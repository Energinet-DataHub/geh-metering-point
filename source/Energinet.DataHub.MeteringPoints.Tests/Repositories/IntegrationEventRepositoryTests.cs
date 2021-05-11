﻿// Copyright 2020 Energinet DataHub A/S
//
// Licensed under the Apache License, Version 2.0 (the "License2");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Energinet.DataHub.MeteringPoints.Application;
using Energinet.DataHub.MeteringPoints.Infrastructure.DataAccess;
using Energinet.DataHub.MeteringPoints.Infrastructure.Helpers;
using Energinet.DataHub.MeteringPoints.Infrastructure.IntegrationServices.Helpers;
using Energinet.DataHub.MeteringPoints.Infrastructure.IntegrationServices.Repository;
using Energinet.DataHub.MeteringPoints.Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using Xunit;

namespace Energinet.DataHub.MeteringPoints.Tests.Repositories
{
    public class IntegrationEventRepositoryTests
    {
        private readonly DbContextOptions<MeteringPointContext> _options;
        private readonly IJsonSerializer _jsonSerializer;
        private IIntegrationEventRepository _integrationEventRepository;

        public IntegrationEventRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<MeteringPointContext>()
                .UseInMemoryDatabase(databaseName: "OutboxMessages")
                .Options;
            _jsonSerializer = new JsonSerializer();
        }

        [Fact]
        public async Task IntegrationEventRepositoryGetUnProcessedIntegrationEventMessageAsyncTest()
        {
            await using var context = new MeteringPointContext(_options);
            context.Add(new OutboxMessage(
                "CreateMeteringPointEventMessage",
                "{\"Gsrn\":\"000000000\",\"MpType\":\"CreateMeteringPointEventMessage\",\"GridAccessProvider\":\"GridAccessProvider\",\"Child\":true,\"EnergySupplierCurrent\":\"EnergySupplierCurrent\"}",
                OutboxMessageCategory.IntegrationEvent,
                SystemClock.Instance.GetCurrentInstant(),
                Guid.NewGuid()));

            await context.SaveChangesAsync().ConfigureAwait(false);

            _integrationEventRepository = new IntegrationEventRepository(context, _jsonSerializer);
            var outBoxMessage = await _integrationEventRepository.GetUnProcessedIntegrationEventMessageAsync().ConfigureAwait(false);

            Assert.IsType<OutboxMessage>(outBoxMessage);
            Assert.Equal("CreateMeteringPointEventMessage", outBoxMessage.Type);
        }

        [Fact]
        public async Task IntegrationEventRepositoryMarkIntegrationEventMessageAsProcessedAsyncTest()
        {
            var guid = Guid.NewGuid();
            await using var context = new MeteringPointContext(_options);
            context.Add(new OutboxMessage(
                "CreateMeteringPointEventMessage",
                "{\"Gsrn\":\"000000000\",\"MpType\":\"CreateMeteringPointEventMessage\",\"GridAccessProvider\":\"GridAccessProvider\",\"Child\":true,\"EnergySupplierCurrent\":\"EnergySupplierCurrent\"}",
                OutboxMessageCategory.IntegrationEvent,
                SystemClock.Instance.GetCurrentInstant(),
                guid));

            await context.SaveChangesAsync().ConfigureAwait(false);

            _integrationEventRepository = new IntegrationEventRepository(context, _jsonSerializer);

            await _integrationEventRepository.MarkIntegrationEventMessageAsProcessedAsync(guid)
                .ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);

            var entity = await context.OutboxMessages.FindAsync(guid).ConfigureAwait(false);
            Assert.True(entity.ProcessedDate != null);
        }

        [Fact]
        public async Task IntegrationEventRepositorySaveIntegrationEventMessageToOutboxAsyncTest()
        {
            await using var context = new MeteringPointContext(_options);

            CreateMeteringPointEventMessage message = new(
                "12345678",
                "CreateMeteringPointEventMessage",
                "GridAccessProvider",
                true,
                "EnergySupplierCurrent");

            _integrationEventRepository = new IntegrationEventRepository(context, _jsonSerializer);

            await _integrationEventRepository.SaveIntegrationEventMessageToOutboxAsync(message).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);

            var entity = await context.OutboxMessages.
                Where(x => x.ProcessedDate == null)
                .Select(x => new OutboxMessage(x.Type, x.Data, x.Category, x.CreationDate, x.Id))
                .FirstOrDefaultAsync().ConfigureAwait(false);

            var parsedMessage = _jsonSerializer.Deserialize(
                entity.Data,
                IntegrationEventTypeFactory.GetType(entity.Type));

            // Assert that processedDate are not set when saving object to the outbox
            Assert.True(entity.ProcessedDate == null);

            // Assert that the category is correct
            Assert.Equal(OutboxMessageCategory.IntegrationEvent, entity.Category);

            // Assert that the parsed type is as expected
            Assert.IsType<CreateMeteringPointEventMessage>(parsedMessage);
        }

        [Fact]
        public void IntegrationEventRepositorySaveIntegrationEventMessageToOutboxAsyncWhenNullTest()
        {
        }
    }
}

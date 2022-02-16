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
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Energinet.DataHub.MeteringPoints.Application.ChangeConnectionStatus;
using Energinet.DataHub.MeteringPoints.Application.Connect;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;
using Energinet.DataHub.MeteringPoints.Infrastructure.DataAccess;
using Energinet.DataHub.MeteringPoints.Infrastructure.EDI;
using Energinet.DataHub.MeteringPoints.Infrastructure.EDI.Acknowledgements;
using Energinet.DataHub.MeteringPoints.Infrastructure.Integration.IntegrationEvents.ChangeConnectionStatus.Reconnect;
using Energinet.DataHub.MeteringPoints.Infrastructure.Serialization;
using Energinet.DataHub.MeteringPoints.IntegrationTests.Tooling;
using NodaTime;
using Xunit;

namespace Energinet.DataHub.MeteringPoints.IntegrationTests.ReconnecMeteringPoints
{
    public class ReconnectTests : TestHost
    {
        private readonly ISystemDateTimeProvider _dateTimeProvider;

        public ReconnectTests(DatabaseFixture databaseFixture)
            : base(databaseFixture)
        {
            _dateTimeProvider = GetService<ISystemDateTimeProvider>();
        }

        [Fact]
        public async Task Metering_point_is_Reconnected()
        {
            await CreateMeteringPointWithEnergySupplierAssigned().ConfigureAwait(false);

            await SendCommandAsync(CreateConnectMeteringPointRequest()).ConfigureAwait(false);

            await SendCommandAsync(CreateDisconnectMeteringPointRequest()).ConfigureAwait(false);

            await SendCommandAsync(CreateReconnectMeteringPointRequest()).ConfigureAwait(false);

            AssertPersistedMeteringPoint
                .Initialize(SampleData.GsrnNumber, GetService<IDbConnectionFactory>())
                .HasConnectionState(PhysicalState.Connected);

            AssertConfirmMessages(DocumentType.ConfirmConnectionStatusMeteringPoint, 2);
            Assert.NotNull(FindIntegrationEvent<MeteringPointReconnectedIntegrationEvent>());
        }

        [Fact]
        public async Task Cannot_reconnect_if_not_disconnected()
        {
            await CreateMeteringPointWithEnergySupplierAssigned().ConfigureAwait(false);

            await SendCommandAsync(CreateReconnectMeteringPointRequest()).ConfigureAwait(false);

            AssertValidationError("D16");
            AssertRejectMessage(DocumentType.RejectConnectionStatusMeteringPoint);
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(1, false)]
        public async Task Effective_date_must_be_within_the_allowed_time_period_in_past(int numberOfDaysOffset, bool expectError)
        {
            var effectiveDate = EffectiveDateInPast(numberOfDaysOffset);

            await CreateMeteringPointWithEnergySupplierAssigned(effectiveDate).ConfigureAwait(false);

            await SendCommandAsync(CreateConnectMeteringPointRequest() with
            {
                EffectiveDate = effectiveDate.ToString(),
            }).ConfigureAwait(false);

            await SendCommandAsync(CreateDisconnectMeteringPointRequest()).ConfigureAwait(false);

            await SendCommandAsync(CreateReconnectMeteringPointRequest() with
            {
                EffectiveDate = effectiveDate.ToString(),
            }).ConfigureAwait(false);

            AssertValidationError("E17", expectError);
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(0, false)]
        public async Task Effective_date_must_be_within_the_allowed_time_period_in_future(int numberOfDaysOffset, bool expectError)
        {
            var effectiveDate = EffectiveDateInFuture(numberOfDaysOffset);

            await CreateMeteringPointWithEnergySupplierAssigned().ConfigureAwait(false);

            await SendCommandAsync(CreateConnectMeteringPointRequest()).ConfigureAwait(false);

            await SendCommandAsync(CreateDisconnectMeteringPointRequest()).ConfigureAwait(false);

            await SendCommandAsync(CreateReconnectMeteringPointRequest() with
            {
                EffectiveDate = effectiveDate.ToString(),
            }).ConfigureAwait(false);

            AssertValidationError("E17", expectError);
        }

        private static Instant ToEffectiveDate(DateTime date)
        {
            return Instant.FromUtc(date.Year, date.Month, date.Day, 23, 0);
        }

        private Task CreateMeteringPointWithEnergySupplierAssigned()
        {
            var currentDate = _dateTimeProvider.Now().ToDateTimeUtc();
            var startOfSupplyDate = Instant.FromUtc(currentDate.Year, currentDate.Month, currentDate.Day, 22, 0);
            return CreateMeteringPointWithEnergySupplierAssigned(startOfSupplyDate);
        }

        private async Task CreateMeteringPointWithEnergySupplierAssigned(Instant startOfSupplyDate)
        {
            await SendCommandAsync(Scenarios.CreateCommand(MeteringPointType.Consumption)).ConfigureAwait(false);
            await MarkAsEnergySupplierAssigned(startOfSupplyDate).ConfigureAwait(false);
        }

        private async Task MarkAsEnergySupplierAssigned(Instant startOfSupply)
        {
            var setEnergySupplierAssigned = new SetEnergySupplierInfo(SampleData.GsrnNumber, startOfSupply);
            await SendCommandAsync(setEnergySupplierAssigned).ConfigureAwait(false);
        }

        private ConnectMeteringPointRequest CreateConnectMeteringPointRequest()
        {
            var currentDate = _dateTimeProvider.Now().ToDateTimeUtc();
            var effectiveDate = Instant.FromUtc(currentDate.Year, currentDate.Month, currentDate.Day, 23, 0);
            return new(SampleData.GsrnNumber, effectiveDate.ToString(), SampleData.Transaction);
        }

        private DisconnectReconnectMeteringPointRequest CreateDisconnectMeteringPointRequest()
        {
            var currentDate = _dateTimeProvider.Now().ToDateTimeUtc();
            var effectiveDate = Instant.FromUtc(currentDate.Year, currentDate.Month, currentDate.Day, 23, 0);
            return new(SampleData.GsrnNumber, effectiveDate.ToString(), SampleData.Transaction, "Disconnected");
        }

        private DisconnectReconnectMeteringPointRequest CreateReconnectMeteringPointRequest()
        {
            var currentDate = _dateTimeProvider.Now().ToDateTimeUtc();
            var effectiveDate = Instant.FromUtc(currentDate.Year, currentDate.Month, currentDate.Day, 23, 0);
            return new(SampleData.GsrnNumber, effectiveDate.ToString(), SampleData.Transaction, "Connected");
        }

        private Instant EffectiveDateInPast(int numberOfDaysFromToday)
        {
            return ToEffectiveDate(_dateTimeProvider.Now().Minus(Duration.FromDays(numberOfDaysFromToday)).ToDateTimeUtc());
        }

        private Instant EffectiveDateInFuture(int numberOfDaysFromToday)
        {
            return ToEffectiveDate(_dateTimeProvider.Now().Plus(Duration.FromDays(numberOfDaysFromToday)).ToDateTimeUtc());
        }

        private void AssertConfirmMessages(DocumentType documentType, int expectedNumbeOfMessages)
        {
            var messages = GetOutboxMessages<MessageHubEnvelope>().Where(msg => msg.MessageType.Equals(documentType)).ToList();

            Assert.Equal(expectedNumbeOfMessages, messages.Count);
            foreach (var confirmMessage in messages.Select(msg => GetService<IJsonSerializer>().Deserialize<ConfirmMessage>(msg.Content)))
            {
                Assert.NotNull(confirmMessage);
            }
        }
    }
}

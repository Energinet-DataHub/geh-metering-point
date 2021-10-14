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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Energinet.DataHub.MeteringPoints.EntryPoints.Common.MediatR;
using Energinet.DataHub.MeteringPoints.Infrastructure.DataAccess.MessageHub.Bundling;
using Energinet.DataHub.MeteringPoints.Infrastructure.EDI;
using Energinet.DataHub.MeteringPoints.Infrastructure.EDI.Acknowledgements;
using Energinet.DataHub.MeteringPoints.Infrastructure.LocalMessageHub;
using Energinet.DataHub.MeteringPoints.Infrastructure.Serialization;
using Energinet.DataHub.MeteringPoints.Messaging.Bundling;
using FluentAssertions;
using MediatR;
using NodaTime;
using SimpleInjector;
using Xunit;
using Xunit.Categories;

namespace Energinet.DataHub.MeteringPoints.Tests.LocalMessageHub
{
    [UnitTest]
    public class BundleCreatorTests
    {
        [Fact]
        public async Task Bundles_should_be_created_for_multiple_documents()
        {
            await using var container = new Container();
            container.BuildMinimalMediator(typeof(BundleHandler<>).Assembly, Array.Empty<Type>());
            container.Register<IRequestHandler<BundleRequest<ConfirmMessage>, string>, ConfirmMessageBundleHandler>();
            container.Register<IJsonSerializer, JsonSerializer>();
            container.Register<IBundleCreator, BundleCreator>();
            container.Register<IDocumentSerializer<ConfirmMessage>, ConfirmMessageSerializer>();
            var sut = container.GetInstance<IBundleCreator>();
            var confirmMessages = CreateConfirmMessages().ToList();
            var messageHubMessages = CreateMessages(confirmMessages);

            var bundle = await sut.CreateBundleAsync(messageHubMessages).ConfigureAwait(false);

            bundle.Should().NotBeNull();
            bundle.Should().ContainAll(confirmMessages.Select(message => message.MarketActivityRecord.Id.ToString()));
        }

        private static List<MessageHubMessage> CreateMessages(IEnumerable<ConfirmMessage> createConfirmMessages)
        {
            var officeMessages = createConfirmMessages
                .Select(message => new JsonSerializer().Serialize(message))
                .Select(message => new MessageHubMessage(message, "correlation", DocumentType.CreateMeteringPointAccepted, "recipient", SystemClock.Instance.GetCurrentInstant()))
                .ToList();
            return officeMessages;
        }

        private static IEnumerable<ConfirmMessage> CreateConfirmMessages()
        {
            return new Fixture().Create<List<ConfirmMessage>>()
                .Select(message => message with { DocumentName = "Foo" });
        }
    }
}

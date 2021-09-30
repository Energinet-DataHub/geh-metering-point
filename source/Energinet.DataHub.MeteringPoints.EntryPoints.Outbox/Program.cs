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
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;
using Energinet.DataHub.MeteringPoints.EntryPoints.Common;
using Energinet.DataHub.MeteringPoints.EntryPoints.Common.MediatR;
using Energinet.DataHub.MeteringPoints.EntryPoints.Common.SimpleInjector;
using Energinet.DataHub.MeteringPoints.EntryPoints.Outbox.ActorMessages;
using Energinet.DataHub.MeteringPoints.EntryPoints.Outbox.Common;
using Energinet.DataHub.MeteringPoints.Infrastructure;
using Energinet.DataHub.MeteringPoints.Infrastructure.BusinessRequestProcessing.Pipeline;
using Energinet.DataHub.MeteringPoints.Infrastructure.Correlation;
using Energinet.DataHub.MeteringPoints.Infrastructure.DataAccess;
using Energinet.DataHub.MeteringPoints.Infrastructure.Integration;
using Energinet.DataHub.MeteringPoints.Infrastructure.Integration.IntegrationEvents.CreateMeteringPoint;
using Energinet.DataHub.MeteringPoints.Infrastructure.Integration.IntegrationEvents.CreateMeteringPoint.Consumption;
using Energinet.DataHub.MeteringPoints.Infrastructure.Outbox;
using Energinet.DataHub.MeteringPoints.Infrastructure.PostOffice;
using Energinet.DataHub.MeteringPoints.Infrastructure.Serialization;
using Energinet.DataHub.MeteringPoints.Infrastructure.Transport.Protobuf.Integration;
using Energinet.DataHub.MeteringPoints.IntegrationEventContracts;
using EntityFrameworkCore.SqlServer.NodaTime.Extensions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using SimpleInjector.Lifestyles;

[assembly: CLSCompliant(false)]

namespace Energinet.DataHub.MeteringPoints.EntryPoints.Outbox
{
    public class Program : EntryPoint
    {
        public static async Task Main()
        {
            var program = new Program();

            var host = program.ConfigureApplication();
            program.AssertConfiguration();
            await program.ExecuteApplicationAsync(host).ConfigureAwait(false);
        }

        protected override void ConfigureServiceCollection(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            base.ConfigureServiceCollection(services);

            services.AddDbContext<MeteringPointContext>(x =>
            {
                var connectionString = Environment.GetEnvironmentVariable("METERINGPOINT_DB_CONNECTION_STRING")
                                       ?? throw new InvalidOperationException(
                                           "Metering point db connection string not found.");

                x.UseSqlServer(connectionString, y => y.UseNodaTime());
            });
        }

        protected override void ConfigureContainer(Container container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            base.ConfigureContainer(container);

            // Register application components.
            container.Register(
                () => new PostOfficeStorageClientSettings(
                    Environment.GetEnvironmentVariable("TEMP_POST_OFFICE_CONNECTION_STRING")!,
                    Environment.GetEnvironmentVariable("TEMP_POST_OFFICE_SHARE")!));
            container.Register<ISystemDateTimeProvider, SystemDateTimeProvider>(Lifestyle.Scoped);
            container.Register<IJsonSerializer, JsonSerializer>(Lifestyle.Scoped);
            container.Register<IOutboxManager, OutboxManager>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<OutboxWatcher>(Lifestyle.Scoped);
            container.Register<IPostOfficeStorageClient, TempPostOfficeStorageClient>(Lifestyle.Scoped);
            container.Register<OutboxOrchestrator>(Lifestyle.Scoped);
            container.Register<IOutboxMessageDispatcher, OutboxMessageDispatcher>(Lifestyle.Transient);
            container.RegisterDecorator<IOutboxMessageDispatcher, OutboxMessageDispatcherTelemetryDecorator>(
                Lifestyle.Scoped);
            container.Register<OutboxMessageFactory>(Lifestyle.Scoped);
            container.Register<ICorrelationContext, CorrelationContext>(Lifestyle.Scoped);
            container.Register<IIntegrationMetadataContext, IntegrationMetadataContext>(Lifestyle.Scoped);
            container.Register<IIntegrationEventMessageFactory, IntegrationEventServiceBusMessageFactory>(Lifestyle.Scoped);

            var connectionString =
                Environment.GetEnvironmentVariable("SHARED_INTEGRATION_EVENT_SERVICE_BUS_SENDER_CONNECTION_STRING");
            container.Register<ServiceBusClient>(
                () => new ServiceBusClient(connectionString),
                Lifestyle.Singleton);

            container.Register(
                () => new MeteringPointCreatedTopic(
                    Environment.GetEnvironmentVariable("METERING_POINT_CREATED_TOPIC") ??
                    throw new InvalidOperationException(
                        "No MeteringPointCreated Topic found")),
                Lifestyle.Singleton);
            container.Register(
                () => new ConsumptionMeteringPointCreatedTopic(
                    Environment.GetEnvironmentVariable("CONSUMPTION_METERING_POINT_CREATED_TOPIC") ??
                    throw new InvalidOperationException(
                        "No Consumption Metering Point Created Topic found")),
                Lifestyle.Singleton);
            container.Register(
                () => new MeteringPointConnectedTopic(
                    Environment.GetEnvironmentVariable("METERING_POINT_CONNECTED_TOPIC") ??
                    throw new InvalidOperationException(
                        "No MeteringPointConnected Topic found")),
                Lifestyle.Singleton);

            container.Register(typeof(ITopicSender<>), typeof(TopicSender<>), Lifestyle.Singleton);

            container.SendProtobuf<IntegrationEventEnvelope>();

            // Setup pipeline behaviors
            container.BuildMediator(
                new[]
                {
                    typeof(OutboxWatcher).Assembly,
                },
                Array.Empty<Type>());
        }
    }
}

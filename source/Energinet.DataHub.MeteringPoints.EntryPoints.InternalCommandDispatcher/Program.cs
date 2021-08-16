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
using Energinet.DataHub.MeteringPoints.EntryPoints.Common.SimpleInjector;
using Energinet.DataHub.MeteringPoints.Infrastructure;
using Energinet.DataHub.MeteringPoints.Infrastructure.DataAccess;
using Energinet.DataHub.MeteringPoints.Infrastructure.Integration.IntegrationEvents.Connect;
using Energinet.DataHub.MeteringPoints.Infrastructure.InternalCommands;
using Energinet.DataHub.MeteringPoints.Infrastructure.Transport.Protobuf.Integration;
using Energinet.DataHub.MeteringPoints.InternalCommandsContracts;
using EntityFrameworkCore.SqlServer.NodaTime.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace Energinet.DataHub.MeteringPoints.EntryPoints.InternalCommandDispatcher
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
                var dbConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                                         ?? throw new InvalidOperationException(
                                             "Metering point db connection string not found.");

                x.UseSqlServer(dbConnectionString, options => options.UseNodaTime());
            });
        }

        protected override void ConfigureContainer(Container container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            base.ConfigureContainer(container);

            // Register application components.
            container.Register<Dispatcher>(Lifestyle.Scoped);
            container.Register<ISystemDateTimeProvider, SystemDateTimeProvider>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IInternalCommandAccessor, InternalCommandAccessor>(Lifestyle.Scoped);
            container.Register<IInternalCommandProcessor, InternalCommandProcessor>(Lifestyle.Scoped);
            container.Register<IInternalCommandDispatcher, InternalCommandServiceBusDispatcher>(Lifestyle.Scoped);

            var connectionString = Environment.GetEnvironmentVariable("PROCESSING_QUEUE_CONNECTION_STRING");
            var queueName = Environment.GetEnvironmentVariable("PROCESSING_QUEUE_NAME");
            container.Register<ServiceBusSender>(
                () => new ServiceBusClient(connectionString).CreateSender(queueName),
                Lifestyle.Singleton);

            container.SendProtobuf<SetEnergySupplierInfo>();
        }
    }
}

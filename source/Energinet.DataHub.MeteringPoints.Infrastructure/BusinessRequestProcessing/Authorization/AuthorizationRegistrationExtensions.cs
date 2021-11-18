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
using Energinet.DataHub.MeteringPoints.Application.Authorization;
using Energinet.DataHub.MeteringPoints.Application.ChangeMasterData;
using Energinet.DataHub.MeteringPoints.Application.ChangeMasterData.Consumption;
using Energinet.DataHub.MeteringPoints.Application.Connect;
using Energinet.DataHub.MeteringPoints.Application.Create.Consumption;
using Energinet.DataHub.MeteringPoints.Application.Create.Exchange;
using Energinet.DataHub.MeteringPoints.Application.Create.Production;
using Energinet.DataHub.MeteringPoints.Application.Create.Special;
using SimpleInjector;

namespace Energinet.DataHub.MeteringPoints.Infrastructure.BusinessRequestProcessing.Authorization
{
    public static class AuthorizationRegistrationExtensions
    {
        public static void AddBusinessProcessAuthorizers(this Container container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            container.Register<IAuthorizer<ChangeMasterDataRequest>, Authorizer>();
            container.Register<IAuthorizer<CreateConsumptionMeteringPoint>, NullAuthorizer<CreateConsumptionMeteringPoint>>();
            container.Register<IAuthorizer<CreateProductionMeteringPoint>, NullAuthorizer<CreateProductionMeteringPoint>>();
            container.Register<IAuthorizer<CreateExchangeMeteringPoint>, NullAuthorizer<CreateExchangeMeteringPoint>>();
            container.Register<IAuthorizer<ConnectMeteringPoint>, NullAuthorizer<ConnectMeteringPoint>>();
            container.Register<IAuthorizer<CreateSpecialMeteringPoint>, NullAuthorizer<CreateSpecialMeteringPoint>>();
        }
    }
}

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
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;
using Energinet.DataHub.MeteringPoints.Infrastructure.Integration.Helpers;
using Energinet.DataHub.MeteringPoints.Infrastructure.Transport.Protobuf;
using Energinet.DataHub.MeteringPoints.IntegrationEventContracts;
using Google.Protobuf;

namespace Energinet.DataHub.MeteringPoints.Infrastructure.Integration.IntegrationEvents.CreateMeteringPoint.Exchange
{
    public class ExchangeMeteringPointCreatedOutBoundMapper : ProtobufOutboundMapper<ExchangeMeteringPointCreatedIntegrationEvent>
    {
        protected override IMessage Convert(ExchangeMeteringPointCreatedIntegrationEvent obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new ExchangeMeteringPointCreated
            {
                MeteringPointId = obj.MeteringPointId,
                GsrnNumber = obj.GsrnNumber,
                GridAreaCode = obj.GridAreaCode,
                MeteringMethod = EnumerationType.FromName<MeteringMethod>(obj.MeteringMethod).MapToEnum<ExchangeMeteringPointCreated.Types.MeteringMethod>(),
                MeterReadingPeriodicity = EnumerationType.FromName<ReadingOccurrence>(obj.MeterReadingPeriodicity).MapToEnum<ExchangeMeteringPointCreated.Types.MeterReadingPeriodicity>(),
                Product = EnumerationType.FromName<ProductType>(obj.ProductType).MapToEnum<ExchangeMeteringPointCreated.Types.ProductType>(),
                EffectiveDate = obj.EffectiveDate.ToTimestamp(),
                ConnectionState = EnumerationType.FromName<PhysicalState>(obj.ConnectionState).MapToEnum<ExchangeMeteringPointCreated.Types.ConnectionState>(),
                FromGridAreaCode = obj.FromGrid,
                ToGridAreaCode = obj.ToGrid,
            };
        }
    }
}

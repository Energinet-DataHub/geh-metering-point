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

using Energinet.DataHub.MeteringPoints.Domain.Addresses;
using Energinet.DataHub.MeteringPoints.Domain.GridAreas;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;
using NodaTime;

namespace Energinet.DataHub.MeteringPoints.Domain.MeteringPoints
{
    public class ExchangeMeteringPoint : MeteringPoint
    {
        private string? _fromGrid;
        private string? _toGrid;

        public ExchangeMeteringPoint(
            MeteringPointId id,
            GsrnNumber gsrnNumber,
            Address address,
            MeteringMethod meteringMethod,
            MeteringPointType meteringPointType,
            GridAreaLinkId gridAreaLinkId,
            GsrnNumber? powerPlantGsrnNumber,
            LocationDescription? locationDescription,
            MeasurementUnitType unitType,
            MeterId? meterNumber,
            ReadingOccurrence meterReadingOccurrence,
            PowerLimit powerLimit,
            EffectiveDate effectiveDate,
            string? toGrid,
            string? fromGrid,
            ProductType productType,
            Capacity? capacity)
            : base(
                id,
                gsrnNumber,
                address,
                meteringMethod,
                meteringPointType,
                gridAreaLinkId,
                powerPlantGsrnNumber,
                locationDescription,
                unitType,
                meterNumber,
                meterReadingOccurrence,
                powerLimit,
                effectiveDate,
                capacity)
        {
            _toGrid = toGrid;
            _fromGrid = fromGrid;
            _productType = productType;

            AddDomainEvent(new MeteringPointCreated(id, GsrnNumber, meteringPointType, gridAreaLinkId, meteringMethod, ConnectionState.PhysicalState, meterReadingOccurrence, ProductType.Tariff, unitType, toGrid, fromGrid));
        }

#pragma warning disable 8618 // Must have an empty constructor, since EF cannot bind Address in main constructor
        private ExchangeMeteringPoint() { }
#pragma warning restore 8618

        public override BusinessRulesValidationResult ConnectAcceptable(ConnectionDetails connectionDetails)
        {
            throw new System.NotImplementedException();
        }

        public override void Connect(ConnectionDetails connectionDetails)
        {
            throw new System.NotImplementedException();
        }
    }
}

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
using NodaTime;

namespace Energinet.DataHub.MeteringPoints.Tests
{
    public static class SampleData
    {
        public static string GsrnNumber => "571234567891234568";

        public static string GridAreaLinkId => "10A9E0E7-3906-4DC0-8CBD-A5C042A5C484";

        public static string StreetName => "Test Road 1";

        public static string PostCode => "8000";

        public static string CityName => "Aarhus";

        public static string CountryCode => "DK";

        public static bool IsOfficialAddress => true;

        public static string PhysicalStateName => PhysicalState.Connected.Name;

        public static string SubTypeName => MeteringPointSubType.Physical.Name;

        public static string TypeName => MeteringPointType.Consumption.Name;

        public static string PowerPlant => "571234567891234568";

        public static string LocationDescription => string.Empty;

        public static string ProductType => string.Empty;

        public static string? ParentRelatedMeteringPoint => null;

        public static string UnitType => string.Empty;

        public static string MeterNumber => "123456";

        public static string MeterReadingOccurence => string.Empty;

        public static int MaximumCurrent => 0;

        public static int MaximumPower => 230;

        public static string EffectiveDate => EffectiveDateNow();

        public static string SettlementMethod => MeteringPoints.Domain.MeteringPoints.Consumption.SettlementMethod.Flex.Name;

        public static string NetSettlementGroup => Energinet.DataHub.MeteringPoints.Domain.MeteringPoints.NetSettlementGroup.Six.Name;

        public static string DisconnectionType => string.Empty;

        public static string ConnectionType => string.Empty;

        public static string AssetType => "KWh";

        public static string Floor => string.Empty;

        public static string StreetCode => string.Empty;

        public static string BuildingNumber => string.Empty;

        public static string Room => string.Empty;

        public static string CitySubdivision => string.Empty;

        public static int MunicipalityCode => default;

        public static string ScheduledMeterReadingDate => "0101";

        public static Guid GeoInfoReference => Guid.Parse("EB0ECFD2-97AD-48E3-8502-04C36AA7ACF8");

        private static string EffectiveDateNow()
        {
            var currentDate = SystemClock.Instance.GetCurrentInstant().InUtc();
            var effectiveDate = Instant.FromUtc(currentDate.Year, currentDate.Month, currentDate.Day, 22, 0, 0);
            return effectiveDate.ToString();
        }
    }
}

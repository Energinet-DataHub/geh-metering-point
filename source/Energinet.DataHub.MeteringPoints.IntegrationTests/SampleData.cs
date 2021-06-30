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

namespace Energinet.DataHub.MeteringPoints.IntegrationTests
{
    public static class SampleData
    {
        public static string GsrnNumber => "571234567891234568";

        public static string TypeOfMeteringPoint => nameof(MeteringPointType.Consumption);

        public static string Transaction => Guid.NewGuid().ToString();

        public static string SubTypeOfMeteringPoint => nameof(MeteringPointSubType.Physical);

        public static string SettlementMethod => nameof(Domain.MeteringPoints.SettlementMethod.Flex);

        public static string DisconnectionType => nameof(Domain.MeteringPoints.DisconnectionType.Manual);

        public static string ConnectionType => nameof(Domain.MeteringPoints.ConnectionType.Installation);

        public static string PowerPlantGsrnNumber => "571234567891234568";

        public static string ReadingOccurrence => nameof(Domain.MeteringPoints.ReadingOccurrence.Hourly);

        public static string AssetType => nameof(Domain.MeteringPoints.AssetType.GasTurbine);

        public static string Occurrence => "2021-05-05T10:10:10Z";

        public static string MeasurementUnitType => nameof(Domain.MeteringPoints.MeasurementUnitType.KWh);

        public static string MeteringGridArea => "990";

        public static string StreetName => "Test Road 1";

        public static string PostCode => "8000";

        public static string CityName => "Aarhus";

        public static string CountryCode => "DK";

        public static bool IsWashable => true;

        public static string MeterNumber => "12345678910";
    }
}

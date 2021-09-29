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
using Energinet.DataHub.MeteringPoints.Domain.Addresses;
using Energinet.DataHub.MeteringPoints.Domain.GridAreas;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints.Consumption;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints.MarketMeteringPoints.Rules;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;
using Xunit;
using Xunit.Categories;
using CreationRules = Energinet.DataHub.MeteringPoints.Domain.MeteringPoints.MarketMeteringPoints.CreationRules;

namespace Energinet.DataHub.MeteringPoints.Tests.Domain.MeteringPoints.MarketMeteringPoints
{
    [UnitTest]
    public class CreationTests
    {
        [Fact]
        public void Should_return_error__meter_reading_occurrence_is_not_quarterly_or_hourly()
        {
            var details = CreateDetails()
                with
                {
                    ReadingOccurrence = ReadingOccurrence.Yearly,
                };

            var creationRules = new CreationRules(details);
            var result = new BusinessRulesValidationResult(creationRules.Rules);

            Assert.False(result.Success);
            Assert.Contains(result.Errors, e => e is InvalidMeterReadingOccurrenceRuleError);
        }

        private static MeteringPointDetails CreateDetails()
        {
            var address = Address.Create(
                SampleData.StreetName,
                SampleData.StreetCode,
                SampleData.BuildingNumber,
                SampleData.CityName,
                SampleData.CitySubdivision,
                SampleData.PostCode,
                EnumerationType.FromName<CountryCode>(SampleData.CountryCode),
                SampleData.Floor,
                SampleData.Room,
                SampleData.MunicipalityCode);

            var details = new MeteringPointDetails(
                MeteringPointId.New(),
                GsrnNumber.Create(SampleData.GsrnNumber),
                address,
                SampleData.IsOfficialAddress,
                EnumerationType.FromName<MeteringPointSubType>(SampleData.SubTypeName),
                new GridAreaLinkId(Guid.Parse(SampleData.GridAreaLinkId)),
                GsrnNumber.Create(SampleData.PowerPlant),
                LocationDescription.Create(SampleData.LocationDescription),
                SampleData.MeterNumber,
                ReadingOccurrence.Hourly,
                PowerLimit.Create(SampleData.MaximumPower, SampleData.MaximumCurrent),
                EffectiveDate.Create(SampleData.EffectiveDate),
                SettlementMethod.Flex,
                NetSettlementGroup.Six,
                DisconnectionType.Remote,
                ConnectionType.Installation,
                AssetType.WindTurbines,
                ScheduledMeterReadingDate.Create("0101"));

            return details;
        }
    }
}

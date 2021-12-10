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
using Energinet.DataHub.MeteringPoints.Domain.MeteringDetails;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints.MarketMeteringPoints;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints.MarketMeteringPoints.Rules;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints.Production;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints.Rules;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;
using Xunit;
using Xunit.Categories;

namespace Energinet.DataHub.MeteringPoints.Tests.Domain.MeteringPoints.MarketMeteringPoints
{
    [UnitTest]
    public class CreationTests : TestBase
    {
        [Fact]
        public void Should_return_error__meter_reading_occurrence_is_not_quarterly_or_hourly()
        {
            var details = CreateConsumptionDetails()
                with
                {
                    ReadingOccurrence = ReadingOccurrence.Yearly,
                };

            var result = MarketMeteringPoint.CanCreate(details);

            Assert.False(result.Success);
            AssertError<InvalidMeterReadingOccurrenceRuleError>(result, true);
        }

        [Fact]
        public void Connection_type_is_required_when_net_settlement_group_is_not_0()
        {
            var details = CreateConsumptionDetails()
                with
                {
                    NetSettlementGroup = NetSettlementGroup.Six,
                    ConnectionType = null,
                };

            var result = MarketMeteringPoint.CanCreate(details);

            Assert.False(result.Success);
            AssertError<ConnectionTypeIsRequiredRuleError>(result, true);
        }

        [Fact]
        public void Connection_type_is_not_allowed_for_net_settlement_group_0()
        {
            var details = CreateConsumptionDetails()
                with
                {
                    NetSettlementGroup = NetSettlementGroup.Zero,
                    ConnectionType = ConnectionType.Installation,
                };

            var result = MarketMeteringPoint.CanCreate(details);

            Assert.False(result.Success);
            AssertError<ConnectionTypeIsNotAllowedRuleError>(result, true);
        }

        [Fact]
        public void Connection_type_must_match_net_settlement_group()
        {
            var details = CreateConsumptionDetails()
                with
                {
                    NetSettlementGroup = NetSettlementGroup.Six,
                    ConnectionType = ConnectionType.Direct,
                };

            var result = MarketMeteringPoint.CanCreate(details);

            AssertError<ConnectionTypeDoesNotMatchNetSettlementGroupRuleError>(result, true);
        }

        [Theory]
        [InlineData("Zero", "Physical", false)]
        [InlineData("One", "Physical", true)]
        [InlineData("One", "Virtual", false)]
        [InlineData("One", "Calculated", false)]
        [InlineData("Two", "Physical", true)]
        [InlineData("Two", "Virtual", false)]
        [InlineData("Two", "Calculated", false)]
        [InlineData("Three", "Physical", true)]
        [InlineData("Three", "Virtual", false)]
        [InlineData("Three", "Calculated", false)]
        [InlineData("Six", "Physical", true)]
        [InlineData("Six", "Virtual", false)]
        [InlineData("Six", "Calculated", false)]
        [InlineData("NinetyNine", "Physical", false)]
        public void Metering_method_must_be_virtual_or_calculated_when_net_settlement_group_is_not_0_or_99(string netSettlementGroup, string meteringMethod, bool expectError)
        {
            var method = EnumerationType.FromName<MeteringMethod>(meteringMethod);
            var meter = method == MeteringMethod.Physical ? MeterId.Create("Fake") : MeterId.Empty();
            var details = CreateConsumptionDetails()
                with
                {
                    NetSettlementGroup = EnumerationType.FromName<NetSettlementGroup>(netSettlementGroup),
                    MeteringConfiguration = MeteringConfiguration.Create(method, meter),
                };

            var result = MarketMeteringPoint.CanCreate(details);

            AssertError<MeteringMethodDoesNotMatchNetSettlementGroupRuleError>(result, expectError);
        }
    }
}

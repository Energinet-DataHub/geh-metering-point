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

using System.Threading.Tasks;
using Energinet.DataHub.MeteringPoints.Application.Common;
using Energinet.DataHub.MeteringPoints.Domain.MeteringDetails;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints.MarketMeteringPoints;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;
using Energinet.DataHub.MeteringPoints.IntegrationTests.Tooling;
using NodaTime.Text;
using Xunit;
using Xunit.Categories;

namespace Energinet.DataHub.MeteringPoints.IntegrationTests.ChangeMasterData.ConsumptionMeteringPoints
{
    [IntegrationTest]
    public class ChangeTests : TestHost
    {
        public ChangeTests(DatabaseFixture databaseFixture)
            : base(databaseFixture)
        {
        }

        [Fact]
        public async Task Metering_point_must_exist()
        {
            await InvokeBusinessProcessAsync(TestUtils.CreateRequest()).ConfigureAwait(false);

            AssertValidationError("E10");
        }

        [Theory]
        [InlineData("invalid_gsrn_number")]
        [InlineData("")]
        public async Task Gsrn_number_is_required(string gsrnNumber)
        {
            await InvokeBusinessProcessAsync(TestUtils.CreateRequest()
                with
                {
                    GsrnNumber = gsrnNumber,
                }).ConfigureAwait(false);

            AssertValidationError("E10");
        }

        [Fact]
        public async Task Effective_date_is_required()
        {
            await InvokeBusinessProcessAsync(TestUtils.CreateRequest()
                with
                {
                    EffectiveDate = string.Empty,
                }).ConfigureAwait(false);

            AssertValidationError("D02");
        }

        [Theory]
        [InlineData("2021-01-01T18:00:00Z", "2021-01-02T22:00:00Z", true)]
        [InlineData("2021-01-01T18:00:00Z", "2020-12-30T22:00:00Z", true)]
        [InlineData("2021-01-01T18:00:00Z", "2021-01-01T22:00:00Z", false)]
        [InlineData("2021-01-01T18:00:00Z", "2020-12-31T22:00:00Z", false)]
        public async Task Effective_date_is_today_or_the_day_before(string today, string effectiveDate, bool expectError)
        {
            var timeProvider = GetService<ISystemDateTimeProvider>() as SystemDateTimeProviderStub;
            timeProvider!.SetNow(InstantPattern.General.Parse(today).Value);

            await CreateMeteringPointAsync().ConfigureAwait(false);

            await InvokeBusinessProcessAsync(TestUtils.CreateRequest()
                with
                {
                    EffectiveDate = effectiveDate,
                }).ConfigureAwait(false);

            AssertValidationError("E17", expectError);
        }

        [Fact]
        public async Task Grid_operator_is_the_owner_of_the_metering_point()
        {
            SetGridOperatorAsAuthenticatedUser("This_is_not_the_owner_of_this_metering_point");
            await CreateMeteringPointAsync().ConfigureAwait(false);

            await InvokeBusinessProcessAsync(TestUtils.CreateRequest()).ConfigureAwait(false);

            AssertValidationError("E10");
        }

        [Fact]
        public async Task Reject_when_settlement_method_is_invalid()
        {
            var request = TestUtils.CreateRequest()
                with
                {
                    SettlementMethod = "Invalid_Method_Name",
                };

            await InvokeBusinessProcessAsync(request).ConfigureAwait(false);

            AssertValidationError("D15");
        }

        [Fact]
        public async Task Meter_is_required_when_physical()
        {
            var timeProvider = GetService<ISystemDateTimeProvider>() as SystemDateTimeProviderStub;
            timeProvider!.SetNow(InstantPattern.General.Parse(SampleData.EffectiveDate).Value);

            await CreatePhysicalConsumptionMeteringPoint().ConfigureAwait(false);

            var request = TestUtils.CreateRequest()
                with
                {
                    MeterId = string.Empty,
                };
            await InvokeBusinessProcessAsync(request).ConfigureAwait(false);

            AssertValidationError("D31");
        }

        private Task<BusinessProcessResult> CreateMeteringPointAsync()
        {
            return InvokeBusinessProcessAsync(Scenarios.CreateConsumptionMeteringPointCommand());
        }

        private async Task CreatePhysicalConsumptionMeteringPoint()
        {
            var request = Scenarios.CreateConsumptionMeteringPointCommand()
                with
                {
                    MeteringMethod = MeteringMethod.Physical.Name,
                    MeterNumber = "1",
                    NetSettlementGroup = NetSettlementGroup.Zero.Name,
                    ConnectionType = null,
                    ScheduledMeterReadingDate = null,
                };
            await InvokeBusinessProcessAsync(request).ConfigureAwait(false);
        }
    }
}
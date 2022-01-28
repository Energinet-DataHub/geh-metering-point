﻿// Copyright 2020 Energinet DataHub A/S
//
// Licensed under the Apache License, Version 2.0 (the "License2");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Xunit;

namespace Energinet.DataHub.MeteringPoints.Tests.Domain.MeteringPoints
{
    public class DisconnectTests : TestBase
    {
        private readonly SystemDateTimeProviderStub _systemDateTimeProvider;

        public DisconnectTests()
        {
            _systemDateTimeProvider = new SystemDateTimeProviderStub();
        }

        [Fact(Skip = "Not implemented yet")]
        public void Metering_point_must_be_connected()
        {
        }

        [Fact(Skip = "Not implemented yet")]
        public void Not_possible_when_no_energy_supplier_E17_E18()
        {
        }

        [Fact(Skip = "Not implemented yet")]
        public void Should_succeed()
        {
        }
    }
}

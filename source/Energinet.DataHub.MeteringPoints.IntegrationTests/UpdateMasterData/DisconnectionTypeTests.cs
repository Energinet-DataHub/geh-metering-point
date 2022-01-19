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
using Energinet.DataHub.MeteringPoints.Domain.MasterDataHandling.Components;
using Energinet.DataHub.MeteringPoints.Infrastructure.DataAccess;
using Energinet.DataHub.MeteringPoints.IntegrationTests.Tooling;
using Xunit;

namespace Energinet.DataHub.MeteringPoints.IntegrationTests.UpdateMasterData
{
    public class DisconnectionTypeTests : TestHost
    {
        public DisconnectionTypeTests(DatabaseFixture databaseFixture)
            : base(databaseFixture)
        {
        }

        [Fact]
        public async Task Disconnection_type_is_changed()
        {
            await SendCommandAsync(Scenarios.CreateVEProduction() with
            {
                DisconnectionType = DisconnectionType.Manual.Name,
            }).ConfigureAwait(false);

            var request = CreateUpdateRequest()
                with
                {
                    DisconnectionType = DisconnectionType.Remote.Name,
                };

            await SendCommandAsync(request).ConfigureAwait(false);

            AssertMasterData()
                .HasDisconnectionType(DisconnectionType.Remote);
        }

        private AssertPersistedMeteringPoint AssertMasterData()
        {
            return AssertPersistedMeteringPoint
                .Initialize(SampleData.GsrnNumber, GetService<IDbConnectionFactory>());
        }
    }
}

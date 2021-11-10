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

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Energinet.DataHub.Core.FunctionApp.TestCommon;
using Energinet.DataHub.MeteringPoints.EntryPoints.IntegrationTests.Fixtures;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Energinet.DataHub.MeteringPoints.EntryPoints.IntegrationTests.Functions
{
    [Collection(nameof(IngestionFunctionAppCollectionFixture))]
    public class MeteringPointHttpTriggerTests_RunAsync : FunctionAppTestBase<IngestionFunctionAppFixture>, IAsyncLifetime
    {
        public MeteringPointHttpTriggerTests_RunAsync(IngestionFunctionAppFixture fixture, ITestOutputHelper testOutputHelper)
            : base(fixture, testOutputHelper)
        {
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task When_CallingMeteringPoint_Then_RequestIsProcessed()
        {
            // Arrange
            using var request = new HttpRequestMessage(HttpMethod.Post, "api/MeteringPoint");

            // Act
            var actualResponse = await Fixture.HostManager.HttpClient.SendAsync(request)
                .ConfigureAwait(false);

            // Assert
            actualResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
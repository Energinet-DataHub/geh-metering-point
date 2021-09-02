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

using System.Threading;
using System.Threading.Tasks;
using Energinet.DataHub.MeteringPoints.Application.Connect;
using Energinet.DataHub.MeteringPoints.Application.Create;
using Energinet.DataHub.MeteringPoints.Application.Extensions;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;
using Energinet.DataHub.MeteringPoints.Infrastructure.EDI;
using Energinet.DataHub.MeteringPoints.Infrastructure.EDI.AccountingPointCharacteristics;
using Energinet.DataHub.MeteringPoints.Infrastructure.EDI.ConnectMeteringPoint;
using Energinet.DataHub.MeteringPoints.Infrastructure.Integration.IntegrationEvents.Connect;
using Energinet.DataHub.MeteringPoints.IntegrationTests.Tooling;
using MediatR;
using NodaTime;
using Xunit;
using Xunit.Categories;

namespace Energinet.DataHub.MeteringPoints.IntegrationTests.ConnectMeteringPoints
{
    [IntegrationTest]
    public class ConnectTests
        : TestHost
    {
        private readonly ISystemDateTimeProvider _dateTimeProvider;

        public ConnectTests(DatabaseFixture databaseFixture)
            : base(databaseFixture)
        {
            _dateTimeProvider = GetService<ISystemDateTimeProvider>();
        }

        [Fact]
        public async Task ConnectMeteringPoint_WithNoValidationErrors_ShouldGenerateConfirmMessageInOutbox()
        {
            var createMeteringPointRequest = CreateMeteringPointRequest();
            var connectMeteringPointRequest = CreateConnectMeteringPointRequest();

            await SendCommandAsync(createMeteringPointRequest).ConfigureAwait(false);
            await MarkAsEnergySupplierAssigned(connectMeteringPointRequest.EffectiveDate.ToInstant()).ConfigureAwait(false);
            await SendCommandAsync(connectMeteringPointRequest).ConfigureAwait(false);

            AssertOutboxMessage<PostOfficeEnvelope>(envelope => envelope.MessageType == typeof(ConnectMeteringPointAccepted).FullName);
        }

        [Fact]
        public async Task Connect_MeteringPoint_Should_Generate_AccountingPointCharacteristicsMessage_In_Outbox()
        {
            var createMeteringPointRequest = CreateMeteringPointRequest();
            var connectMeteringPointRequest = CreateConnectMeteringPointRequest();

            await SendCommandAsync(createMeteringPointRequest, CancellationToken.None).ConfigureAwait(false);
            await MarkAsEnergySupplierAssigned(connectMeteringPointRequest.EffectiveDate.ToInstant()).ConfigureAwait(false);
            await SendCommandAsync(connectMeteringPointRequest, CancellationToken.None).ConfigureAwait(false);

            AssertOutboxMessage<PostOfficeEnvelope>(envelope => envelope.MessageType == typeof(AccountingPointCharacteristicsMessage).FullName);
        }

        [Fact]
        public async Task Reject_When_No_Energy_Supplier_Is_Assigned()
        {
            var createMeteringPointRequest = CreateMeteringPointRequest();
            var connectMeteringPointRequest = CreateConnectMeteringPointRequest();

            await SendCommandAsync(createMeteringPointRequest, CancellationToken.None).ConfigureAwait(false);
            await SendCommandAsync(connectMeteringPointRequest, CancellationToken.None).ConfigureAwait(false);

            AssertOutboxMessage<PostOfficeEnvelope>(envelope => envelope.MessageType == typeof(ConnectMeteringPointRejected).FullName);
        }

        [Fact]
        public async Task ConnectMeteringPoint_WithNoValidationErrors_ShouldGenerateIntegrationEventInOutbox()
        {
            var createMeteringPointRequest = CreateMeteringPointRequest();
            var connectMeteringPointRequest = CreateConnectMeteringPointRequest();

            await SendCommandAsync(createMeteringPointRequest, CancellationToken.None).ConfigureAwait(false);
            await MarkAsEnergySupplierAssigned(connectMeteringPointRequest.EffectiveDate.ToInstant()).ConfigureAwait(false);
            await SendCommandAsync(connectMeteringPointRequest, CancellationToken.None).ConfigureAwait(false);

            AssertOutboxMessage<MeteringPointConnectedIntegrationEvent>();
        }

        [Fact]
        public async Task ConnectMeteringPoint_WithValidationErrors_ShouldGenerateRejectMessageInOutbox()
        {
            var createMeteringPointRequest = CreateMeteringPointRequest();

            var connectMeteringPointRequest = CreateConnectMeteringPointRequest() with
            {
                GsrnNumber = "This is not a valid GSRN number",
            };

            await SendCommandAsync(createMeteringPointRequest, CancellationToken.None).ConfigureAwait(false);
            await SendCommandAsync(connectMeteringPointRequest, CancellationToken.None).ConfigureAwait(false);

            AssertOutboxMessage<PostOfficeEnvelope>(envelope => envelope.MessageType == typeof(ConnectMeteringPointRejected).FullName!);
        }

        [Fact]
        public async Task ConnectMeteringPoint_WithNotExistingMetering_ShouldGenerateRejectMessageInOutbox()
        {
            var connectMeteringPointRequest = CreateConnectMeteringPointRequest();

            await SendCommandAsync(connectMeteringPointRequest, CancellationToken.None).ConfigureAwait(false);

            AssertOutboxMessage<PostOfficeEnvelope>(envelope => envelope.MessageType == typeof(ConnectMeteringPointRejected).FullName!);
        }

        [Fact]
        public async Task ConnectMeteringPoint_WithAlreadyConnected_ShouldGenerateRejectMessageInOutbox()
        {
            var createMeteringPointRequest = CreateMeteringPointRequest();

            var connectMeteringPointRequest = CreateConnectMeteringPointRequest();

            await SendCommandAsync(createMeteringPointRequest, CancellationToken.None).ConfigureAwait(false);
            await MarkAsEnergySupplierAssigned(connectMeteringPointRequest.EffectiveDate.ToInstant()).ConfigureAwait(false);
            await SendCommandAsync(connectMeteringPointRequest, CancellationToken.None).ConfigureAwait(false);
            await SendCommandAsync(connectMeteringPointRequest, CancellationToken.None).ConfigureAwait(false);

            AssertOutboxMessage<PostOfficeEnvelope>(envelope => envelope.MessageType == typeof(ConnectMeteringPointRejected).FullName!);
        }

        [Fact(Skip = "Not implemented yet")]
        public void ConnectMeteringPoint_WhenEffectiveDateIsOutOfScope_ShouldGenerateRejectMessageInOutbox()
        {
        }

        private static CreateMeteringPoint CreateMeteringPointRequest()
        {
            return new(
                SampleData.StreetName,
                SampleData.BuildingNumber,
                SampleData.PostCode,
                SampleData.CityName,
                SampleData.CitySubDivisionName,
                SampleData.MunicipalityCode,
                SampleData.CountryCode,
                SampleData.StreetCode,
                SampleData.FloorIdentification,
                SampleData.RoomIdentification,
                SampleData.IsWashable,
                SampleData.GsrnNumber,
                SampleData.TypeOfMeteringPoint,
                SampleData.SubTypeOfMeteringPoint,
                SampleData.ReadingOccurrence,
                0,
                0,
                SampleData.MeteringGridArea,
                SampleData.PowerPlantGsrnNumber,
                string.Empty,
                SampleData.SettlementMethod,
                SampleData.MeasurementUnitType,
                SampleData.DisconnectionType,
                SampleData.EffectiveDate,
                SampleData.MeterNumber,
                SampleData.Transaction,
                SampleData.PhysicalState,
                SampleData.NetSettlementGroup,
                SampleData.ConnectionType,
                SampleData.AssetType,
                null,
                ToGrid: null,
                ParentRelatedMeteringPoint: null,
                SampleData.ProductType,
                null,
                SampleData.GeoInfoReference,
                SampleData.MeasurementUnitType);
        }

        private ConnectMeteringPoint CreateConnectMeteringPointRequest()
        {
            var currentDate = _dateTimeProvider.Now().ToDateTimeUtc();
            var effectiveDate = Instant.FromUtc(currentDate.Year, currentDate.Month, currentDate.Day, 22, 0);
            return new(SampleData.GsrnNumber, effectiveDate.ToString(), SampleData.Transaction);
        }

        private async Task MarkAsEnergySupplierAssigned(Instant startOfSupply)
        {
            var setEnergySupplierAssigned = new SetEnergySupplierInfo(SampleData.GsrnNumber, startOfSupply);
            await SendCommandAsync(setEnergySupplierAssigned).ConfigureAwait(false);
        }
    }
}

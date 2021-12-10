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
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Energinet.DataHub.MeteringPoints.Application.Common;
using Energinet.DataHub.MeteringPoints.Application.GridAreas;
using Energinet.DataHub.MeteringPoints.Application.Queries;
using Energinet.DataHub.MeteringPoints.Application.Validation.Rules;
using Energinet.DataHub.MeteringPoints.Domain.Addresses;
using Energinet.DataHub.MeteringPoints.Domain.GridAreas;
using Energinet.DataHub.MeteringPoints.Domain.MasterDataHandling;
using Energinet.DataHub.MeteringPoints.Domain.MeteringDetails;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;
using MediatR;

namespace Energinet.DataHub.MeteringPoints.Application.Create.Consumption
{
    public class CreateConsumptionMeteringPointHandler : IBusinessRequestHandler<CreateConsumptionMeteringPoint>
    {
        private readonly IMeteringPointRepository _meteringPointRepository;
        private readonly IGridAreaRepository _gridAreaRepository;
        private readonly IMediator _mediator;

        public CreateConsumptionMeteringPointHandler(
            IMeteringPointRepository meteringPointRepository,
            IGridAreaRepository gridAreaRepository,
            IMediator mediator)
        {
            _meteringPointRepository = meteringPointRepository ?? throw new ArgumentNullException(nameof(meteringPointRepository));
            _gridAreaRepository = gridAreaRepository;
            _mediator = mediator;
        }

        public async Task<BusinessProcessResult> Handle(CreateConsumptionMeteringPoint request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var validationResult = await ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!validationResult.Success)
            {
                return validationResult;
            }

            var gridArea = await GetGridAreaAsync(request).ConfigureAwait(false);
            var gridAreaValidationResult = ValidateGridArea(request, gridArea);
            if (!gridAreaValidationResult.Success)
            {
                return new BusinessProcessResult(request.TransactionId, gridAreaValidationResult.ValidationErrors);
            }

            var meteringPointType = EnumerationType.FromName<MeteringPointType>(request.MeteringPointType);
            var masterDataBuilder =
                new MasterDataBuilder(
                    new MasterDataFieldSelector().GetMasterDataFieldsFor(meteringPointType));

            masterDataBuilder
                .WithAssetType(request.AssetType)
                .WithConnectionType(request.ConnectionType)
                .WithDisconnectionType(request.DisconnectionType)
                .EffectiveOn(request.EffectiveDate)
                .WithMeteringConfiguration(request.MeteringMethod, request.MeterNumber)
                .WithSettlementMethod(request.SettlementMethod)
                .WithNetSettlementGroup(request.NetSettlementGroup!)
                .WithScheduledMeterReadingDate(request.ScheduledMeterReadingDate!)
                .WithReadingPeriodicity(request.MeterReadingOccurrence)
                .WithPowerLimit(request.MaximumPower, request.MaximumCurrent)
                .WithPowerPlant(request.PowerPlant)
                .WithCapacity(string.IsNullOrWhiteSpace(request.PhysicalConnectionCapacity) ? null : double.Parse(request.PhysicalConnectionCapacity, NumberStyles.Number, new NumberFormatInfo()))
                .WithAddress(
                    request.StreetName,
                    request.StreetCode,
                    request.BuildingNumber,
                    request.CityName,
                    request.CitySubDivisionName,
                    request.PostCode,
                    EnumerationType.FromName<CountryCode>(request.CountryCode),
                    request.FloorIdentification,
                    request.RoomIdentification,
                    string.IsNullOrWhiteSpace(request.MunicipalityCode) ? default : int.Parse(request.MunicipalityCode, NumberStyles.Integer, new NumberFormatInfo()),
                    request.IsActualAddress,
                    string.IsNullOrWhiteSpace(request.GeoInfoReference) ? default : Guid.Parse(request.GeoInfoReference),
                    request.LocationDescription);

            var masterDataValidationResult = masterDataBuilder.Validate();
            if (masterDataValidationResult.Success == false)
            {
                return new BusinessProcessResult(request.TransactionId, masterDataValidationResult.Errors);
            }

            var masterData = masterDataBuilder.Build();

            var creationValidationResult = MeteringPoint.CanCreate(meteringPointType, masterData, new MasterDataValidator());
            if (creationValidationResult.Success == false)
            {
                return new BusinessProcessResult(request.TransactionId, creationValidationResult.Errors);
            }

            if (gridArea is null)
            {
                throw new BusinessOperationException("Grid area is required in order to create metering points.");
            }

            _meteringPointRepository.Add(
                MeteringPoint.Create(
                    MeteringPointId.New(),
                    GsrnNumber.Create(request.GsrnNumber),
                    meteringPointType,
                    gridArea.DefaultLink.Id,
                    EffectiveDate.Create(request.EffectiveDate),
                    masterData)!);

            return BusinessProcessResult.Ok(request.TransactionId);
        }

        private static BusinessProcessResult ValidateGridArea(CreateConsumptionMeteringPoint request, GridArea? gridArea)
        {
            var validationRules = new List<IBusinessRule>
            {
                new GridAreaMustExistRule(gridArea),
            };

            return new BusinessProcessResult(request.TransactionId, validationRules);
        }

        private Task<GridArea?> GetGridAreaAsync(CreateConsumptionMeteringPoint request)
        {
            return _gridAreaRepository.GetByCodeAsync(request.MeteringGridArea);
        }

        private async Task<BusinessProcessResult> ValidateAsync(CreateConsumptionMeteringPoint request, CancellationToken cancellationToken)
        {
            var gsrnNumberExists = await _mediator.Send(new MeteringPointGsrnExistsQuery(request.GsrnNumber), cancellationToken).ConfigureAwait(false);

            var validationRules = new List<IBusinessRule>
            {
                new MeteringPointGsrnMustBeUniqueRule(gsrnNumberExists, request.GsrnNumber),
            };

            return new BusinessProcessResult(request.TransactionId, validationRules);
        }
    }
}

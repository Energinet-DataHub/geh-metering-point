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

using Energinet.DataHub.MeteringPoints.Application.Create;
using Energinet.DataHub.MeteringPoints.Application.Validation.ValidationErrors;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints;
using FluentValidation;

namespace Energinet.DataHub.MeteringPoints.Application.Validation.Rules
{
    public class MeterReadingOccurenceRule : AbstractValidator<CreateConsumptionMeteringPoint>
    {
        public MeterReadingOccurenceRule()
        {
            RuleFor(request => request.MeterReadingOccurrence)
                .NotEmpty()
                .WithState(createMeteringPoint => new MeterReadingOccurenceMandatoryValidationError(createMeteringPoint.GsrnNumber, createMeteringPoint.TypeOfMeteringPoint));

            When(createMeteringPoint => createMeteringPoint.TypeOfMeteringPoint == MeteringPointType.SurplusProductionGroup.Name || createMeteringPoint.TypeOfMeteringPoint == MeteringPointType.NetConsumption.Name, () =>
            {
                RuleFor(request => request.MeterReadingOccurrence)
                    .Must(meterReadingOccurrence => meterReadingOccurrence == ReadingOccurrence.Hourly.Name)
                    .WithState(createMeteringPoint => new MeterReadingOccurenceInvalidValueValidationError(createMeteringPoint.GsrnNumber, createMeteringPoint.ProductType, ReadingOccurrence.Hourly.Name));
            });

            When(createMeteringPoint => createMeteringPoint.TypeOfMeteringPoint == MeteringPointType.VEProduction.Name || createMeteringPoint.TypeOfMeteringPoint == MeteringPointType.Analysis.Name, () =>
            {
                RuleFor(request => request.MeterReadingOccurrence)
                    .Must(meterReadingOccurrence => meterReadingOccurrence == ReadingOccurrence.Hourly.Name || meterReadingOccurrence == ReadingOccurrence.Quarterly.Name || meterReadingOccurrence == ReadingOccurrence.Monthly.Name)
                    .WithState(createMeteringPoint => new MeterReadingOccurenceInvalidValueValidationError(createMeteringPoint.GsrnNumber, createMeteringPoint.ProductType, ReadingOccurrence.Hourly.Name, ReadingOccurrence.Quarterly.Name, ReadingOccurrence.Monthly.Name));
            }).Otherwise(() =>
            {
                RuleFor(request => request.MeterReadingOccurrence)
                    .Must(meterReadingOccurrence => meterReadingOccurrence == ReadingOccurrence.Hourly.Name || meterReadingOccurrence == ReadingOccurrence.Quarterly.Name)
                    .WithState(createMeteringPoint => new MeterReadingOccurenceInvalidValueValidationError(createMeteringPoint.GsrnNumber, createMeteringPoint.ProductType, ReadingOccurrence.Hourly.Name, ReadingOccurrence.Quarterly.Name));
            });
        }
    }
}

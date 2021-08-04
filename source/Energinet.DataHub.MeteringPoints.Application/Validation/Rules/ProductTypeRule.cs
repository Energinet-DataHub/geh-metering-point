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
using System.Linq;
using Energinet.DataHub.MeteringPoints.Application.Validation.ValidationErrors;
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;
using FluentValidation;

namespace Energinet.DataHub.MeteringPoints.Application.Validation.Rules
{
    public class ProductTypeRule : AbstractValidator<CreateMeteringPoint>
    {
        public ProductTypeRule()
        {
            RuleFor(request => request.ProductType)
                .NotEmpty()
                .WithState(createMeteringPoint => new ProductTypeMandatoryValidationError(createMeteringPoint.GsrnNumber));

            RuleFor(request => request.ProductType)
                .Must(productType => AllowedProductTypeValues().Contains(productType.ToUpperInvariant()))
                .WithState(createMeteringPoint => new ProductTypeInvalidValueValidationError(createMeteringPoint.GsrnNumber, createMeteringPoint.ProductType));

            When(IsMeteringPointTypeWithDefaultProductType, () =>
            {
                RuleFor(request => request.ProductType)
                    .Must(productType => string.Equals(productType, ProductType.EnergyActive.Name, StringComparison.OrdinalIgnoreCase))
                    .WithState(createMeteringPoint => new ProductTypeWrongDefaultValueValidationError(createMeteringPoint.GsrnNumber, createMeteringPoint.ProductType));
            });
        }

        private static bool IsMeteringPointTypeWithDefaultProductType(CreateMeteringPoint createMeteringPoint)
        {
            var includedMeteringPointTypes = new HashSet<string>
            {
                MeteringPointType.Analysis.Name.ToUpperInvariant(),
                MeteringPointType.VEProduction.Name.ToUpperInvariant(),
                MeteringPointType.ExchangeReactiveEnergy.Name.ToUpperInvariant(),
                MeteringPointType.InternalUse.Name.ToUpperInvariant(),
            };

            return !includedMeteringPointTypes.Contains(createMeteringPoint.TypeOfMeteringPoint.ToUpperInvariant());
        }

        private static HashSet<string> AllowedProductTypeValues()
        {
            return EnumerationType.GetAll<ProductType>().Select(x => x.Name.ToUpperInvariant()).ToHashSet();
        }
    }
}

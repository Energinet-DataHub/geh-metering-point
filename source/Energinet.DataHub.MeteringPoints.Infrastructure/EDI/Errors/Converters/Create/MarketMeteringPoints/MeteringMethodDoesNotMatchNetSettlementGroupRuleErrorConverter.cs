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
using Energinet.DataHub.MeteringPoints.Domain.MeteringPoints.MarketMeteringPoints.Rules;

namespace Energinet.DataHub.MeteringPoints.Infrastructure.EDI.Errors.Converters.Create.MarketMeteringPoints
{
    public class MeteringMethodDoesNotMatchNetSettlementGroupRuleErrorConverter : ErrorConverter<MeteringMethodDoesNotMatchNetSettlementGroupRuleError>
    {
        protected override ErrorMessage Convert(MeteringMethodDoesNotMatchNetSettlementGroupRuleError validationError)
        {
            if (validationError == null) throw new ArgumentNullException(nameof(validationError));

            return new("D37", $"Metering method {validationError.MeteringMethod.Name} not allowed: the metering method for this type of metering point must be Virtual (D02) or Calculated (D03) if net settlement group is not 0 or 99.");
        }
    }
}
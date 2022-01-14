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
using Energinet.DataHub.MeteringPoints.Application.EDI;
using Energinet.DataHub.MeteringPoints.Application.Validation.ValidationErrors;
using Energinet.DataHub.MeteringPoints.Domain.MasterDataHandling.Rules;

namespace Energinet.DataHub.MeteringPoints.Infrastructure.EDI.Errors.Converters
{
    public class AssetTypeIsRequiredRuleErrorConverter : ErrorConverter<AssetTypeIsRequired>
    {
        protected override ErrorMessage Convert(AssetTypeIsRequired validationError)
        {
            if (validationError == null) throw new ArgumentNullException(nameof(validationError));

            return new("D59", $"AssetType is missing. It must be applied for Production (E18) and Consumption (E17) in net settlement groups other than 0.");
        }
    }
}

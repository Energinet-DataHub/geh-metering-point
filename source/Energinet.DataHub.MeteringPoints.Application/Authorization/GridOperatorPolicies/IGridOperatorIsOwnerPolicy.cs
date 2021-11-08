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

namespace Energinet.DataHub.MeteringPoints.Application.Authorization.GridOperatorPolicies
{
    /// <summary>
    /// Verfiy if current user is the owner (Grid operator) of the metering point with the specified GSRN-number.
    /// </summary>
    public interface IGridOperatorIsOwnerPolicy
    {
        /// <summary>
        /// Run authorization logic
        /// </summary>
        /// <param name="gsrnNumber"></param>
        /// <returns><see cref="AuthorizationResult"/></returns>
        Task<AuthorizationResult> AuthorizeAsync(string gsrnNumber);
    }
}
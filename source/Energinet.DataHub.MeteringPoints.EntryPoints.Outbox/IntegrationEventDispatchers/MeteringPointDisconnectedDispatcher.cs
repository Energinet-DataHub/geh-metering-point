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

using System.Threading;
using System.Threading.Tasks;
using Energinet.DataHub.MeteringPoints.Infrastructure.Integration.IntegrationEvents.Disconnect;
using MediatR;

namespace Energinet.DataHub.MeteringPoints.EntryPoints.Outbox.IntegrationEventDispatchers
{
    public class MeteringPointDisconnectedDispatcher : IRequestHandler<MeteringPointDisconnectedIntegrationEvent>
    {
        public Task<Unit> Handle(MeteringPointDisconnectedIntegrationEvent request, CancellationToken cancellationToken)
        {
            // TODO: Implement correct handler when Infrastructure is done
            return Task.FromResult(Unit.Value);
        }
    }
}

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
using System.Threading;
using System.Threading.Tasks;
using Energinet.DataHub.MeteringPoints.Infrastructure.EDI;
using Energinet.DataHub.MeteringPoints.Infrastructure.SubPostOffice;
using MediatR;

namespace Energinet.DataHub.MeteringPoints.EntryPoints.Outbox.ActorMessages
{
    public class PostOfficeDispatcher : IRequestHandler<PostOfficeMessageEnvelope>
    {
        private readonly ISubPostOfficeClient _subPostOfficeClient;

        public PostOfficeDispatcher(ISubPostOfficeClient subPostOfficeClient)
        {
            _subPostOfficeClient = subPostOfficeClient;
        }

        public async Task<Unit> Handle(PostOfficeMessageEnvelope request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            await _subPostOfficeClient.DispatchAsync(request).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}

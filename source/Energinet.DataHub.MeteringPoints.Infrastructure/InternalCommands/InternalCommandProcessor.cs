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
using System.Threading.Tasks;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;
using Energinet.DataHub.MeteringPoints.Infrastructure.Serialization;
using MediatR;

namespace Energinet.DataHub.MeteringPoints.Infrastructure.InternalCommands
{
    public class InternalCommandProcessor
    {
        private readonly InternalCommandAccessor _internalCommandAccessor;
        private readonly ISystemDateTimeProvider _systemDateTimeProvider;
        private readonly IJsonSerializer _serializer;
        private readonly IMediator _mediator;

        public InternalCommandProcessor(InternalCommandAccessor internalCommandAccessor, ISystemDateTimeProvider systemDateTimeProvider, IJsonSerializer serializer, IMediator mediator)
        {
            _internalCommandAccessor = internalCommandAccessor ?? throw new ArgumentNullException(nameof(internalCommandAccessor));
            _systemDateTimeProvider = systemDateTimeProvider ?? throw new ArgumentNullException(nameof(systemDateTimeProvider));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task ProcessPendingAsync()
        {
            var pendingCommands = await _internalCommandAccessor.GetPendingAsync(_systemDateTimeProvider.Now()).ConfigureAwait(false);

            foreach (var queuedCommand in pendingCommands)
            {
                queuedCommand.SetProcessed(_systemDateTimeProvider.Now());
                var command = _serializer.Deserialize(queuedCommand.Data, Type.GetType(queuedCommand.Type, true)!);
                await _mediator.Send(command).ConfigureAwait(false);
            }
        }
    }
}

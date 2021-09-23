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
using Energinet.DataHub.MeteringPoints.Infrastructure.Integration.Helpers;
using Energinet.DataHub.MeteringPoints.Infrastructure.Outbox;
using Energinet.DataHub.MeteringPoints.Infrastructure.Serialization;
using MediatR;

namespace Energinet.DataHub.MeteringPoints.EntryPoints.Outbox.Common
{
    public class OutboxMessageDispatcher : IOutboxMessageDispatcher
    {
        private readonly IMediator _mediator;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IIntegrationMetaDataContext _integrationMetaDataContext;

        public OutboxMessageDispatcher(
            IMediator mediator,
            IJsonSerializer jsonSerializer,
            IIntegrationMetaDataContext integrationMetaDataContext)
        {
            _mediator = mediator;
            _jsonSerializer = jsonSerializer;
            _integrationMetaDataContext = integrationMetaDataContext;
        }

        public async Task DispatchMessageAsync(OutboxMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            object parsedCommand = _jsonSerializer.Deserialize(
                message.Data,
                OutboxTypeFactory.GetType(message.Type));

            _integrationMetaDataContext.SetInitialMetaData(message.CreationDate, message.Correlation, Guid.NewGuid());
            await _mediator.Send(parsedCommand, CancellationToken.None).ConfigureAwait(false);
        }
    }
}

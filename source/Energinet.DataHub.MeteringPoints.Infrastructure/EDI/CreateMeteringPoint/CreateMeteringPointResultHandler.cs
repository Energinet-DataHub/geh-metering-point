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
using System.Linq;
using System.Threading.Tasks;
using Energinet.DataHub.MeteringPoints.Application.Common;
using Energinet.DataHub.MeteringPoints.Infrastructure.BusinessRequestProcessing;
using Energinet.DataHub.MeteringPoints.Infrastructure.Correlation;
using Energinet.DataHub.MeteringPoints.Infrastructure.EDI.Errors;
using Energinet.DataHub.MeteringPoints.Infrastructure.Helpers;
using Energinet.DataHub.MeteringPoints.Infrastructure.Outbox;

namespace Energinet.DataHub.MeteringPoints.Infrastructure.EDI.CreateMeteringPoint
{
    public class CreateMeteringPointResultHandler : IBusinessProcessResultHandler<Application.Create.CreateMeteringPoint>
    {
        private readonly ErrorMessageFactory _errorMessageFactory;
        private readonly IOutbox _outbox;
        private readonly IOutboxMessageFactory _outboxMessageFactory;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly ICorrelationContext _correlationContext;

        public CreateMeteringPointResultHandler(
            ErrorMessageFactory errorMessageFactory,
            IOutbox outbox,
            IOutboxMessageFactory outboxMessageFactory,
            IJsonSerializer jsonSerializer,
            ICorrelationContext correlationContext)
        {
            _errorMessageFactory = errorMessageFactory;
            _outbox = outbox;
            _outboxMessageFactory = outboxMessageFactory;
            _jsonSerializer = jsonSerializer;
            _correlationContext = correlationContext;
        }

        public Task HandleAsync(Application.Create.CreateMeteringPoint request, BusinessProcessResult result)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (result == null) throw new ArgumentNullException(nameof(result));

            return result.Success
                ? CreateAcceptResponseAsync(request, result)
                : CreateRejectResponseAsync(request, result);
        }

        private Task CreateAcceptResponseAsync(Application.Create.CreateMeteringPoint request, BusinessProcessResult result)
        {
            var ediMessage = new CreateMeteringPointAccepted(
                TransactionId: result.TransactionId,
                GsrnNumber: request.GsrnNumber,
                Status: "Accepted");
            var envelope = new PostOfficeEnvelope(string.Empty, string.Empty, _jsonSerializer.Serialize(ediMessage), "Accepted", _correlationContext.AsTraceContext());
            AddToOutbox(envelope);

            return Task.CompletedTask;
        }

        private Task CreateRejectResponseAsync(Application.Create.CreateMeteringPoint request, BusinessProcessResult result)
        {
            var errors = result.ValidationErrors
                .Select(error => _errorMessageFactory.GetErrorMessage(error))
                .ToArray();

            var ediMessage = new CreateMeteringPointRejected(
                TransactionId: result.TransactionId,
                GsrnNumber: request.GsrnNumber,
                Status: "Rejected", // TODO: Is this necessary? Also, Reason?
                Reason: "TODO",
                Errors: errors);
            var envelope = new PostOfficeEnvelope(string.Empty, string.Empty, _jsonSerializer.Serialize(ediMessage), "Rejected", _correlationContext.AsTraceContext());

            AddToOutbox(envelope);

            return Task.CompletedTask;
        }

        private void AddToOutbox<TEdiMessage>(TEdiMessage ediMessage)
        {
            var outboxMessage = _outboxMessageFactory.CreateFrom(ediMessage, OutboxMessageCategory.ActorMessage);
            _outbox.Add(outboxMessage);
        }
    }
}

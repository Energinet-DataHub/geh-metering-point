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
using Energinet.DataHub.MeteringPoints.Application.Common;
using MediatR;

namespace Energinet.DataHub.MeteringPoints.Infrastructure.BusinessRequestProcessing.Pipeline
{
    public class BusinessProcessResultBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBusinessRequest, MediatR.IRequest<TResponse>
        where TResponse : BusinessProcessResult
    {
        private readonly IBusinessProcessResultHandler<TRequest> _resultHandler;

        public BusinessProcessResultBehavior(
            IBusinessProcessResultHandler<TRequest> resultHandler)
        {
            _resultHandler = resultHandler;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (next == null) throw new ArgumentNullException(nameof(next));

            var result = await next().ConfigureAwait(false);

            await _resultHandler.HandleAsync(request, result).ConfigureAwait(false);

            return result;
        }
    }
}

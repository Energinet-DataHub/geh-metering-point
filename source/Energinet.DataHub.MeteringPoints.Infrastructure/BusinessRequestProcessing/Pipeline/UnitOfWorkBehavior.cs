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
using Energinet.DataHub.MeteringPoints.Application.Common.Commands;
using Energinet.DataHub.MeteringPoints.Domain.SeedWork;
using Energinet.DataHub.MeteringPoints.Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Energinet.DataHub.MeteringPoints.Infrastructure.BusinessRequestProcessing.Pipeline
{
    public class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MeteringPointContext _context;
        private readonly ISystemDateTimeProvider _systemDateTimeProvider;

        public UnitOfWorkBehavior(IUnitOfWork unitOfWork, MeteringPointContext context, ISystemDateTimeProvider systemDateTimeProvider)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _systemDateTimeProvider = systemDateTimeProvider;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (next == null) throw new ArgumentNullException(nameof(next));

            // Call next handler in the pipeline and wait for the result
            var result = await next().ConfigureAwait(false);

            await MarkAsProcessedIfInternalCommandAsync(request, cancellationToken).ConfigureAwait(false);

            await _unitOfWork.CommitAsync().ConfigureAwait(false);

            return result;
        }

        private async Task MarkAsProcessedIfInternalCommandAsync(TRequest request, CancellationToken cancellationToken)
        {
            if (request is InternalCommand internalCommand)
            {
                var queuedCommand =
                    await _context.QueuedInternalCommands
                        .FirstOrDefaultAsync(command => command.Id.Equals(internalCommand.Id), cancellationToken)
                        .ConfigureAwait(false);
                queuedCommand?.SetProcessed(_systemDateTimeProvider.Now());
            }
        }
    }
}

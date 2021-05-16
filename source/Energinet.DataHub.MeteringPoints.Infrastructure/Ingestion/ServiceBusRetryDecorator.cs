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

using System.Threading;
using System.Threading.Tasks;
using Energinet.DataHub.MeteringPoints.Application.Transport;
using Polly;

namespace Energinet.DataHub.MeteringPoints.Infrastructure.Ingestion
{
    public class ServiceBusRetryDecorator : Channel
    {
        private readonly InternalServiceBus _internalServiceBus;
        private readonly IAsyncPolicy _retryPolicy;

        public ServiceBusRetryDecorator(InternalServiceBus internalServiceBus, IAsyncPolicy retryPolicy)
        {
            _internalServiceBus = internalServiceBus;
            _retryPolicy = retryPolicy;
        }

        public override async Task WriteAsync(byte[] data, CancellationToken cancellationToken = default)
        {
            await _retryPolicy.ExecuteAsync(async () =>
            {
                await _internalServiceBus.WriteAsync(data, cancellationToken);
            });
        }
    }
}
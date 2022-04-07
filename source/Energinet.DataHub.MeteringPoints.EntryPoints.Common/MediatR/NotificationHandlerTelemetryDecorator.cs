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
using MediatR;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Extensions.Logging;

namespace Energinet.DataHub.MeteringPoints.EntryPoints.Common.MediatR
{
    public class NotificationHandlerTelemetryDecorator<TNotification> : INotificationHandler<TNotification>
        where TNotification : INotification
    {
        private readonly INotificationHandler<TNotification> _decoratedHandler;
        private readonly TelemetryClient _telemetryClient;
        private readonly ILogger _logger;

        public NotificationHandlerTelemetryDecorator(
            INotificationHandler<TNotification> decoratedHandler,
            TelemetryClient telemetryClient,
            ILogger logger)
        {
            _decoratedHandler = decoratedHandler;
            _telemetryClient = telemetryClient;
            _logger = logger;
        }

        public async Task Handle(TNotification notification, CancellationToken cancellationToken)
        {
            var operationName = notification.GetType().Name;
            _logger.LogInformation("Handle {Notification}", operationName);

            var operation = _telemetryClient.StartOperation<DependencyTelemetry>(operationName);
            operation.Telemetry.Type = "Handler";
            try
            {
                await _decoratedHandler.Handle(notification, cancellationToken).ConfigureAwait(false);
                operation.Telemetry.Success = true;
            }
            catch (Exception exception)
            {
                operation.Telemetry.Success = false;
                _telemetryClient.TrackException(exception);
                throw;
            }
            finally
            {
                _telemetryClient.StopOperation(operation);
            }
        }
    }
}

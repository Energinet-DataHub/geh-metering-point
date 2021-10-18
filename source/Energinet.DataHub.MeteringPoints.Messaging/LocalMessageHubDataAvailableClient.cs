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
using Energinet.DataHub.MessageHub.Client.DataAvailable;
using Energinet.DataHub.MessageHub.Client.Model;
using Energinet.DataHub.MeteringPoints.Infrastructure.EDI;
using Energinet.DataHub.MeteringPoints.Infrastructure.LocalMessageHub;

namespace Energinet.DataHub.MeteringPoints.Messaging
{
    public class LocalMessageHubDataAvailableClient : ILocalMessageHubDataAvailableClient
    {
        private readonly IDataAvailableNotificationSender _dataAvailableNotificationSender;
        private readonly MessageHubMessageFactory _messageHubMessageFactory;
        private readonly IMessageHubMessageRepository _messageHubMessageRepository;

        public LocalMessageHubDataAvailableClient(
            IMessageHubMessageRepository messageHubMessageRepository,
            IDataAvailableNotificationSender dataAvailableNotificationSender,
            MessageHubMessageFactory messageHubMessageFactory)
        {
            _messageHubMessageRepository = messageHubMessageRepository;
            _dataAvailableNotificationSender = dataAvailableNotificationSender;
            _messageHubMessageFactory = messageHubMessageFactory;
        }

        public async Task DataAvailableAsync(MessageHubEnvelope messageHub)
        {
            if (messageHub is null)
            {
                throw new ArgumentNullException(nameof(messageHub));
            }

            var messageMetadata = _messageHubMessageFactory.Create(messageHub.Correlation, messageHub.Content, messageHub.MessageType, messageHub.Recipient);
            _messageHubMessageRepository.AddMessageMetadata(messageMetadata);

            // TODO - add notification to Outbox instead of sending immediately
            await _dataAvailableNotificationSender.SendAsync(new DataAvailableNotificationDto(messageMetadata.Id, new GlobalLocationNumberDto(messageHub.Recipient), new MessageTypeDto(messageHub.MessageType.Name), DomainOrigin.MeteringPoints, true, 1)).ConfigureAwait(false);
        }
    }
}

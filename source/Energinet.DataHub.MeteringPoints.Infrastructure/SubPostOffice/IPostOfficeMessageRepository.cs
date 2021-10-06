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

namespace Energinet.DataHub.MeteringPoints.Infrastructure.SubPostOffice
{
    /// <summary>
    /// Repository for market facing metering points
    /// </summary>
    public interface IPostOfficeMessageMetadataRepository
    {
        /// <summary>
        /// Fetch Post Office Message Metadata by id
        /// </summary>
        Task<PostOfficeMessage> GetMessageAsync(Guid messageId);

        /// <summary>
        /// Fetch Post Office Message Metadata by id
        /// </summary>
        Task<PostOfficeMessage[]> GetMessagesAsync(Guid[] messageIds);

        /// <summary>
        /// Save Post Office Message Metadata
        /// </summary>
        void AddMessageMetadata(PostOfficeMessage postOfficeMessage);
    }
}

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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Energinet.DataHub.Core.App.Common.Abstractions.Users;
using Energinet.DataHub.MeteringPoints.Client.Abstractions.Models;
using Energinet.DataHub.MeteringPoints.Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Energinet.DataHub.MeteringPoints.EntryPoints.WebApi.MeteringPoints.Queries
{
    public class
        MeteringPointProcessesByGsrnQueryHandler : IRequestHandler<MeteringPointProcessesByGsrnQuery, List<Process>>
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly IUserContext _userContext;
        private readonly MeteringPointContext _dbContext;

        public MeteringPointProcessesByGsrnQueryHandler(
            IDbConnectionFactory connectionFactory,
            IUserContext userContext,
            MeteringPointContext dbContext)
        {
            _connectionFactory = connectionFactory;
            _userContext = userContext;
            _dbContext = dbContext;
        }

        public Task<List<Process>> Handle(
            MeteringPointProcessesByGsrnQuery request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            // TODO: Include filtration on user/actor
            var result = _dbContext.Processes
                .Include(p => p.Details.OrderBy(d => d.CreatedDate))
                .Where(p => p.MeteringPointGsrn == request.GsrnNumber)
                .OrderByDescending(p => p.CreatedDate);

            return Task.FromResult(result.ToList());
        }
    }
}

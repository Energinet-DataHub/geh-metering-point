// Copyright 2020 Energinet DataHub A/S
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

using System.Linq;
using System.Threading.Tasks;
using Energinet.DataHub.MeteringPoints.Application.EDI;
using Energinet.DataHub.MeteringPoints.EntryPoints.WebApi.GridAreas.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Energinet.DataHub.MeteringPoints.EntryPoints.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridAreaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GridAreaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateGridArea createGridArea)
        {
            var result = await _mediator.Send(createGridArea).ConfigureAwait(false);

            var errors = result.ValidationErrors
                .Select(error => ErrorMessageFactory.GetErrorMessage(error))
                .ToArray();

            return Ok(new
            {
                Errors = errors,
                result.Success,
            });
        }
    }
}

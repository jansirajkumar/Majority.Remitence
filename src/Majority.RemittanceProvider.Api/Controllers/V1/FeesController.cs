using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Majority.RemittanceProvider.Api.Controllers.V1
{
    [Route("api/v1/fees")]
    [ApiController]
    public class FeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Returns the fees and available modes of transfer for selected destination
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        [HttpGet("get-fees-list")]
        public async Task<FeesDto> GetFees([FromQuery] string to, string from) => await _mediator.Send(new GetFeesQuery(from, to));
    }
}

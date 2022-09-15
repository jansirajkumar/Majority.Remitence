using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Majority.RemittanceProvider.Api.Controllers.V1
{
    [Route("api/v1/bank/")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BeneficiaryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-beneficiary-name")]
        public async Task<BeneficiaryDto> GetBeneficiaryName([FromQuery] string accountNumber, string bankCode)
            => await _mediator.Send(new GetBeneficiaryNameQuery(accountNumber, bankCode));



    }
}

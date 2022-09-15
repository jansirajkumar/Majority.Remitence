using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Majority.RemittanceProvider.Api.Controllers.V1
{
    [Route("api/v1/bank/")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("get-beneficiary-name")]
        //public Task GetBeneficiaryName([FromQuery] string accountNumber, string bankCode)
        //{
        //    return Ok();
        //}

        [HttpGet("get-bank-list")]
        public async Task<List<BankDto>> GetBanks([FromQuery] string code) => await _mediator.Send(new GetBanksQuery(code));

    }
}


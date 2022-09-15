using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Majority.RemittanceProvider.Api.Controllers.V1
{
    [Route("api/v1/exchangeRate")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExchangeRateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns the exchange rate for the specified destination rounded to 3 decimal places.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [HttpGet("get-exchange-rates")]
        public async Task<List<ExchangeRateDto>> GetExchangeRates([FromQuery] string? to, string? from)
        {
            return await _mediator.Send(new GetExchangeRatesQuery(from, to));
        }
    }
}

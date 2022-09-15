using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Majority.RemittanceProvider.Api.Controllers.V1
{
    [Route("api/v1/country/")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns all the currently supported countries.
        /// </summary>
        [HttpGet("get-country-list")]

        public async Task<List<CountryDto>> GetCountries([FromQuery] GetCountriesQuery getCountriesQuery)
            => await _mediator.Send(getCountriesQuery);


        /// <summary>
        /// Returns all the states
        /// </summary>
        /// <param name="stateQuery"></param>
        /// <returns></returns>
        [HttpGet("{countryCode}/get-state-list")]
        public async Task<List<StateDto>> GetStates([FromRoute] string CountryCode) =>
            await _mediator.Send(new GetStatesQuery(CountryCode));
    }
}

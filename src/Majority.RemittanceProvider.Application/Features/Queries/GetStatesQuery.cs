using Majority.RemittanceProvider.Application.Features.Dtos;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries
{
    public class GetStatesQuery : IRequest<List<StateDto>>
    {
        public string CountryCode { get; set; }
        public GetStatesQuery(string countryCode)
        {
            CountryCode = countryCode;
        }
    }
}

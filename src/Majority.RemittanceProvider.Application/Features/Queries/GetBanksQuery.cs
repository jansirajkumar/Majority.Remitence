using Majority.RemittanceProvider.Application.Features.Dtos;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries
{
    public class GetBanksQuery : IRequest<List<BankDto>>
    {
        public string CountryCode { get; set; }
        public GetBanksQuery(string countryCode)
        {
            CountryCode = countryCode;
        }
    }
}

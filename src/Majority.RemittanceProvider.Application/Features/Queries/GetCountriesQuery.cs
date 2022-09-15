using Majority.RemittanceProvider.Application.Features.Dtos;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries
{
    public class GetCountriesQuery : IRequest<List<CountryDto>>
    {
    }
}

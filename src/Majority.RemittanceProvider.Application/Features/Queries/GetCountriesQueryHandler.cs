using AutoMapper;
using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries;

public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, List<CountryDto>>
{
    private readonly ICountryRepository _countryRespoitory;
    private readonly IMapper _mapper;
    public GetCountriesQueryHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRespoitory = countryRepository;
        _mapper = mapper;
    }
    public async Task<List<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var countries = await _countryRespoitory.GetSupportedCountries();
            if (countries?.Count > 0)
            {
                return _mapper.Map<List<CountryDto>>(countries);
            }
            throw new ArgumentException("No countries found");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}


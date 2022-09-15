namespace Majority.RemittanceProvider.Domain.RemittanceProvider;
public interface ICountryRepository
{
    Task<List<Country>> GetSupportedCountries(bool isActive = true);


}


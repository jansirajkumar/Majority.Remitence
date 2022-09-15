using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Microsoft.EntityFrameworkCore;
namespace Majority.RemittanceProvider.Infrastructure.Repositories;
public class CountryRepository : ICountryRepository
{
    private readonly RemittanceProviderContext _context;

    public CountryRepository(RemittanceProviderContext context)
    {
        _context = context;
    }

    public async Task<List<Country>> GetSupportedCountries(bool isActive = true)
    {

        return await _context.Countries
            .Where(x => x.IsActive == isActive)
             .ToListAsync();

    }
}


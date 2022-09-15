using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Microsoft.EntityFrameworkCore;
namespace Majority.RemittanceProvider.Infrastructure.Repositories;

public class ExchangeRateRepository : IExchangeRateRepository
{
    private readonly RemittanceProviderContext _context;

    public ExchangeRateRepository(RemittanceProviderContext context)
    {
        _context = context;
    }
    public async Task<List<ExchangeRate>> GetExchangeRate(List<string> currencyCodes)
    {
        return await _context.ExchangeRates
                  .Where(x => x.IsActive == true && currencyCodes.Contains(x.DestinationCurrencyCode))
                  .ToListAsync();
    }
}


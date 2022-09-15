using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Microsoft.EntityFrameworkCore;

namespace Majority.RemittanceProvider.Infrastructure.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly RemittanceProviderContext _context;

        public BankRepository(RemittanceProviderContext context)
        {
            _context = context;
        }
        public async Task<List<Bank>> GetBankDetailsByCountryCode(string countryCode)
        {

            return await _context.Banks
                    .Where(x => x.CountryCode == countryCode)
                    .ToListAsync();
        }
    }
}

using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Microsoft.EntityFrameworkCore;

namespace Majority.RemittanceProvider.Infrastructure.Repositories
{
    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly RemittanceProviderContext _context;

        public BeneficiaryRepository(RemittanceProviderContext context)
        {
            _context = context;
        }
        public async Task<Beneficiary> GetBeneficiaryDetailsByBankCodeAndAccountNumber(string bankCode, string accountNumber)
        {
            return await _context.Beneficiaries
                         .Where(x => x.BankCode == bankCode && x.AccountNumber == accountNumber)
                         .FirstOrDefaultAsync();
        }
    }
}

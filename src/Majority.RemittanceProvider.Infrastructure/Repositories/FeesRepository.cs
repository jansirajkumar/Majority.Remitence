using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Microsoft.EntityFrameworkCore;

namespace Majority.RemittanceProvider.Infrastructure.Repositories
{
    public class FeesRepository : IFeesRepository
    {
        private readonly RemittanceProviderContext _context;
        public FeesRepository(RemittanceProviderContext context)
        {
            _context = context;
        }

        public async Task<List<FeesDetails>> GetFees(string sourceCountryCode, string destinationCountryCode)
        {
            return await _context.FeesDetails
                    .Where(x => x.IsAvailable == true && x.FromCountryCode == sourceCountryCode && x.ToCountryCode == destinationCountryCode)
                     .Include(x => x.TransferMode)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}

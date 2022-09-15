using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Microsoft.EntityFrameworkCore;

namespace Majority.RemittanceProvider.Infrastructure.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly RemittanceProviderContext _context;

        public StateRepository(RemittanceProviderContext context)
        {
            _context = context;
        }

        public async Task<List<State>> GetStates(string countryCode = "US")
        {
            return await _context.States.Where(x => x.CountryCode == countryCode).ToListAsync();
        }
    }
}

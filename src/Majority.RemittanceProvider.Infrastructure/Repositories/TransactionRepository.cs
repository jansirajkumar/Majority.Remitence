using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Microsoft.EntityFrameworkCore;

namespace Majority.RemittanceProvider.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly RemittanceProviderContext _context;

        public TransactionRepository(RemittanceProviderContext context)
        {
            _context = context;
        }

        public async Task AddTransaction(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.CommitAsync();
        }

        public async Task<Transaction?> GetTransaction(Guid transactionId)
        {
            return await _context.Transactions
                      .Where(x => x.TransactionId == transactionId).FirstOrDefaultAsync();
        }
    }
}

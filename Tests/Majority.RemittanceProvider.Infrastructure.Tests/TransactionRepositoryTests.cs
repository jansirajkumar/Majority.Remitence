using System;
using System.Linq;
using System.Threading.Tasks;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Majority.RemittanceProvider.Infrastructure.Repositories;
using Majority.RemittanceProvider.Infrastructure.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Majority.RemittanceProvider.Infrastructure.UnitTests.RepositoryTests
{
    public class TransactionRepositoryTests
    {
        private readonly RemittanceProviderContext _context;

        private readonly ITransactionRepository _transactionRepository;

        public TransactionRepositoryTests()
        {
            _context = DBHelper.GetRemittanceProviderContext();
            _transactionRepository = new TransactionRepository(_context);
        }

        [Fact]
        public async Task GetTransaction_WhenNoTransactionFound_ThenReturnEmpty()
        {
            // Arrange
            var transactionId = Guid.NewGuid();
            await _context.Transactions.AddAsync(TestDataHelper.Transaction(transactionId));
            await _context.SaveChangesAsync();

            // Act
            var result = await _transactionRepository.GetTransaction(Guid.NewGuid());

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetTransaction_WhenTransactionFound_ThenReturnTransaction()
        {
            // Arrange
            var transactionId = Guid.NewGuid();
            await _context.Transactions.AddAsync(TestDataHelper.Transaction(transactionId));
            await _context.SaveChangesAsync();

            // Act
            var result = await _transactionRepository.GetTransaction(transactionId);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddTransaction_WhenAllPropertiesAreValid_ThenSuccess()
        {
            // Arrange
            var transactionId = Guid.NewGuid();

            // Act
            await _transactionRepository.AddTransaction(TestDataHelper.Transaction(transactionId));
            var result = await _context.Transactions.Where(X => X.TransactionId == transactionId).FirstOrDefaultAsync();

            // Assert
            Assert.NotNull(result);
        }
    }
}

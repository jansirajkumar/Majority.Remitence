using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Majority.RemittanceProvider.Infrastructure.Repositories;
using Majority.RemittanceProvider.Infrastructure.Tests.Helpers;
using Majority.RemittanceProvider.Infrastructure.UnitTests.RepositoryTests;
using Xunit;

namespace Majority.RemittanceProvider.Infrastructure.Tests
{
    public class BankRepositoryTests
    {
        private readonly RemittanceProviderContext _context;

        private readonly IBankRepository _bankRepository;

        public BankRepositoryTests()
        {
            _context = DBHelper.GetRemittanceProviderContext();
            _bankRepository = new BankRepository(_context);
        }

        [Fact]
        public async Task GetBankDetailsByCountryCode_WhenBankAvailableForCountry_ThenReturnBankDetails()
        {
            // Arrange
            SetUpData();

            // Act
            var result = await _bankRepository.GetBankDetailsByCountryCode("US");

            // Assert
            result.Should().BeEquivalentTo(new List<Bank> { TestDataHelper.Bank });
        }

        [Fact]
        public async Task GetBankDetailsByCountryCode_WhenNoBankAvailableForCountry_ThenReturnNoBankDetails()
        {
            // Arrange
            SetUpData();

            // Act
            var result = await _bankRepository.GetBankDetailsByCountryCode("SE");
            // Assert
            result.Should().BeEmpty();

        }

        private async void SetUpData()
        {
            await _context.Banks.AddAsync(TestDataHelper.Bank);
            await _context.SaveChangesAsync();
        }
    }
}

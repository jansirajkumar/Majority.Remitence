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
    public class ExchangeRateRepositoryTests
    {
        private readonly RemittanceProviderContext _context;

        private readonly IExchangeRateRepository _exchangeRateRepository;

        public ExchangeRateRepositoryTests()
        {
            _context = DBHelper.GetRemittanceProviderContext();
            _exchangeRateRepository = new ExchangeRateRepository(_context);
        }

        [Fact]
        public async Task GetExchangeRate_WhenAcitveExchhangeRatesIsAvailableForCurrency_ThenReturnExchangeRates()
        {
            // Arrange
            SetupData();

            // Act
            var result = await _exchangeRateRepository.GetExchangeRate(new List<string> { "AUD" });

            // Assert
            result.Should().BeEquivalentTo(new List<ExchangeRate> { TestDataHelper.ExchangeRate });
        }

        [Fact]
        public async Task GetExchangeRate_WhenNoAcitveExchhangeRatesIsAvailableForCurrency_ThenReturnEmptyList()
        {
            // Arrange
            SetupData(false);

            // Act
            var result = await _exchangeRateRepository.GetExchangeRate(new List<string> { "AUD" });

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetExchangeRate_WhenNoExchhangeRatesIsAvailableForCurrency_ThenReturnEmptyList()
        {
            // Arrange
            SetupData();

            // Act
            var result = await _exchangeRateRepository.GetExchangeRate(new List<string> { "USD" });

            // Assert
            result.Should().BeEmpty();
        }
        private async void SetupData(bool inActive = true)
        {
            await _context.ExchangeRates.AddAsync(inActive ? TestDataHelper.ExchangeRate : TestDataHelper.ExchangeRateInActive);
            await _context.SaveChangesAsync();
        }
    }
}

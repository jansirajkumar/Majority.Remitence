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
    public class CountryRepositoryTests
    {
        private readonly RemittanceProviderContext _context;

        private readonly ICountryRepository _countryrepository;

        public CountryRepositoryTests()
        {
            _context = DBHelper.GetRemittanceProviderContext();
            _countryrepository = new CountryRepository(_context);
        }

        [Fact]
        public async Task GetCountries_WhenAcitveCountryIsAvailable_ThenReturnCountries()
        {
            // Arrange
            SetupData();

            // Act
            var result = await _countryrepository.GetSupportedCountries();

            // Assert
            result.Should().BeEquivalentTo(new List<Country> { TestDataHelper.Country() });
        }

        [Fact]
        public async Task GetCountries_WhenNoAcitveCountryIsAvailable_ThenReturnEmptyList()
        {
            // Arrange
            SetupData(false);

            // Act
            var result = await _countryrepository.GetSupportedCountries();

            // Assert
            result.Should().BeEmpty();
        }
        private async void SetupData(bool inActive = true)
        {
            await _context.Countries.AddAsync(TestDataHelper.Country(inActive));
            await _context.SaveChangesAsync();
        }
    }
}

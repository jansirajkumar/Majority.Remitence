using System.Threading.Tasks;
using FluentAssertions;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Majority.RemittanceProvider.Infrastructure.Repositories;
using Majority.RemittanceProvider.Infrastructure.Tests.Helpers;
using Majority.RemittanceProvider.Infrastructure.UnitTests.RepositoryTests;
using Xunit;


namespace Majority.RemittanceProvider.Infrastructure.Tests
{
    public class StateRepositoryTests
    {
        private readonly RemittanceProviderContext _context;

        private readonly IStateRepository _stateRepository;

        public StateRepositoryTests()
        {
            _context = DBHelper.GetRemittanceProviderContext();
            _stateRepository = new StateRepository(_context);
        }

        [Fact]
        public async Task GetStates_WhenStatesAvailableForCountry_ThenReturnStates()
        {
            // Arrange
            SetupData();

            // Act
            var result = await _stateRepository.GetStates("US");

            // Assert
            result.Should().BeEquivalentTo(TestDataHelper.States);
        }

        [Fact]
        public async Task GetStates_WhenNoStatesAvailableForCountry_ThenReturnEmpty()
        {
            // Arrange
            SetupData();

            // Act
            var result = await _stateRepository.GetStates("SE");

            // Assert
            result.Should().BeEmpty();

        }
        [Fact]
        public async Task GetStates_WhenNoCountryInputIsgiven_ThenReturnStatesOfDefaultCountry()
        {
            // Arrange
            SetupData();

            // Act
            var result = await _stateRepository.GetStates();

            // Assert
            result.Should().BeEquivalentTo(TestDataHelper.States);

        }
        private async void SetupData()
        {
            await _context.States.AddRangeAsync(TestDataHelper.States);
            await _context.SaveChangesAsync();
        }
    }
}

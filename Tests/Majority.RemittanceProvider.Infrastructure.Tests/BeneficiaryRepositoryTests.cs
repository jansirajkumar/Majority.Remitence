using System.Threading.Tasks;
using FluentAssertions;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Majority.RemittanceProvider.Infrastructure.Repositories;
using Majority.RemittanceProvider.Infrastructure.Tests.Helpers;
using Majority.RemittanceProvider.Infrastructure.UnitTests.RepositoryTests;
using Xunit;


namespace Majority.RemittanceProvider.Infrastructure.Tests
{
    public class BeneficiaryRepositoryTests
    {
        private readonly RemittanceProviderContext _context;

        private readonly IBeneficiaryRepository _beneficiaryRepository;

        public BeneficiaryRepositoryTests()
        {
            _context = DBHelper.GetRemittanceProviderContext();
            _beneficiaryRepository = new BeneficiaryRepository(_context);
        }

        [Fact]
        public async Task GetBeneficiaryDetailsByBankCodeAndAccountNumber_WhenValidBankCodeAndAccountIsGiven_ThenReturnBeneficiaryDetails()
        {
            // Arrange
            SetupData();

            // Act
            var result = await _beneficiaryRepository.GetBeneficiaryDetailsByBankCodeAndAccountNumber("BOA", "123456789");

            // Assert
            result.Should().BeEquivalentTo(TestDataHelper.Beneficiary);
        }
        [Fact]
        public async Task GetBeneficiaryDetailsByBankCodeAndAccountNumber_WhenInValidBankCodeAndAccountIsGiven_ThenReturnEmpty()
        {
            // Arrange
            SetupData();

            // Act
            var result = await _beneficiaryRepository.GetBeneficiaryDetailsByBankCodeAndAccountNumber("1234589", "BOA");

            // Assert
            Assert.Null(result);
        }

        private async void SetupData()
        {
            await _context.Beneficiaries.AddAsync(TestDataHelper.Beneficiary);
            await _context.SaveChangesAsync();
        }
    }
}

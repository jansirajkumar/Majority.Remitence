
using System;
using System.Threading.Tasks;
using FluentAssertions;
using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Application.Features.Queries;
using Majority.RemittanceProvider.Application.Tests.Helpers;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Moq;
using Xunit;

namespace Majority.RemittanceProvider.Application.Tests.CommandAndQueriesTests
{
    public class GetBeneficiaryQueryHandlerTests
    {
        private readonly Mock<IBeneficiaryRepository> _mockRepository;
        private readonly GetBeneficiaryNameQuery _query;
        private readonly GetBeneficiaryNameQueryHandler _handler;

        public GetBeneficiaryQueryHandlerTests()
        {
            _mockRepository = MockSetupHelper.MockBeneficieryRepository();
            var mapper = AutoMapperHelper.GetMapper();
            _query = new GetBeneficiaryNameQuery(It.IsAny<string>(), It.IsAny<string>());
            _handler = new GetBeneficiaryNameQueryHandler(_mockRepository.Object, mapper);
        }

        [Fact]
        public async Task GetBeneficiaryNameHandler_WhenBeneficiaryDetailsAvailable_ThenReturnName()
        {
            // Act
            var result = await _handler.Handle(_query, default);
            // Assert
            result.Should().BeEquivalentTo(new BeneficiaryDto
            {
                BeneficiaryName = "Rajkumar",
            });
        }

        [Fact]
        public async Task GetBanksHandler_WhenNoBeneficaryDetailsAvailable_ThenThrowArgumentException()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetBeneficiaryDetailsByBankCodeAndAccountNumber(It.IsAny<string>(), It.IsAny<string>()))
                 .Returns(Task.FromResult<Beneficiary>(null));
            // Act
            var result = await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(_query, default));
            Assert.Equal("Beneficiary details not found", result.Message);
        }


    }
}

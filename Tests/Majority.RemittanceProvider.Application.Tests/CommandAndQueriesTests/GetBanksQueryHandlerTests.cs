
using System;
using System.Collections.Generic;
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
    public class GetBanksQueryHandlerTests
    {
        private readonly Mock<IBankRepository> _mockRepository;
        private readonly GetBanksQuery _query;
        private readonly GetBanksQueryHandler _handler;

        public GetBanksQueryHandlerTests()
        {
            _mockRepository = MockSetupHelper.MockBankRepository();
            var mapper = AutoMapperHelper.GetMapper();
            _query = new GetBanksQuery(It.IsAny<string>());
            _handler = new GetBanksQueryHandler(_mockRepository.Object, mapper);
        }

        [Fact]
        public async Task GetBanksHandler_WhenBankDetailIsAvailableForTheCountry_ThenReturnBanks()
        {
            // Act
            var result = await _handler.Handle(_query, default);
            // Assert
            result.Should().BeEquivalentTo(new List<BankDto>
            {
                new BankDto
                {
                    Code = "HSB",
                    Name =  "HSBC Bank of America",
                }
            });
        }

        [Fact]
        public async Task GetBanksHandler_WhenNoBanksAvailbleForTheCountry_ThenThrowArgumentException()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetBankDetailsByCountryCode(It.IsAny<string>()))
                 .Returns(Task.FromResult(new List<Bank>() { }));
            // Act
            var result = await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(_query, default));
            Assert.Equal("No banks found for the given country", result.Message);
        }


    }
}

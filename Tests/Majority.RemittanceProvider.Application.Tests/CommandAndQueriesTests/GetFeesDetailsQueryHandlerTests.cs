
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
    public class GetFeesDetailsQueryHandlerTests
    {
        private readonly Mock<IFeesRepository> _mockRepository;
        private readonly GetFeesQuery _query;
        private readonly GetFeesQueryHandler _handler;

        public GetFeesDetailsQueryHandlerTests()
        {
            _mockRepository = MockSetupHelper.MockFeesRepository();
            _query = new GetFeesQuery("US", "se");
            _handler = new GetFeesQueryHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task GetFeesHandler_WhenFeesDetailssAvailableForTheCountry_ThenReturnFees()
        {

            // Act
            var result = await _handler.Handle(_query, default);
            // Assert
            result.Should().BeEquivalentTo(
             new FeesDto
             {
                 ToCountryCode = "SE",
                 FromCountryCode = "US",
                 TransferMode = new List<TransferModeDto>
                 {
                     new TransferModeDto
                     {
                         Description ="Transfer money from bank",
                         FeesInPercentage =0.6,
                         TransferMode ="Bank"
                     }
                 }
            });
        }

        [Fact]
        public async Task GetBanksHandler_WhenNoBanksAvailbleForTheCountry_ThenThrowArgumentException()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetFees(It.IsAny<string>(), It.IsAny<string>()))
                 .Returns(Task.FromResult(new List<FeesDetails>() { }));
            // Act
            var result = await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(_query, default));
            Assert.Equal("No fees details available for the country", result.Message);
        }


    }
}

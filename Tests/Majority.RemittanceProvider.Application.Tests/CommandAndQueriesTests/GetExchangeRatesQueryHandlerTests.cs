
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
    public class GetExchangeRatesQueryHandlerTests
    {
        private readonly Mock<IExchangeRateRepository> _mockRepository;
        private readonly GetExchangeRatesQuery _query;
        private readonly GetExchangeRatesQueryHandler _handler;

        public GetExchangeRatesQueryHandlerTests()
        {
            _mockRepository = MockSetupHelper.MockExchangeateRepository();
            _query = new GetExchangeRatesQuery("AUD", "USD,SEK");
            _handler = new GetExchangeRatesQueryHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task GetExchangeRateHandler_WhenExchangeRatesAvailableForTheCurrency_ThenReturnRates()
        {
            // Act
            var result = await _handler.Handle(_query, default);
            // Assert
            result.Should().BeEquivalentTo(new List<ExchangeRateDto>
            {
                new ExchangeRateDto
                {
                    SourceCurrencyCode = "AUD",
                    DestinationCurrencyCode = "SEK",
                    ExchangeRate = 7.2,
                    ExchangeRateToken ="ExchangeToken"
                },
                new ExchangeRateDto
                {
                    SourceCurrencyCode = "AUD",
                    DestinationCurrencyCode = "USD",
                    ExchangeRate =  0.689,
                    ExchangeRateToken ="ExchangeToken"
                },
            });
        }

        [Fact]
        public async Task GetBanksHandler_WhenNoBanksAvailbleForTheCountry_ThenThrowArgumentException()
        {

            // Arrange
            _mockRepository.Setup(x => x.GetExchangeRate(It.IsAny<List<string>>()))
                 .Returns(Task.FromResult(new List<ExchangeRate>() { }));

            // Act & Assert
            var result = await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(_query, default));
            Assert.Equal("No exchange rates found for this countries", result.Message);
        }


    }
}

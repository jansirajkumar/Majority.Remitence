
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
    public class GetCountriesQueryHandlerTests
    {
        private readonly Mock<ICountryRepository> _mockRepository;
        private readonly GetCountriesQuery _query;
        private readonly GetCountriesQueryHandler _handler;

        public GetCountriesQueryHandlerTests()
        {
            _mockRepository = MockSetupHelper.MockCountryRepository();
            var mapper = AutoMapperHelper.GetMapper();
            _query = new GetCountriesQuery();
            _handler = new GetCountriesQueryHandler(_mockRepository.Object, mapper);
        }

        [Fact]
        public async Task GetCountries_WhenCountriesIsAvailable_ThenReturnCountries()
        {
            // Arrange

            // Act
            var result = await _handler.Handle(_query, default);
            // Assert
            result.Should().BeEquivalentTo(new List<CountryDto>
            {
                new CountryDto
                {
                    Code = "US",
                    Name =  "United States Of America",
                    CurrencyCode = "USD"
                }
            });
        }

        [Fact]
        public async Task GetCountries_WhenCountriesNotAvailable_ThenThrowArgumentException()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetSupportedCountries(It.IsAny<bool>()))
                 .Returns(Task.FromResult(new List<Country>() { }));
            // Act
            var result = await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(_query, default));
            Assert.Equal("No countries found", result.Message);
        }


    }
}

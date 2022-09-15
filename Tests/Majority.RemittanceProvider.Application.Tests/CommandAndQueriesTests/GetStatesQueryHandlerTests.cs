
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
    public class GetStatesQueryHandlerTests
    {
        private readonly Mock<IStateRepository> _mockRepository;
        private readonly GetStatesQuery _query;
        private readonly GetStatesQueryHandler _handler;

        public GetStatesQueryHandlerTests()
        {
            _mockRepository = MockSetupHelper.MockStateRepository();
            var mapper = AutoMapperHelper.GetMapper();
            _query = new GetStatesQuery(It.IsAny<string>());
            _handler = new GetStatesQueryHandler(_mockRepository.Object, mapper);
        }

        [Fact]
        public async Task GetStatesHandler_WhenStatesIsAvailable_ThenReturnStates()
        {
            // Arrange

            // Act
            var result = await _handler.Handle(_query, default);
            // Assert
            result.Should().BeEquivalentTo(new List<StateDto>
            {
                new StateDto
                {
                    Code = "CA",
                    Name =  "California",
                }
            });
        }

        [Fact]
        public async Task GetStatesHandler_WhenStatesNotAvailable_ThenThrowArgumentException()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetStates(It.IsAny<string>()))
                 .Returns(Task.FromResult(new List<State>() { }));
            // Act
            var result = await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(_query, default));
            Assert.Equal("No states found", result.Message);
        }


    }
}


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
    public class GetTransactionStatusQueryHandlerTests
    {
        private readonly Mock<ITransactionRepository> _mockRepository;
        private readonly GetTransactionStatusQuery _query;
        private readonly GetTransactionStatusQueryHandler _handler;
        public Guid TransactionId = Guid.NewGuid();

        public GetTransactionStatusQueryHandlerTests()
        {
            _mockRepository = MockSetupHelper.MockTransactionRepository(TransactionId);
            _query = new GetTransactionStatusQuery(TransactionId.ToString());
            _handler = new GetTransactionStatusQueryHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task GetTransctionStatusHandler_WhenTransactionDetailsAvailable_ThenReturnTransactionStatus()
        {
            // Act
            var result = await _handler.Handle(_query, default);
            // Assert
            result.Should().BeEquivalentTo(
                new TransactionStatusDto
                {
                    TransactionId = TransactionId.ToString(),
                    Status = "Completed",
                }
            );
        }

        [Fact]
        public async Task GetTransctionStatusHandle_WhenNoTransactionFound_ThenThrowArgumentException()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetTransaction(It.IsAny<Guid>()))
                 .Returns(Task.FromResult<Transaction?>(null));
            // Act
            var result = await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(_query, default));
            Assert.Equal("No transaction found", result.Message);
        }


    }
}

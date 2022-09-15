
using System;
using System.Threading.Tasks;
using FluentAssertions;
using Majority.RemittanceProvider.Application.Features.Commands;
using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Application.Features.RemittanceProvider.Commands;
using Majority.RemittanceProvider.Application.Tests.Helpers;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Moq;
using Xunit;

namespace Majority.RemittanceProvider.Application.Tests.CommandAndQueriesTests
{
    public class TransactionCommandHandlerTests
    {
        private readonly Mock<ITransactionRepository> _mockRepository;
        private readonly TransactionCommand _command;
        private readonly TransactionCommandHandler _handler;
        public Guid TransactionId = Guid.NewGuid();

        public TransactionCommandHandlerTests()
        {
            _mockRepository = MockSetupHelper.MockTransactionRepository(TransactionId);
            var mapper = AutoMapperHelper.GetMapper();
            _command = new TransactionCommand();
            _handler = new TransactionCommandHandler(_mockRepository.Object, mapper);
        }

        [Fact]
        public async Task TransactionHandler_WhenTransactionSaved_ThenReturnTransactionStatus()
        {
            // Act
            var result = await _handler.Handle(_command, default);

            // Assert
            result.Should().BeEquivalentTo(
                new TransactionStatusDto
                {
                    TransactionId = TransactionId.ToString(),
                    Status = "Completed",
                }
            );
        }
    }
}

using AutoMapper;
using Majority.RemittanceProvider.Application.Features.Commands;
using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.RemittanceProvider.Commands
{
    public class TransactionCommandHandler : IRequestHandler<TransactionCommand, TransactionStatusDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public TransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {

            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }
        public async Task<TransactionStatusDto> Handle(TransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Map the request object to transaction
                var transaction = _mapper.Map<Transaction>(request);
                transaction.Init();

                // Add transaction details
                await _transactionRepository.AddTransaction(transaction);

                // Get the transaction details
                transaction = await _transactionRepository.GetTransaction(transaction.TransactionId);
                return new TransactionStatusDto()
                {
                    TransactionId = transaction?.TransactionId.ToString(),
                    Status = Enum.GetName(typeof(TransactionStatus), transaction.Status),
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}

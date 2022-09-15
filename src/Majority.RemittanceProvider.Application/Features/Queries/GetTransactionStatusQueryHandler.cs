using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries
{
    public class GetTransactionStatusQueryHandler : IRequestHandler<GetTransactionStatusQuery, TransactionStatusDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        public GetTransactionStatusQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionStatusDto> Handle(GetTransactionStatusQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var transaction = await _transactionRepository.GetTransaction(new Guid(request.TransactionId));

                if (transaction != null)
                {
                    return new TransactionStatusDto()
                    {
                        TransactionId = transaction.TransactionId.ToString(),
                        Status = Enum.GetName(typeof(TransactionStatus), transaction.Status),
                    };
                }
                throw new ArgumentException("No transaction found");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

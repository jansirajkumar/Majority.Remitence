using Majority.RemittanceProvider.Application.Features.Dtos;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries
{
    public class GetTransactionStatusQuery : IRequest<TransactionStatusDto>
    {
        public string TransactionId { get; set; }

        public GetTransactionStatusQuery(string transactionId)
        {
            TransactionId = transactionId;
        }
    }
}

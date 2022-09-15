using Majority.RemittanceProvider.Application.Features.Dtos;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries
{
    public class GetBeneficiaryNameQuery : IRequest<BeneficiaryDto>
    {
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }

        public GetBeneficiaryNameQuery(string accountNumber, string bankCode)
        {
            AccountNumber = accountNumber;
            BankCode = bankCode;
        }

    }
}

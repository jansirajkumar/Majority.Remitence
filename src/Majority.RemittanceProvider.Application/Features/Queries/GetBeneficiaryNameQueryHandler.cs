using AutoMapper;
using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries
{
    public class GetBeneficiaryNameQueryHandler : IRequestHandler<GetBeneficiaryNameQuery, BeneficiaryDto>
    {
        private readonly IBeneficiaryRepository _beneficiaryRepository;
        private readonly IMapper _mapper;

        public GetBeneficiaryNameQueryHandler(IBeneficiaryRepository beneficiaryRepository, IMapper mapper
            )
        {
            _beneficiaryRepository = beneficiaryRepository;
            _mapper = mapper;

        }
        public async Task<BeneficiaryDto> Handle(GetBeneficiaryNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var beneficiary = await _beneficiaryRepository.GetBeneficiaryDetailsByBankCodeAndAccountNumber(request.BankCode, request.AccountNumber);
                if (beneficiary == null)
                {
                    throw new ArgumentException("Beneficiary details not found");
                }
                return _mapper.Map<BeneficiaryDto>(beneficiary);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
            throw new NotImplementedException();
        }
    }
}

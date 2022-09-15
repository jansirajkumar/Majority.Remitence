using AutoMapper;
using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries
{
    public class GetBanksQueryHandler : IRequestHandler<GetBanksQuery, List<BankDto>>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public GetBanksQueryHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public async Task<List<BankDto>> Handle(GetBanksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var banks = await _bankRepository.GetBankDetailsByCountryCode(request.CountryCode);

                if (banks?.Count == 0)
                {
                    throw new ArgumentException("No banks found for the given country");
                }
                return _mapper.Map<List<BankDto>>(banks);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }
    }
}

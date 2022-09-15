using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries
{
    public class GetFeesQueryHandler : IRequestHandler<GetFeesQuery, FeesDto>
    {
        private readonly IFeesRepository _feesRepository;
        public GetFeesQueryHandler(IFeesRepository feesRepository)
        {
            _feesRepository = feesRepository;
        }
        public async Task<FeesDto> Handle(GetFeesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Get the different transfer modes available
                var feesDetails = await _feesRepository.GetFees(request.From.ToUpper(), request.To.ToUpper());

                // calculate the fees 
                if (feesDetails?.Count == 0)
                {
                    throw new ArgumentException("No fees details available for the country");
                }
                return CalculateFeesDetail(feesDetails);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static FeesDto CalculateFeesDetail(List<FeesDetails> feesDetails)
        {
            var fees = new FeesDto();
            foreach (var feesDetail in feesDetails)
            {
                fees.ToCountryCode = feesDetail.ToCountryCode;
                fees.FromCountryCode = feesDetail.FromCountryCode;
                fees.TransferMode.Add(new TransferModeDto()
                {
                    TransferMode = feesDetail.TransferMode.TransferModeName,
                    Description = feesDetail.TransferMode.TransferModeDescription,
                    FeesInPercentage = feesDetail.FeesPercentage,
                });
            }
            return fees;
        }
    }
}

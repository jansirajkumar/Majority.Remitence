using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries
{
    public class GetExchangeRatesQueryHandler : IRequestHandler<GetExchangeRatesQuery, List<ExchangeRateDto>>
    {
        private readonly IExchangeRateRepository _exchangeRateRepository;

        public GetExchangeRatesQueryHandler(IExchangeRateRepository exchangeRateRepository)
        {
            _exchangeRateRepository = exchangeRateRepository;

        }
        public async Task<List<ExchangeRateDto>> Handle(GetExchangeRatesQuery request, CancellationToken cancellationToken)
        {
            try
            {

                List<string> inputs = string.IsNullOrWhiteSpace(request.To) ? new List<string>()
                        : request.To.ToUpper().Split(',').ToList();
                inputs.Add(request.From.ToUpper());

                // Get the exchange rates based on the inputs.
                var exchangeRates = await _exchangeRateRepository.GetExchangeRate(inputs);

                var exchangeRateDtos = new List<ExchangeRateDto>();
                if (exchangeRates?.Count > 0)
                {
                    inputs = string.IsNullOrWhiteSpace(request.To) ? new List<string>()
                        : request.To.ToUpper().Split(',').ToList();
                    foreach (var input in inputs)
                    {

                        var exchangeRate = exchangeRates.Where(x => x.DestinationCurrencyCode == input).FirstOrDefault();
                        if (exchangeRate != null)
                        {
                            exchangeRateDtos.Add(new ExchangeRateDto
                            {
                                ExchangeRateToken = exchangeRate.ExchangeRateToken,
                                ExchangeRate = ExchangeRateCalculator.Calcuate(request.From.ToUpper(), input, exchangeRate, exchangeRates),
                                SourceCurrencyCode = request.From,
                                DestinationCurrencyCode = input
                            });
                        }

                    }

                    return exchangeRateDtos;
                }
                else
                {
                    throw new ArgumentException("No exchange rates found for this countries");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}

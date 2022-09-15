
namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public static class ExchangeRateCalculator
    {
        public static double Calcuate(string sourceCurrencyCode, string destinationCurrencyCode, ExchangeRate exchangeRate, List<ExchangeRate> exchangeRates)
        {
            double rate = 0;

            if (exchangeRate.BaseCurrencyCode == sourceCurrencyCode)
            {
                rate = exchangeRate.Rate;
            }
            else
            {
                double sourceRate = exchangeRates
                     .Where(x => x.DestinationCurrencyCode == sourceCurrencyCode)
                     .Select(x => x.Rate).First();
                double destinationRate = exchangeRates
                            .Where(x => x.DestinationCurrencyCode == destinationCurrencyCode)
                            .Select(x => x.Rate).First();
                rate = destinationRate / sourceRate;
            }
            return Math.Round(rate, 3);
        }
    }
}

namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public interface IExchangeRateRepository
    {
        /// <summary>
        /// This function is used to get the exchange rate details based on the given currency codes
        /// </summary>
        /// <param name="list of currencyCodes"></param>
        /// <returns></returns>
        Task<List<ExchangeRate>> GetExchangeRate(List<string> currencyCodes);
    }
}

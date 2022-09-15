
namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public class ExchangeRate
    {
        public string BaseCurrencyCode { get; set; }
        public string DestinationCurrencyCode { get; set; }
        public DateTime ExchangeRateDate { get; set; }
        public bool IsActive { get; set; }
        public double Rate { get; set; }
        public string ExchangeRateToken { get; set; }
    }
}

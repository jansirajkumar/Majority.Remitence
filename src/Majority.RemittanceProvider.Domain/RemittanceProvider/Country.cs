namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsActive { get; set; }
        public List<State> States { get; set; }
        public List<Bank> Banks { get; set; }
    }
}

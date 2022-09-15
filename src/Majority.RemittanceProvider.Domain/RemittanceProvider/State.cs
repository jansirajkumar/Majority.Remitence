
namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public class State
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public Country Country { get; set; }
    }
}

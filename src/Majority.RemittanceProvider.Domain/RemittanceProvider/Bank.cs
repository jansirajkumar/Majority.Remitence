namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public class Bank
    {
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public string MICRCode { get; set; }
        public string? Address { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? CountryCode { get; set; }
        public string? PinCode { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual Country Country { get; set; }

    }
}

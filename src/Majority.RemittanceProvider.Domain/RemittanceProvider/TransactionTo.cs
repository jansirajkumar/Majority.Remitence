namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public class TransactionTo
    {
        public string ToFirstName { get; set; }
        public string ToLastName { get; set; }
        public string ToCountry { get; set; }
        public string ToBankAccountName { get; set; }
        public string ToBankAccountNumber { get; set; }
        public string ToBankName { get; set; }
        public string ToBankCode { get; set; }
        public Guid TransactionId { get; set; }

    }
}

namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public class TransactionSender
    {
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPhoneNumber { get; set; }
        public string Address { get; set; }
        public string SenderCountry { get; set; }
        public string SenderCity { get; set; }
        public string SenderFromState { get; set; }
        public string SenderPostalCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid TransactionId { get; set; }

    }
}

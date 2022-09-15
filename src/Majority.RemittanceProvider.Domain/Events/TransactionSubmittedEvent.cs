namespace Majority.RemittanceProvider.Domain.Events
{
    public class TransactionSubmittedEvent : Event
    {
        public TransactionSubmittedEvent(Guid transactionId)
        {
            TransactionId = transactionId;
        }
        public Guid TransactionId { get; set; }
    }
}

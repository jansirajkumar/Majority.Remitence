using Majority.RemittanceProvider.Domain.RemittanceProvider;

namespace Majority.RemittanceProvider.Domain.Events
{
    public class TransactionStatusChangedEvent : Event
    {
        public Guid TransactionId { get; set; }
        public TransactionStatus Status { get; set; }
        public TransactionStatus OldStatus { get; set; }

        public TransactionStatusChangedEvent(TransactionStatus oldStatus, TransactionStatus newStatus, Guid transationId)
        {
            TransactionId = transationId;
            Status = oldStatus;
            OldStatus = newStatus;
        }
    }
}

using System.ComponentModel.DataAnnotations;
using Majority.RemittanceProvider.Domain.Events;

namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public class Transaction : AggregateRoot
    {
        [Key]
        public Guid TransactionId { get; set; }
        public double FromAmount { get; set; }
        public double ExchangeRate { get; set; }
        public double Fees { get; set; }
        public string TransactionNumber { get; set; }
        public string Currency { get; set; }
        public TransactionStatus Status { get; set; }
        public virtual TransactionSender TransactionSender { get; set; } = new TransactionSender();
        public virtual TransactionTo TransactionTo { get; set; } = new TransactionTo();

        public void Init()
        {

            TransactionId = Guid.NewGuid();

            TransactionSender.TransactionId = TransactionId;
            TransactionTo.TransactionId = TransactionId;

            Status = TransactionStatus.Pending;

            // After new transaction added Transaction submitted added to the event
            var @event = new TransactionSubmittedEvent(TransactionId);
            AddEvent(@event);


        }
        public void ChangeStatus(TransactionStatus oldStatus, TransactionStatus newStatus)
        {
            // Changes to the transaction added to the event
            var @event = new TransactionStatusChangedEvent(oldStatus, newStatus, TransactionId);
            AddEvent(@event);
        }
    }


    public enum TransactionStatus
    {

        Pending = 1,
        Completed,
        Canceled,
        Declined
    }
}

using MediatR;

namespace Majority.RemittanceProvider.Domain.Events
{
    internal class TransactionSubmittedEventHandler : INotificationHandler<TransactionSubmittedEvent>
    {
        public Task Handle(TransactionSubmittedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //protected override void Handle(TransactionSubmittedEvent notification)
        //{
        //    //TO be implmented if event handled in this project
        //}
    }
}

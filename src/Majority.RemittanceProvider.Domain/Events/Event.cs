using MediatR;

namespace Majority.RemittanceProvider.Domain.Events
{
    public class Event : INotification
    {

        public int id { get; set; }
    }
}

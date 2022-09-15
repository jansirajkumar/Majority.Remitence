using Majority.RemittanceProvider.Domain.Events;

namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public class AggregateRoot
    {

        public List<Event> Events;

        public AggregateRoot()
        {
            Events = new List<Event>();
        }

        protected void AddEvent(Event @event)
        {
            Events.Add(@event);
        }

        public void ClearEvents()
        {
            Events.Clear();
        }
    }
}

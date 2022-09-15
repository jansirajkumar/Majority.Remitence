using Majority.RemittanceProvider.Domain.Events;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Majority.RemittanceProvider.Infrastructure.Repositories;
using MediatR;

namespace Majority.RemittanceProvider.Infrastructure.Extensions
{
    internal static class MediatorExtensions
    {
        public static async Task DispatchEventsAsync(this IMediator mediator, RemittanceProviderContext context)
        {

            var aggregateRoots = context.ChangeTracker
                .Entries<AggregateRoot>()
                .Where(x => x.Entity.Events != null && x.Entity.Events.Any())
                .Select(e => e.Entity)
                .ToList();

            var events = aggregateRoots
                .SelectMany(x => x.Events)
                .ToList();

            await mediator.DispatchDomainEventsAsync(events);

            ClearDomainEvents(aggregateRoots);
        }

        private static async Task DispatchDomainEventsAsync(this IMediator mediator, List<Event> events)
        {
            foreach (var @event in events)
            {

                //In real scenario need to publish to the mediator like Kafka, Azure Service bus, etc..
                await mediator.Publish(@event);
            }
        }

        private static void ClearDomainEvents(List<AggregateRoot> aggregateRoots)
        {
            aggregateRoots.ForEach(aggregate => aggregate.ClearEvents());
        }
    }
}

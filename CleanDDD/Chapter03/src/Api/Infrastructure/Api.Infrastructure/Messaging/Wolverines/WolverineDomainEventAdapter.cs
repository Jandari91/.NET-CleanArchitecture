using Shared.Adapter.Messaging;
using Shared.Domain;
using Wolverine;

namespace Api.Infrastructure.Messaging.Wolverines;

internal sealed class WolverineDomainEventAdapter(IMessageBus bus) : IDomainEventBus
{
    public async Task PublishAsync(IEnumerable<IDomainEvent> events, CancellationToken ct)
    {
        foreach (var e in events)
            await bus.PublishAsync(e).AsTask();
    }
}

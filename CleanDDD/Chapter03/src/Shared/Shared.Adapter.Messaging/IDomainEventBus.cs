using Shared.Domain;

namespace Shared.Adapter.Messaging;

public interface IDomainEventBus
{
    Task PublishAsync(IEnumerable<IDomainEvent> events, CancellationToken ct);
}

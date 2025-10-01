using Shared.Domain;

namespace Api.Domain.Abstractions;

public abstract record DomainEventBase : IDomainEvent
{
    public DateTime OccurredOnUtc { get; init; } = DateTime.UtcNow;
}

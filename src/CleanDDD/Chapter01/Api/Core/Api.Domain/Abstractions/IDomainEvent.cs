namespace Api.Domain.Abstractions;

public interface IDomainEvent
{
    DateTime OccurredOnUtc { get; }
}

public abstract record DomainEventBase : IDomainEvent
{
    public DateTime OccurredOnUtc { get; init; } = DateTime.UtcNow;
}

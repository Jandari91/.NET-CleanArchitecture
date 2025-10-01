namespace Shared.Application.Behaviors;

public interface ITransactionBehavior
{
    Task<T> ExecuteInTransaction<T>(Func<CancellationToken, Task<T>> action, CancellationToken ct);
}

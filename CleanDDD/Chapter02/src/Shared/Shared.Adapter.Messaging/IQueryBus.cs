using Shared.Application.Abstractions;

namespace Shared.Adapter.Messaging;

public interface IQueryBus
{
    Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query, CancellationToken ct = default);
}

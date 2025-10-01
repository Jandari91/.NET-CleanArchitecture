using Shared.Adapter.Messaging;
using Shared.Application.Abstractions;
using Wolverine;

namespace Client.Infrastructure.Messaging.Wolverines;

internal sealed class WolverineQueryAdapter(IMessageBus bus) : IQueryBus
{
    public Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query, CancellationToken ct)
        => bus.InvokeAsync<TResponse>(query, ct);
}

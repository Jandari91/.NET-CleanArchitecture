using Shared.Application.Abstractions;
using Wolverine;

namespace Api.Infrastructure.Messaging.Wolverines;

internal sealed class WolverineCommandAdapter(IMessageBus bus) : Shared.Adapter.Messaging.ICommandBus
{
    public Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken ct)
        => bus.InvokeAsync<TResponse>(command, ct);
}

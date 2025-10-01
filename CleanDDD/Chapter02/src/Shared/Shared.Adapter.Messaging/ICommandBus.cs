using Shared.Application.Abstractions;

namespace Shared.Adapter.Messaging;

public interface ICommandBus
{
    Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken ct);
}

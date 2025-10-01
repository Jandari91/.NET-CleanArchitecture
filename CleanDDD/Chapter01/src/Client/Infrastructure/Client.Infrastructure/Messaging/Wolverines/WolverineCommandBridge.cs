using Shared.Application.Abstractions;
using Shared.Application.Behaviors;

namespace Client.Infrastructure.Messaging.Wolverines
{
    public sealed class WolverineCommandBridge<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    {
        private readonly ICommandHandler<TCommand, TResponse> _inner;
        private readonly IValidationBehavior _validator;
        private readonly ITransactionBehavior _tx;

        public WolverineCommandBridge(
            ICommandHandler<TCommand, TResponse> inner,
            IValidationBehavior validator,
            ITransactionBehavior tx)
        {
            _inner = inner; _validator = validator; _tx = tx;
        }

        public Task<TResponse> Handle(TCommand cmd, CancellationToken ct)
            => _tx.ExecuteInTransaction<TResponse>(async _ =>
            {
                await _validator.Validate(cmd, ct);
                return await _inner.Handle(cmd, ct);
            }, ct);
    }
}

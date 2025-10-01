using Shared.Application.Abstractions;
using Shared.Application.Behaviors;

namespace Api.Infrastructure.Messaging.Wolverines;

public sealed class WolverineQueryBridge<TQuery, TResponse>
where TQuery : IQuery<TResponse>
{
    private readonly IQueryHandler<TQuery, TResponse> _inner;
    private readonly IValidationBehavior _validator;

    public WolverineQueryBridge(IQueryHandler<TQuery, TResponse> inner, IValidationBehavior validator)
    { _inner = inner; _validator = validator; }

    public async Task<TResponse> Handle(TQuery query, CancellationToken ct)
    {
        await _validator.Validate(query, ct);
        return await _inner.Handle(query, ct);
    }
}

namespace Shared.Application.Behaviors;

public interface IValidationBehavior
{
    Task Validate(object message, CancellationToken ct);
}

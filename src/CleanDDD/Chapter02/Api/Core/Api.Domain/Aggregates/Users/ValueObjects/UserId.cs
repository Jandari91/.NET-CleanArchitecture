namespace Api.Domain.Aggregates.Users.ValueObjects;

public readonly record struct UserId(Guid Value)
{
    public static UserId New() => new(Guid.NewGuid());
    public static UserId Parse(string v) => new(Guid.Parse(v));
    public override string ToString() => Value.ToString();
}

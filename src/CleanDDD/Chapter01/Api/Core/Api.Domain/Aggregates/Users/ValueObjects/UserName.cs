using Api.Domain.Abstractions;

namespace Api.Domain.Aggregates.Users.ValueObjects;

public sealed class UserName
{
    public string Value { get; }
    private UserName(string value) => Value = value;
    public static UserName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new DomainException("Name required.");
        if (value.Length > 80) throw new DomainException("Name too long.");
        return new(value.Trim());
    }
    public override string ToString() => Value;
}

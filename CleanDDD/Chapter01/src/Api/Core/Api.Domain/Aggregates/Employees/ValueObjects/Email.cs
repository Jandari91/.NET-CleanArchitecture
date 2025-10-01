using Api.Domain.Abstractions;

namespace Api.Domain.Aggregates.Employees.ValueObjects;

public sealed class Email
{
    public string Value { get; }
    private Email(string value) => Value = value;
    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new DomainException("Email required.");
        if (!value.Contains("@")) throw new DomainException("Invalid email.");
        return new(value.Trim().ToLowerInvariant());
    }
    public override string ToString() => Value;
}
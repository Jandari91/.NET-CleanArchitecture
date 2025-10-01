using Api.Domain.Abstractions;

namespace Api.Domain.Aggregates.Employees.ValueObjects;

public sealed class EmployeeName
{
    public string Value { get; }
    private EmployeeName(string value) => Value = value;
    public static EmployeeName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new DomainException("Name required.");
        if (value.Length > 80) throw new DomainException("Name too long.");
        return new(value.Trim());
    }
    public override string ToString() => Value;
}

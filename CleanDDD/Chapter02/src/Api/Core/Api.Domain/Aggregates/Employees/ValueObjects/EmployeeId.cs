namespace Api.Domain.Aggregates.Employees.ValueObjects;

public readonly record struct EmployeeId(Guid Value)
{
    public static EmployeeId New() => new(Guid.NewGuid());
    public static EmployeeId Parse(string v) => new(Guid.Parse(v));
    public override string ToString() => Value.ToString();
}

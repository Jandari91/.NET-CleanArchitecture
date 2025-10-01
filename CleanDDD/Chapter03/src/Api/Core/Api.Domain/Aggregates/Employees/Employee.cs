using Api.Domain.Abstractions;
using Api.Domain.Aggregates.Employees.ValueObjects;

namespace Api.Domain.Aggregates.Employees;

public sealed class Employee : Entity<EmployeeId>
{
    public EmployeeId EmployeeId { get; private set; }
    public EmployeeName Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public bool IsActive { get; private set; }

    /// <summary>
    /// EF Core
    /// </summary>
    private Employee() { }

    private Employee(EmployeeName name, Email email)
    {
        EmployeeId = EmployeeId.New();
        Name = name;
        Email = email;
        IsActive = true;
    }

    public static Employee Register(EmployeeName name, Email email) => new(name, email);

}

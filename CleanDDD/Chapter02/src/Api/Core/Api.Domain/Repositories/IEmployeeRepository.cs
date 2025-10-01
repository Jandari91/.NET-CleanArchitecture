using Api.Domain.Aggregates.Employees;
using Api.Domain.Aggregates.Employees.ValueObjects;

namespace Api.Domain.Repositories;

public interface IEmployeeRepository
{
    Task<Employee?> GetAsync(EmployeeId id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Employee?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
}
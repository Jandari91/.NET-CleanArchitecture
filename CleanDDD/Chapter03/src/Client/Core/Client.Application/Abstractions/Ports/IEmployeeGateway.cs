using Client.Application.Features.Employees.Models;

namespace Client.Application.Abstractions.Ports;

public interface IEmployeeGateway
{
    Task<IReadOnlyList<EmployeeDto>> GetEmployeesAsync(CancellationToken ct);
}

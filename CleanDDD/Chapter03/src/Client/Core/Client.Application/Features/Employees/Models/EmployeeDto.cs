namespace Client.Application.Features.Employees.Models;

public sealed record EmployeeDto(string Id, string Name, string Email, bool IsActive);

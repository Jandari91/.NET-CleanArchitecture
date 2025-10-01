namespace Api.Application.Features.Employees.Models.Dtos;

public sealed record EmployeeDto(string EmployeeId, string Name, string Email, bool IsActive);
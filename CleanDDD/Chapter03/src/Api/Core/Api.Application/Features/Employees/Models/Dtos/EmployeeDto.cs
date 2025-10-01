namespace Api.Application.Features.Employees.Models.Dtos;

public sealed record EmployeeDto(string Id, string Name, string Email, bool IsActive);
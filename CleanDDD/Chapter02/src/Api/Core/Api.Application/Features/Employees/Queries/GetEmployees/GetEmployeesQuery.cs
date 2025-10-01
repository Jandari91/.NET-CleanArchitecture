using Api.Application.Features.Employees.Models.Dtos;
using Kernel.Results;
using Shared.Application.Abstractions;

namespace Api.Application.Features.Employees.Queries.GetEmployees;

public sealed record GetEmployeesQuery() : IQuery<Result<List<EmployeeDto>>>;

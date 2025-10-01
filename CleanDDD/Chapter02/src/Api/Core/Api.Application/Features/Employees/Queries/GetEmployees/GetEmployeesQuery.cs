using Api.Application.Features.Employees.Models.Dtos;
using Shared.Application.Abstractions;
using Shared.Application.Common;

namespace Api.Application.Features.Employees.Queries.GetEmployees;

public sealed record GetEmployeesQuery() : IQuery<Result<List<EmployeeDto>>>;

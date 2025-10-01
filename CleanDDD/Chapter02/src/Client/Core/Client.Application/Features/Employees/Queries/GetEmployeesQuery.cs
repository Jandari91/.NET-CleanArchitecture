using Client.Application.Features.Employees.Models;
using Kernel.Results;
using Shared.Application.Abstractions;

namespace Client.Application.Features.Employees.Queries;

public sealed record GetEmployeesQuery() : IQuery<Result<List<EmployeeDto>>>;

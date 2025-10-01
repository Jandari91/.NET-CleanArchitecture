using Client.Application.Features.Employees.Models;
using Shared.Application.Abstractions;
using Shared.Application.Common;

namespace Client.Application.Features.Employees.Queries;

public sealed record GetEmployeesQuery() : IQuery<Result<List<EmployeeDto>>>;

using Api.Application.Features.Employees.Models.Dtos;
using Api.Domain.Repositories;
using Shared.Application.Abstractions;
using Shared.Application.Common;

namespace Api.Application.Features.Employees.Queries.GetEmployees;

public sealed class GetEmployeesHandler : IQueryHandler<GetEmployeesQuery, Result<List<EmployeeDto>>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeesHandler(IEmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;

    public async Task<Result<List<EmployeeDto>>> Handle(GetEmployeesQuery req, CancellationToken cancellationToken)
    {
        var list = await _employeeRepository.GetAllAsync(cancellationToken);

        var dto = list.Select(u =>
            new EmployeeDto(
                u.EmployeeId.ToString(),
                u.Name.ToString(),
                u.Email.ToString(),
                u.IsActive))
            .ToList();

        return Result<List<EmployeeDto>>.Ok(dto);
    }
}

using Client.Application.Abstractions.Ports;
using Client.Application.Features.Employees.Models;
using Kernel.Results;
using Shared.Application.Abstractions;

namespace Client.Application.Features.Employees.Queries;

public sealed class GetEmployeesHandler : IQueryHandler<GetEmployeesQuery, Result<List<EmployeeDto>>>
{
    private readonly IEmployeeGateway _employeesGateway;

    public GetEmployeesHandler(IEmployeeGateway employeesGateway) => _employeesGateway = employeesGateway;

    public async Task<Result<List<EmployeeDto>>> Handle(GetEmployeesQuery req, CancellationToken cancellationToken)
    {
        var list = await _employeesGateway.GetEmployeesAsync(cancellationToken);

        var dto = list.Select(u =>
            new EmployeeDto(
                u.Id,
                u.Name,
                u.Email,
                u.IsActive))
            .ToList();

        return Result<List<EmployeeDto>>.Ok(dto);
    }
}

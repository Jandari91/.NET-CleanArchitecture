using Api.Application.Features.Employees.Queries.GetEmployees;
using CleanDDD.Contracts.Employees.v1;
using Grpc.Core;
using Shared.Adapter.Messaging;
namespace Api.Service.Controllers;

public class EmployeeController : EmployeeService.EmployeeServiceBase
{
    private readonly IQueryBus _bus;
    public EmployeeController(IQueryBus bus)
    {
        _bus = bus ?? throw new ArgumentNullException(nameof(bus));
    }

    public override async Task<GetEmployeesResponse> GetEmployees(GetEmployeesRequest request, ServerCallContext context)
    {
        var res = await _bus.SendAsync(new GetEmployeesQuery(), context.CancellationToken);

        if (!res.IsSuccess)
            throw new RpcException(new Status(StatusCode.Internal, res.Error.ToString()));

        var rsp = new GetEmployeesResponse();
        rsp.Items.AddRange(res.Value.Select(u => new Employee
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            IsActive = u.IsActive
        }));
        return rsp;
    }
}

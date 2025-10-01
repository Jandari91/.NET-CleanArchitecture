using CleanDDD.Contracts.Employees.v1;
using Grpc.Core;
namespace Api.Service.Controllers;

public class EmployeeController : EmployeeService.EmployeeServiceBase
{
    private readonly List<Employee> _employees = new()
    {
        new Employee { Id = "5caf2e3a-73f3-40f9-9045-5b970730eabf", Name = "Bak", Email = "pys0201@hanwha.com" },
        new Employee { Id = "9797dc8e-22ad-4ebf-acb4-e2ce7573058d", Name = "Jo", Email = "jbh0424@hanwha.com" },
        new Employee { Id = "cda45c93-d1f8-4b10-8a58-50a728f479dc", Name = "Hwang", Email = "ghkd6535@hanwha.com" },
        new Employee { Id = "bf0cd722-c5f6-4199-861f-afc21692ff5e", Name = "Moon", Email = "magte007@hanwha.com" },

    };

    public override async Task<GetEmployeesResponse> GetEmployees(GetEmployeesRequest request, ServerCallContext context)
    {
        return await Task.Run(() => {
            var rsp = new GetEmployeesResponse();
            rsp.Items.AddRange(_employees);
            return rsp;
        });
    }
}

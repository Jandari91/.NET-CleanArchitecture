using CleanDDD.Contracts.Employees.v1;
using Client.Application.Abstractions.Ports;
using Client.Application.Features.Employees.Models;
using static CleanDDD.Contracts.Employees.v1.EmployeeService;

namespace Client.Infrastructure.Gateways
{
    public class EmployeeGateway : IEmployeeGateway
    {
        private readonly EmployeeServiceClient _client;

        public EmployeeGateway(EmployeeServiceClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IReadOnlyList<EmployeeDto>> GetEmployeesAsync(CancellationToken ct)
        {
            var resp = await _client.GetEmployeesAsync(new GetEmployeesRequest(), cancellationToken: ct);
            return resp.Items.Select(Map).ToList();
        }

        private static EmployeeDto Map(Employee x)
            => new EmployeeDto(
                Id: x.Id,
                Name: x.Name,
                Email: x.Email,
                IsActive: x.IsActive
            );
    }
}

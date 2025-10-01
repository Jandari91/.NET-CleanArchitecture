using Api.Domain.Aggregates.Employees;
using Api.Domain.Aggregates.Employees.ValueObjects;
using Api.Domain.Repositories;

namespace Api.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new()
        {
            Employee.Register(EmployeeName.Create("Bak"), Email.Create("pys0201@hanwha.com")),
            Employee.Register(EmployeeName.Create("Jo"), Email.Create("jbh0424@hanwha.com")),
            Employee.Register(EmployeeName.Create("Hwang"), Email.Create("ghkd6535@hanwha.com")),
            Employee.Register(EmployeeName.Create("Moon"), Email.Create("magte007@hanwha.com")),
            
        };

        public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
            => await Task.Run(() => _employees);

        public Task<Employee?> GetAsync(EmployeeId id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default)
            => await Task.Run(() => _employees.FirstOrDefault(u => u.Email.Value == email.Value));
    }
}

using Api.Domain.Aggregates.Users;
using Api.Domain.Aggregates.Users.ValueObjects;
using Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new()
        {
            User.Register(UserName.Create("Bak"), Email.Create("pys0201@hanwha.com")),
            User.Register(UserName.Create("Jo"), Email.Create("jbh0424@hanwha.com")),
            User.Register(UserName.Create("Hwang"), Email.Create("ghkd6535@hanwha.com")),
            User.Register(UserName.Create("Moon"), Email.Create("magte007@hanwha.com")),
            
        };

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
            => await Task.Run(() => _users);

        public Task<User?> GetAsync(UserId id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default)
            => await Task.Run(() => _users.FirstOrDefault(u => u.Email.Value == email.Value));
    }
}

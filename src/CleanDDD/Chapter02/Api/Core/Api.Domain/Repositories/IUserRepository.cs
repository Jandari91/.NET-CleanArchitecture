using Api.Domain.Aggregates.Users;
using Api.Domain.Aggregates.Users.ValueObjects;

namespace Api.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetAsync(UserId id, CancellationToken cancellationToken = default);
    Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
}
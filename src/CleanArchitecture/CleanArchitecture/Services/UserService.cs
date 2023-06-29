using Application;
using Application.Persistences;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Services;

public class UserService : IUserService
{
    private readonly IApplicationDbContext _dbContext;
    public UserService(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<User>> GetUsers()
    {
        var entities = await _dbContext.Users.ToListAsync();
        return entities; ;
    }
}

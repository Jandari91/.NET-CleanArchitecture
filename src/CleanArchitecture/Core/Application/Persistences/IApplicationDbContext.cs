using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistences;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
}
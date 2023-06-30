using Domain.Entities;
using Infrastructure.EFCore.EntityConfigurations;
using Infrastructure.EFCore.EntityInitialize;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("DM80")
               .ApplyConfiguration(new UserEntityConfiguration());

        builder.HasUsers();
    }
}

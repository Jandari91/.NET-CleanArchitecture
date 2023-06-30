using Domain.Entities;
using Infrastructure.Persistence.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore.EntityInitialize;

public static class UserEntityInitialize
{
    public static ModelBuilder HasUsers(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(UserEntityDatas.InitUsers());
        return modelBuilder;
    }

    
}

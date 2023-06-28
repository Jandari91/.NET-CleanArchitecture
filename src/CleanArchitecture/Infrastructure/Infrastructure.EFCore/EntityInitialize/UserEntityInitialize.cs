using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore.EntityInitialize;

public static class UserEntityInitialize
{
    public static ModelBuilder HasUsers(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(InitUsers());
        return modelBuilder;
    }

    private static IEnumerable<User> InitUsers()
    {
        return new List<User>()
        {
            new User() { Id = 1, Name = "박영석", Password = "password", Email ="bak@gmail.com"},
            new User() { Id = 2, Name = "이건우", Password = "password", Email ="lee@gmail.com"},
            new User() { Id = 3, Name = "조범희", Password = "password", Email ="jo@gmail.com"},
            new User() { Id = 4, Name = "안성윤", Password = "password", Email ="an@gmail.com"},
            new User() { Id = 5, Name = "장동계", Password = "password", Email ="jang@gmail.com"},

        };
    }
}

﻿using Application.Persistences;
using Domain.Entities;
using Infrastructure.EFCore.EntityConfigurations;
using Infrastructure.EFCore.EntityInitialize;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Group> Groups { get; set; } = null!;
    public virtual DbSet<MemberUserGroup> MemberUserGroups { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("DM80")
               .ApplyConfiguration(new UserEntityConfiguration())
               .ApplyConfiguration(new GroupEntityConfiguration())
               .ApplyConfiguration(new MemberUserGroupEntityConfiguration());

        builder.HasUsers()
               .HasGroups()
               .HasMemberUserGroups();
    }
}

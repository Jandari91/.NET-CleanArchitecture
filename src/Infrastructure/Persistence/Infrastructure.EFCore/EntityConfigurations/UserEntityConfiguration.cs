using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EFCore.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasValueGenerator<GuidValueGenerator>();
        builder.Property(x => x.Name).HasMaxLength(30);
        builder.Property(x => x.Email).HasMaxLength(30);
        builder.Property(x => x.Password).HasMaxLength(15);
    }
}

using Api.Domain.Abstractions;
using Api.Domain.Aggregates.Users.ValueObjects;

namespace Api.Domain.Aggregates.Users;

public sealed class User : Entity<UserId>
{
    public UserId UserId { get; private set; }
    public UserName Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public bool IsActive { get; private set; }

    /// <summary>
    /// EF Core
    /// </summary>
    private User() { }

    private User(UserName name, Email email)
    {
        UserId = UserId.New();
        Name = name;
        Email = email;
        IsActive = true;
    }

    public static User Register(UserName name, Email email) => new(name, email);

}

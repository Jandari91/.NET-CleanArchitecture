using Application.Persistences;
using Infrastructure.EFCore.Repositories;

namespace CleanArchitecture.Extensions;

public static class RepositoryExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}


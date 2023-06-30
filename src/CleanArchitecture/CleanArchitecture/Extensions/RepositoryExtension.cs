using Application.Persistences;

namespace CleanArchitecture.Extensions;

public static class RepositoryExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, Infrastructure.EFCore.Repositories.UserRepository>();
        //services.AddScoped<IUserRepository, Infrastructure.MongoDB.Repositories.UserRepository>();
        return services;
    }
}


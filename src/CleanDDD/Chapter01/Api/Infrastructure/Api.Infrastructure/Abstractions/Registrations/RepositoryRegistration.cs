using Api.Domain.Repositories;
using Api.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure.Abstractions.Registrations;

public static class RepositoryRegistration
{
    public static IServiceCollection RegisterRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace Api.Application.Abstractions.Registrations;

public static class MediatorRegistration
{
    public static IServiceCollection RegisterMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));

        return services;
    }
}

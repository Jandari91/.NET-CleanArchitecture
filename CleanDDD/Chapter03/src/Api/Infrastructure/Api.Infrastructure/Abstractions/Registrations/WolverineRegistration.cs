using Api.Infrastructure.Messaging.Wolverines;
using Microsoft.Extensions.DependencyInjection;
using Shared.Adapter.Messaging;
using Wolverine;

namespace Api.Infrastructure.Abstractions.Registrations;


public static class WolverineRegistration
{
    public static IServiceCollection RegisterWolverine(this IServiceCollection services)
    {
        services.AddWolverine(opts =>
        {
            opts.Discovery.IncludeAssembly(typeof(Application.AssemblyReference).Assembly);
        });

        services.AddScoped<Shared.Adapter.Messaging.ICommandBus, WolverineCommandAdapter>();
        services.AddScoped<IQueryBus, WolverineQueryAdapter>();
        services.AddScoped<IDomainEventBus, WolverineDomainEventAdapter>();
        return services;
    }
}

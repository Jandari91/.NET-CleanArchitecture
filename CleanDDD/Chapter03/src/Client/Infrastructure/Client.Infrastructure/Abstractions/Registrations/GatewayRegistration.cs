using Client.Application.Abstractions.Ports;
using Client.Infrastructure.Gateways;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure.Abstractions.Registrations;

public static class GatewayRegistration
{
    public static IServiceCollection RegisterGateway(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeGateway, EmployeeGateway>();
        return services;
    }
}

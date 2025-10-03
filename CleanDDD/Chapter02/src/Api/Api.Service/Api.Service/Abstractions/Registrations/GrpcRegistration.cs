namespace Api.Service.Abstractions.Registrations;

public static class GrpcRegistration
{
    public static IServiceCollection RegisterGrpc(this IServiceCollection services)
    {
        services.AddGrpc();
        return services;
    }
}

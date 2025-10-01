using Google.Api;

namespace Api.Service.Abstractions.Registrations;

public static class GrpcRegistration
{
    public static IServiceCollection RegisterGrpc(this IServiceCollection services)
    {
        services.AddGrpc();
        services.AddGrpcSwagger();
        services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "gRPC Transcoding API",
                Version = "v1"
            });
        });
        return services;
    }
}

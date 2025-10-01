using Api.Service.Controllers;

namespace Api.Service.Abstractions.Registrations;

public static class SwaggerRegistration
{
    public static IServiceCollection RegisterSwagger(this IServiceCollection services)
    {
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

    public static IApplicationBuilder UsingSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "gRPC Transcoding API v1");
            // c.RoutePrefix = string.Empty; // 주석 해제하면 루트("/")에서 Swagger UI가 열립니다.
        });

        return app;
    }
}
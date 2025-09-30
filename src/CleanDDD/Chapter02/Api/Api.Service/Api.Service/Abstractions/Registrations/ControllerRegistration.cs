using Api.Service.Controllers;

namespace Api.Service.Abstractions.Registrations;

public static class ControllerRegistration
{
    public static IEndpointRouteBuilder MapGrpcControllers(this IEndpointRouteBuilder app)
    {
        app.MapGrpcService<UserController>();

        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        return app;
    }
}

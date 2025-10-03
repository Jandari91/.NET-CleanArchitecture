using Client.Infrastructure.Abstractions.Registrations;
using Client.Presentation.Abstractions.Registrations;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace Client.Test.Integration.Infra;

public class TestHostFactory : IAsyncLifetime, IDisposable
{
    private readonly Action<IServiceCollection>? _overrideServices;
    private readonly GrpcChannel _channel;
    private IHost? _host;

    public TestHostFactory(GrpcChannel channel, Action<IServiceCollection>? overrideServices = null)
    {
        _channel = channel;
        _overrideServices = overrideServices;
    }

    public IServiceProvider Services => _host?.Services
        ?? throw new InvalidOperationException("Host is not started yet.");

    public async Task InitializeAsync()
    {
        var builder = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services
                    .RegisterViewModels()
                    .RegisterGateway()
                    .RegisterWolverine()
                    .RegisterMockComponent();

                services.AddSingleton(_channel);

                _overrideServices?.Invoke(services);
            });

        _host = builder.Build();
        await _host.StartAsync();
    }

    public async Task DisposeAsync()
    {
        if (_host != null)
        {
            await _host.StopAsync();
            _host.Dispose();
        }
    }

    public void Dispose()
    {
        _host?.Dispose();
    }
}
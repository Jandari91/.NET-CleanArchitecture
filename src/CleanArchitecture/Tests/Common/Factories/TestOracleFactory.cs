using Common.Factories;
using DotNet.Testcontainers.Configurations;
using Grpc.Net.Client;
using Infrastructure.EFCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Testcontainers.Oracle;

namespace Common.Factories;

public class TestOracleFactory<TProgram, TDbContext> :
    WebApplicationFactory<TProgram>,
    ITestFactory<TProgram, TDbContext>
     where TProgram : class where TDbContext : DbContext
{
    private readonly OracleContainer _container;
    public GrpcChannel Channel => CreateChannel();


    public TestOracleFactory()
    {
        _container = new OracleBuilder()
            .WithEnvironment("APP_USER", "DM80")
            .WithEnvironment("ORACLE_PASSWORD", "DM80")
            .WithEnvironment("APP_USER_PASSWORD", "DM80")
            .Build();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveDbContext<TDbContext>();
            services.AddDbContextFactory<ApplicationDbContext>(option =>
            {
                var url = _container.GetConnectionString().Replace("oracle", "DM80");
                option.UseOracle(url,
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
            });
            services.EnsureDbCreated<ApplicationDbContext>();
        });
    }

    protected GrpcChannel CreateChannel()
    {
        return GrpcChannel.ForAddress("http://localhost", new GrpcChannelOptions
        {
            HttpHandler = Server.CreateHandler(),
            MaxReceiveMessageSize = 1024 * 1024 * 1566,
            MaxSendMessageSize = 1024 * 1024 * 1566,
        });
    }

    public async Task InitializeAsync()
    {
        await _container.StartAsync();
    }
    public new async Task DisposeAsync() => await _container.DisposeAsync();

    public IServiceScope CreateScope() => Services.CreateScope();
}

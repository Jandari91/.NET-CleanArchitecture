using Grpc.Net.Client;
using Infrastructure.EFCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Testcontainers.MsSql;

namespace Common.Factories;

internal class TestMsSqlFactory
{
}
public class TestMsSqlFactory<TProgram, TDbContext> :
    WebApplicationFactory<TProgram>,
    ITestFactory<TProgram, TDbContext>
     where TProgram : class where TDbContext : DbContext
{
    private readonly MsSqlContainer _container;
    public GrpcChannel Channel => CreateChannel();


    public TestMsSqlFactory()
    {
        _container = new MsSqlBuilder().Build();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveDbContext<TDbContext>();
            services.AddDbContextFactory<ApplicationDbContext>(option =>
            {
                var url = _container.GetConnectionString();
                option.UseSqlServer(url,
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

    public async Task InitializeAsync() => await _container.StartAsync();
    public new async Task DisposeAsync() => await _container.DisposeAsync();

    public IServiceScope CreateScope() => Services.CreateScope();
}
using Common.Factories;
using Grpc.Net.Client;
using Infrastructure.EFCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Testcontainers.PostgreSql;

namespace Common;

public class TestPostgreSqlFactory<TProgram, TDbContext> :
    WebApplicationFactory<TProgram>,
    ITestFactory<TProgram, TDbContext>
     where TProgram : class where TDbContext : DbContext
{
    private readonly PostgreSqlContainer _container;
    public GrpcChannel Channel => CreateChannel();


    public TestPostgreSqlFactory()
    {
        _container = new PostgreSqlBuilder()
            .WithDatabase("dm80")
            .WithUsername("mirero")
            .WithPassword("system")
            .WithEnvironment("TZ", "Asia/Seoul")
            .WithLabel("testContainer", "true")
            .WithImage("postgres:15.3")
            .Build();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveDbContext<TDbContext>();
            services.AddDbContextFactory<ApplicationDbContext>(option =>
            {
                var url = _container.GetConnectionString();
                option.UseNpgsql(url,
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
using Application.Persistences;
using Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitecture.Extensions;

public static class EFCoreExtension
{
    public static IServiceCollection AddEFCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IApplicationDbContext, ApplicationDbContext>();

        //services.AddPostgreSql(configuration);
        services.AddOracle(configuration);
        //services.AddMsSql(configuration);
        return services;
    }

    public static IServiceCollection AddPostgreSql(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<ApplicationDbContext>(option =>
        {
            var url = configuration.GetSection("PostgreSql").Value ?? configuration.GetConnectionString("PostgreSql");
            option.UseNpgsql(url,
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
        });
        return services;
    }

    public static IServiceCollection AddMsSql(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<ApplicationDbContext>(option =>
        {
            var url = configuration.GetSection("MsSql").Value ?? configuration.GetConnectionString("MsSql");
            option.UseSqlServer(url,
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
        });
        return services;
    }

    public static IServiceCollection AddOracle(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<ApplicationDbContext>(option =>
        {
            var url = configuration.GetSection("Oracle").Value ?? configuration.GetConnectionString("Oracle");
            option.UseOracle(url,
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
        });
        return services;
    }
}

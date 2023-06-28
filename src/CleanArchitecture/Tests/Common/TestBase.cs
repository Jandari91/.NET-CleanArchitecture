using Common.Factories;
using Infrastructure.EFCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Common;

public abstract class TestBase<TFactory> : IClassFixture<TFactory>
    where TFactory:class, new()
{
    public readonly ITestFactory<Program, ApplicationDbContext> Factory;
    public readonly ApplicationDbContext DbContext;

    public TestBase(TFactory factory)
    {
        Factory = (factory as ITestFactory<Program, ApplicationDbContext>)!;

        var scope = Factory.CreateScope();
        DbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
}
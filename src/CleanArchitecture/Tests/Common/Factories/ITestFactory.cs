using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Common.Factories;

public interface ITestFactory<TProgram, TDbContext> : IAsyncLifetime
    where TProgram : class where TDbContext : DbContext
{
    IServiceScope CreateScope();
}

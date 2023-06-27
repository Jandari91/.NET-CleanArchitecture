using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Common;

public class IntegratedTestBase : IClassFixture<IntegratedTestFactory<Program>>
{
    public readonly IntegratedTestFactory<Program> Factory;

    public IntegratedTestBase(IntegratedTestFactory<Program> factory)
    {
        Factory = factory;
    }
}
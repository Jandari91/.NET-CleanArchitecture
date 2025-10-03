using NetArchTest.Rules;
using static Shared.Test.Contracts.TestTypes;

namespace Client.Test.Unit.Architecture;

[Trait(nameof(UnitTest), UnitTest.Architecture)]
public sealed class CoreLayerDependencyTests
{
    [Fact]
    public void Domain_Should_Not_Depend_On_Application()
    {
        // Arrange & Act
        var result = Types.InAssembly(Domain.AssemblyReference.Assembly)
            .ShouldNot()
            .HaveDependencyOn(Application.AssemblyReference.Name)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Application_Should_Not_Depend_On_Infrastructure()
    {
        // Arrange & Act
        var result = Types.InAssembly(Application.AssemblyReference.Assembly)
            .ShouldNot()
            .HaveDependencyOn(Infrastructure.AssemblyReference.Name)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }
}

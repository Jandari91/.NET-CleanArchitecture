using NetArchTest.Rules;
using static Shared.Test.Contracts.TestTypes;

namespace Client.Test.Unit.Architecture;

[Trait(nameof(UnitTest), UnitTest.Architecture)]
public sealed class InfrastrucutreLayerDependencyTests
{
    [Fact]
    public void Infrastructure_Should_Not_Depend_On_Service()
    {
        // Arrange & Act
        var result = Types.InAssembly(Infrastructure.AssemblyReference.Assembly)
            .ShouldNot()
            .HaveDependencyOn(Presentation.AssemblyReference.Name)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }
}

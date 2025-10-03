using NetArchTest.Rules;
using static Shared.Test.Contracts.TestTypes;

namespace Api.Test.Unit.Architecture;

[Trait(nameof(UnitTest), UnitTest.Architecture)]
public sealed class InfrastrucutreLayerDependencyTests
{
    [Fact]
    public void Infrastructure_Should_Not_Depend_On_Service()
    {
        // Arrange & Act
        var result = Types.InAssembly(Infrastructure.AssemblyReference.Assembly)
            .ShouldNot()
            .HaveDependencyOn(Service.AssemblyReference.Name)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }
}

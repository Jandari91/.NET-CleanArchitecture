using NetArchTest.Rules;
using static Shared.Test.Contracts.TestTypes;

namespace Client.Test.Unit.Architecture;

[Trait(nameof(UnitTest), UnitTest.Architecture)]
public sealed class PresentationLayerDependencyTests
{
    [Fact]
    public void Service_Should_Not_Depend_On_Infrastructure_Except_Program()
    {
        // Arrange & Act
        var result = Types.InAssembly(Presentation.AssemblyReference.Assembly)
            .ShouldNot()
            .HaveDependencyOn(Infrastructure.AssemblyReference.Name)
            .GetResult();


        // Assert
        Assert.True(result.IsSuccessful);
    }
}

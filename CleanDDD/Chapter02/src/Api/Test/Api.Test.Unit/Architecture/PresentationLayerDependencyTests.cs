using NetArchTest.Rules;
using static Shared.Test.Contracts.TestTypes;

namespace Api.Test.Unit.Architecture;

[Trait(nameof(UnitTest), UnitTest.Architecture)]
public sealed class PresentationLayerDependencyTests
{
    [Fact]
    public void Service_Should_Not_Depend_On_Infrastructure_Except_Program()
    {
        // Arrange & Act
        var result = Types.InAssembly(Service.AssemblyReference.Assembly)
            .ShouldNot()
            .HaveDependencyOn(Infrastructure.AssemblyReference.Name)
            .GetResult();

        var illegal = result.FailingTypeNames
            .Where(name => !string.Equals(name, "Program", StringComparison.Ordinal)
                           && !name.EndsWith(".Program", StringComparison.Ordinal))
            .ToList();

        // Assert
        Assert.NotNull(illegal);
        Assert.Empty(illegal);
    }
}

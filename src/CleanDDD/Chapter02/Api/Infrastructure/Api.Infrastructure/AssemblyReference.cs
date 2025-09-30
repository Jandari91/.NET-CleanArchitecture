using System.Reflection;

namespace Api.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    public static readonly string Name = Assembly.GetName().Name!;
}
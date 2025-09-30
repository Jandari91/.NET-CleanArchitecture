using System.Reflection;

namespace Client.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    public static readonly string Name = Assembly.GetName().Name!;
}

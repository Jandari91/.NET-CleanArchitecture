using System.Windows.Markup;

namespace Client.UI.Abstractions.Markups;

public class DependencySource : MarkupExtension
{
    public static Func<Type, object, string, object> Resolver { get; set; } = default!;

    public Type Type { get; set; } = default!;
    public object Key { get; set; } = default!;
    public string Name { get; set; } = string.Empty;

    public override object ProvideValue(IServiceProvider serviceProvider) => Resolver.Invoke(Type, Key, Name);
}

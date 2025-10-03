using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Input;

namespace Client.UI.Behaviors;

public class LoadedBehavior : Behavior<FrameworkElement>
{
    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(LoadedBehavior));

    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    protected override void OnAttached()
    {
        AssociatedObject.Loaded += OnLoaded;
        base.OnAttached();
    }

    protected override void OnDetaching()
    {
        AssociatedObject.Loaded -= OnLoaded;
        base.OnDetaching();
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (Command != null && Command.CanExecute(null))
        {
            Command.Execute(null);
        }
    }
}

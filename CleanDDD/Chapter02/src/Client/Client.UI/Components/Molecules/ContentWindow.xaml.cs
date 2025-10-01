using System.Windows;

namespace Client.UI.Components.Molecules;

public partial class ContentWindow
{
    public ContentWindow(string title)
    {
        InitializeComponent();
        WindowName.Title = title;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Dispatcher.BeginInvoke(new Action(() =>
        {
            SizeToContent = SizeToContent.Manual;
            SizeToContent = SizeToContent.WidthAndHeight;
        }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
    }
}

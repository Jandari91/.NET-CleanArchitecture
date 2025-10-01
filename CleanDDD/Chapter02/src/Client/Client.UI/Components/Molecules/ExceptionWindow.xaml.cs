using System.Windows;

namespace Client.UI.Components.Molecules;

public partial class ExceptionWindow
{
    public ExceptionWindow(Exception ex)
    {
        InitializeComponent();

        FromException(ex);
    }

    private void FromException(Exception ex)
    {
        if (ex.InnerException is null || ex is AggregateException)
        {
            ExMessage.Text = ex.Message;
            ExTrace.Text = ex.StackTrace;
        }
        else
        {
            ExMessage.Text = ex.InnerException.Message;
            ExTrace.Text = ex.InnerException.StackTrace;
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}

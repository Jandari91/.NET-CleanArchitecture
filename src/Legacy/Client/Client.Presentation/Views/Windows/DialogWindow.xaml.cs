namespace Client.Presentation.Views.Windows;

/// <summary>
/// DialogWindow.xaml에 대한 상호 작용 논리
/// </summary>
public partial class DialogWindow
{
    public DialogWindow()
    {
        InitializeComponent();
    }

    private void Ok_Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void Cancel_Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}

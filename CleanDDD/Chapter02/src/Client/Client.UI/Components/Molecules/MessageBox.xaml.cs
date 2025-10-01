using Client.Presentation.Abstractions.Contracts;
using System.Windows;
using System.Windows.Threading;

namespace Client.UI.Components.Molecules;

public partial class MessageBox
{
    public MessageResult Result { get; private set; }
    public MessageBox()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Dispatcher.BeginInvoke(new Action(() =>
        {
            SizeToContent = SizeToContent.Manual;
            SizeToContent = SizeToContent.WidthAndHeight;
        }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
    }

    private void ConfigureButtons(MessageButton button)
    {
        switch (button)
        {
            case MessageButton.OKCancel:
                YesButton.Visibility = Visibility.Collapsed;
                NoButton.Visibility = Visibility.Collapsed;
                break;
            case MessageButton.OK:
                YesButton.Visibility = Visibility.Collapsed;
                NoButton.Visibility = Visibility.Collapsed;
                CancelButton.Visibility = Visibility.Collapsed;
                break;
            case MessageButton.YesNo:
                OkButton.Visibility = Visibility.Collapsed;
                CancelButton.Visibility = Visibility.Collapsed;
                break;
            case MessageButton.YesNoCancel:
                OkButton.Visibility = Visibility.Collapsed;
                break;
        }
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        Result = MessageResult.OK;
        Close();
    }

    private void YesButton_Click(object sender, RoutedEventArgs e)
    {
        Result = MessageResult.Yes;
        Close();
    }

    private void NoButton_Click(object sender, RoutedEventArgs e)
    {
        Result = MessageResult.No;
        Close();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        Result = MessageResult.Cancel;
        Close();
    }

    public MessageResult Show(string caption = "", string messageBoxText = "", MessageButton button = MessageButton.OK, MessageIcon icon = MessageIcon.None, MessageResult defaultResult = MessageResult.OK)
    {
        ConfigureButtons(button);
        MessageText.Text = messageBoxText;
        titleBarName.Title = caption;
        ShowDialog();
        return Result;
    }
}

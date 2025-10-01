using Client.Presentation.Abstractions.Contracts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Client.UI.Components.Molecules;

public partial class ContentDialog
{
    public MessageResult DialogResultValue { get; private set; } = MessageResult.None;

    public ContentDialog(MessageButton buttons, string title)
    {
        InitializeComponent();
        CreateButtons(buttons);
        WindowName.Title = title;
    }
    private void CreateButtons(MessageButton buttons)
    {
        switch (buttons)
        {
            case MessageButton.OK:
                AddButton("OK", MessageResult.OK, true);
                break;
            case MessageButton.OKCancel:
                AddButton("OK", MessageResult.OK, true);
                AddButton("Cancel", MessageResult.Cancel, false);
                break;
            case MessageButton.YesNo:
                AddButton("Yes", MessageResult.Yes, true);
                AddButton("No", MessageResult.No, false);
                break;
            case MessageButton.YesNoCancel:
                AddButton("Yes", MessageResult.Yes, true);
                AddButton("No", MessageResult.No, false);
                AddButton("Cancel", MessageResult.Cancel, false);
                break;
        }
    }

    private Wpf.Ui.Controls.ControlAppearance GetAppearance(MessageResult result)
    {
        switch (result)
        {
            case MessageResult.OK:
                return Wpf.Ui.Controls.ControlAppearance.Primary;
            case MessageResult.Yes:
                return Wpf.Ui.Controls.ControlAppearance.Primary;
            case MessageResult.No:
                return Wpf.Ui.Controls.ControlAppearance.Secondary;
            case MessageResult.Cancel:
                return Wpf.Ui.Controls.ControlAppearance.Secondary;
            default:
                return Wpf.Ui.Controls.ControlAppearance.Secondary;
        }
    }

    private void AddButton(string content, MessageResult result, bool applyValidation)
    {
        var button = new Atoms.Button
        {
            Content = content,
            Margin = new Thickness(5, 0, 5, 0),
            MinWidth = 75,
            Appearance = GetAppearance(result)
        };

        button.Click += (s, e) => Button_Click(result);

        if (applyValidation)
        {
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(100)
            };

            dispatcherTimer.Tick += (s, e) =>
            {
                var hasErrors = CheckValidationErrors(ContentPanel);
                button.IsEnabled = !hasErrors;
            };

            dispatcherTimer.Start();
        }

        ButtonPanel.Children.Add(button);
    }

    private bool CheckValidationErrors(DependencyObject parent)
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (Validation.GetHasError(child))
                return true;
            if (CheckValidationErrors(child))
                return true;
        }
        return false;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Dispatcher.BeginInvoke(new Action(() =>
        {
            SizeToContent = SizeToContent.Manual;
            SizeToContent = SizeToContent.WidthAndHeight;
        }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
    }

    private void Button_Click(MessageResult result)
    {
        DialogClose(result);
    }

    private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == System.Windows.Input.Key.Escape)
        {
            DialogClose(MessageResult.Cancel);
        }
    }

    private void DialogClose(MessageResult result)
    {
        Dispatcher.BeginInvoke(new Action(() =>
        {
            DialogResultValue = result;
            DialogResult = true;
            Close();
        }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
    }
}

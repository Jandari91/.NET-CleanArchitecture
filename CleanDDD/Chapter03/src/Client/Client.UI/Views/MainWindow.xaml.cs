namespace Client.UI.Views;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        Loaded += (_, __) => NavigationView.Navigate(typeof(Employee.EmployeeView));
    }
}
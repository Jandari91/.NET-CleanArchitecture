using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.Presentation.ViewModels.Employee
{
    public partial class EmployeeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title = "Employee";

        public EmployeeViewModel()
        {
            
        }
    }
}

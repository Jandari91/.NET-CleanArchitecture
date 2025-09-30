using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.Presentation.ViewModels.User
{
    public partial class UserViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title = "User";

        public UserViewModel()
        {
            
        }
    }
}

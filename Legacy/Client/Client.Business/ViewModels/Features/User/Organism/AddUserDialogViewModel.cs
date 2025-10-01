using Client.Business.Core.Application.Mvvm;
using Client.Business.Core.Domain.Models.Users;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace Client.Business.ViewModels.Features.User.Organism;

public partial class AddUserDialogViewModel : ObservableObject, IDialogBase
{

    [ObservableProperty]
    private UserModel _userModel;
    private bool _isValid = false;
    public bool IsValid
    { 
        get => _isValid;
    }

    public AddUserDialogViewModel(UserModel userModel)
    {
        _userModel = userModel;
        
        _userModel.ErrorsChanged += (sender, e) =>
         {
             _isValid = !_userModel.HasErrors;
             OnPropertyChanged(nameof(IsValid));
         };

        _userModel.Name = string.Empty;
        _userModel.Email = string.Empty;
        _userModel.Password = string.Empty;
    }
}

    

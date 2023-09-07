using Client.Business.Core.Application.Dialogs;
using Client.Business.Core.Application.Features.Users.Commands;
using Client.Business.Core.Application.Features.Users.Queries;
using Client.Business.Core.Domain.Models.Users;
using Client.Business.ViewModels.Features.User.Organism;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using System.Collections.ObjectModel;

namespace Client.Business.Extensions.ViewModels.Features.User;

public partial class UserViewModel : ObservableObject
{
    [ObservableProperty]
    public IEnumerable<UserModel> _users;

    private readonly IMediator _mediator;
    private readonly IDialogService _dialogService;
    public UserViewModel(IMediator mediator, IDialogService dialogService)
    {
        _mediator = mediator;
        _dialogService = dialogService;
        Users = new ObservableCollection<UserModel>();
    }

    [RelayCommand]
    private async Task LoadUsersAsync() => await _mediator.Send(new GetAllUsersQuery()).IfSomeAsync(r => Users = r);

    [RelayCommand]
    private void AddNewUser()
    {
        var newUserModel = new UserModel();
        _dialogService.Show<AddUserDialogViewModel>(new AddUserDialogViewModel(newUserModel), result => 
        result.IfSomeAsync(async _ =>
        {
            var result = await _mediator.Send(new CreateUserCommand(newUserModel));
            await LoadUsersAsync();
        }));
    }
}

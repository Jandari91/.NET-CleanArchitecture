using Client.Business.Extensions.ViewModels.Features.User;
using Client.Business.ViewModels.Features.User.Organism;
using System.Windows;
using Wpf.Ui.Controls;

namespace Client.Presentation.Views.Features.Users.Organism;

/// <summary>
/// AddUserDialog.xaml에 대한 상호 작용 논리
/// </summary>
public partial class AddUserDialogView : INavigableView<AddUserDialogViewModel>
{
    public AddUserDialogViewModel ViewModel { get; } = default!;
    public AddUserDialogView(AddUserDialogViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }
}

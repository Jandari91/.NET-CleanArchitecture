using Client.Business.Core.Application.Mvvm;
using LanguageExt;

namespace Client.Business.Core.Application.Dialogs;

public interface IDialogService
{
    void Show<ViewModel>(IDialogBase viewModel, Action<Option<bool>> callback);
}

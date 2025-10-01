using Client.Presentation.Abstractions.Contracts;

namespace Client.Presentation.Abstractions.Dialogs;

public interface IDialogService
{
    Task<MessageResult> ShowDialogAsync<TViewModel>(
        TViewModel viewModel,
        MessageButton buttons,
        Type? viewType = default,
        string title = "Dialog") where TViewModel : class;
}

namespace Client.Presentation.Abstractions.Dialogs;

public interface IWindowService
{
    Task ShowWindowAsync<TViewModel>(
        TViewModel viewModel,
        Type? viewType = default,
        string title = "Windows") where TViewModel : class;
}
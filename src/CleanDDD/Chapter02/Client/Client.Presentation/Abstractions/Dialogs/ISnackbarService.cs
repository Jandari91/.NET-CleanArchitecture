namespace Client.Presentation.Abstractions.Dialogs;

public interface ISnackbarService
{
    void Success(string title, string message, TimeSpan timeout = default);
    void Info(string title, string message, TimeSpan timeout = default);
    void Warning(string title, string message, TimeSpan timeout = default);
    void Error(string title, string message, TimeSpan timeout = default);
    Task SuccessAsync(string title, string message, TimeSpan timeout = default);
    Task InfoAsync(string title, string message, TimeSpan timeout = default);
    Task WarningAsync(string title, string message, TimeSpan timeout = default);
    Task ErrorAsync(string title, string message, TimeSpan timeout = default);
}
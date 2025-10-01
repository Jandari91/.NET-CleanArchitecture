using Client.Presentation.Abstractions.Contracts;

namespace Client.Presentation.Abstractions.Dialogs;

public interface IMessageBoxService
{
    MessageResult ShowMessage(string messageBoxText);
    MessageResult ShowMessage(string messageBoxText, string caption);
    MessageResult ShowMessage(string messageBoxText, string caption, MessageButton button);
    MessageResult ShowMessage(string messageBoxText, string caption, MessageButton button, MessageIcon icon);
    MessageResult ShowMessage(string messageBoxText, string caption, MessageButton button, MessageIcon icon, MessageResult defaultResult);

    Task<MessageResult> ShowMessageAsync(string messageBoxText);
    Task<MessageResult> ShowMessageAsync(string messageBoxText, string caption);
    Task<MessageResult> ShowMessageAsync(string messageBoxText, string caption, MessageButton button);
    Task<MessageResult> ShowMessageAsync(string messageBoxText, string caption, MessageButton button, MessageIcon icon);
    Task<MessageResult> ShowMessageAsync(string messageBoxText, string caption, MessageButton button, MessageIcon icon, MessageResult defaultResult);
}
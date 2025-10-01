using Client.Presentation.Abstractions.Contracts;
using Client.Presentation.Abstractions.Dialogs;
using Client.UI.Components.Molecules;

namespace Client.UI.Abstractions.Dialogs;

internal class MessageBoxService : IMessageBoxService
{
    public MessageResult ShowMessage(string messageBoxText)
            => new MessageBox().Show(messageBoxText);

    public MessageResult ShowMessage(string messageBoxText, string caption)
        => new MessageBox().Show(caption, messageBoxText);

    public MessageResult ShowMessage(string messageBoxText, string caption, MessageButton button)
        => new MessageBox().Show(caption, messageBoxText, button);

    public MessageResult ShowMessage(string messageBoxText, string caption, MessageButton button, MessageIcon icon)
        => new MessageBox().Show(caption, messageBoxText, button, icon);

    public MessageResult ShowMessage(string messageBoxText, string caption, MessageButton button, MessageIcon icon, MessageResult defaultResult)
    {
        new MessageBox().Show(caption, messageBoxText, button, icon);
        return defaultResult;
    }

    public async Task<MessageResult> ShowMessageAsync(string messageBoxText)
    => await System.Windows.Application.Current.Dispatcher.InvokeAsync(() => ShowMessage(messageBoxText));

    public async Task<MessageResult> ShowMessageAsync(string messageBoxText, string caption)
        => await System.Windows.Application.Current.Dispatcher.InvokeAsync(() => ShowMessage(messageBoxText, caption));

    public async Task<MessageResult> ShowMessageAsync(string messageBoxText, string caption, MessageButton button)
        => await System.Windows.Application.Current.Dispatcher.InvokeAsync(() => ShowMessage(messageBoxText, caption, button));

    public async Task<MessageResult> ShowMessageAsync(string messageBoxText, string caption, MessageButton button, MessageIcon icon)
        => await System.Windows.Application.Current.Dispatcher.InvokeAsync(() => ShowMessage(messageBoxText, caption, button, icon));

    public async Task<MessageResult> ShowMessageAsync(string messageBoxText, string caption, MessageButton button, MessageIcon icon, MessageResult defaultResult)
        => await System.Windows.Application.Current.Dispatcher.InvokeAsync(() => ShowMessage(messageBoxText, caption, button, icon, defaultResult));
}

using Client.Presentation.Abstractions.Dialogs;
using Client.UI.Components.Molecules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.UI.Abstractions.Dialogs;

internal class ExceptionService : IExceptionService
{
    public async Task ShowExceptionAsync(Exception e)
        => await System.Windows.Application.Current.Dispatcher.InvokeAsync(() =>
        {
            var exceptionWindow = new ExceptionWindow(e);
            exceptionWindow.ShowDialog();
        });
}

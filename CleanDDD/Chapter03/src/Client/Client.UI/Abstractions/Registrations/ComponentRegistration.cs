using Client.Presentation.Abstractions.Dialogs;
using Client.UI.Abstractions.Dialogs;
using Microsoft.Extensions.DependencyInjection;


namespace Client.UI.Abstractions.Registrations;

public static class ComponentRegistration
{
    public static IServiceCollection RegisterComponent(this IServiceCollection services)
        => services.AddTransient<IDialogService, DialogService>()
                   .AddTransient<IWindowService, WindowService>()
                   .AddTransient<IExceptionService, ExceptionService>()
                   .AddTransient<ISaveDialogService, SaveDialogService>()
                   .AddTransient<IFileDialogService, FileDialogService>()
                   .AddTransient<IMessageBoxService, MessageBoxService>()
                   .AddTransient<IFolderDialogService, FolderDialogService>();
}

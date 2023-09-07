using Client.Business.Core.Application.Dialogs;
using Client.Presentation.Services;
using Client.Presentation.Views.Features.Users.Organism;
using Client.Presentation.Views.Pages;
using Client.Presentation.Views.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Presentation.Extentions;

public static class ViewExtension
{
    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<SettingsMenuPage>();
        services.AddSingleton<UserMenuPage>();
        services.AddSingleton<GroupMenuPage>();

        services.AddSingleton<AddUserDialogView>();
        return services;
    }

    public static IServiceCollection AddDailogs(this IServiceCollection services)
    {
        services.AddSingleton<IDialogService, DialogService>();
        return services;
    }
}

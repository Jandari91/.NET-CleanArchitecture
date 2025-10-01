using Microsoft.Extensions.DependencyInjection;
using Wpf.Ui;

namespace Client.UI.Abstractions.Registrations;

public static class WpfUIRegistration
{
    public static IServiceCollection RegisterWpfUI(this IServiceCollection services)
    {
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IContentDialogService, ContentDialogService>();
        services.AddSingleton<IThemeService, ThemeService>();
        return services;
    }
}

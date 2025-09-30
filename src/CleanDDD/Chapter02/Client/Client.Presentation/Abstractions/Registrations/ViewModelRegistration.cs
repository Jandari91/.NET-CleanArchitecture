using Client.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Presentation.Abstractions.Registrations;

public static class ViewModelRegistration
{
    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        => services.AddSingleton<MainViewModel>();
}

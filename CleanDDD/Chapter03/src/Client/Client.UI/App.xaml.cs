using Api.Infrastructure.Abstractions.Registrations;
using Client.Application.Abstractions.Registrations;
using Client.Presentation.Abstractions.Registrations;
using Client.UI.Abstractions.Markups;
using Client.UI.Abstractions.Registrations;
using Client.UI.Components.Molecules;
using Client.UI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Client.Infrastructure.Abstractions.Registrations;
using System.Windows;

namespace Client.UI;

public partial class App : System.Windows.Application
{
    private static IHost _host = default!;
    object Resolve(Type type, object key, string name) => _host.Services.GetService(type) ?? default!;
    private static IHost CreateHost() => Host
        .CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .AddEnvironmentVariables()
            .Build();

            services.RegisterWpfUI()
                    .RegisterMediator()
                    .RegisterViewModels()
                    .RegisterGateway()
                    .RegisterWolverine()
                    .RegisterGrpc(configuration)
                    .RegisterComponent();
        }).Build();

    protected async void OnStartupAsync(object sender, StartupEventArgs e)
    {
        _host = CreateHost();
        DependencySource.Resolver = Resolve;

        AppDomain.CurrentDomain.UnhandledException += (s, args) =>
        {
            HandleUnhandledException(args.ExceptionObject as Exception);
        };

        var mainWindow = new MainWindow();
        mainWindow.Show();
        await _host.StartAsync();
    }

    protected async void OnExitAsync(object sender, ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();
    }

    private void HandleUnhandledException(Exception? exception)
    {
        if (exception == null) return;

        Console.Error.WriteLine($"Unhandled exception: {exception.Message}");
        System.Windows.Application.Current.Dispatcher.Invoke(() =>
        {
            var exceptionWindow = new ExceptionWindow(exception);
            exceptionWindow.ShowDialog();
        });
    }
}

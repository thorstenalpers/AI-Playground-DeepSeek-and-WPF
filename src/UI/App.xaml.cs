using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using DeepSeek.WPF.Core.Contracts.Services;
using DeepSeek.WPF.Core.Services;
using DeepSeek.WPF.UI.Contracts.Services;
using DeepSeek.WPF.UI.Contracts.Views;
using DeepSeek.WPF.UI.Models;
using DeepSeek.WPF.UI.Services;
using DeepSeek.WPF.UI.ViewModels;
using DeepSeek.WPF.UI.Views;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DeepSeek.WPF.UI;

public partial class App : Application
{
    private IHost _host;

    public T GetService<T>()
        where T : class
        => _host.Services.GetService(typeof(T)) as T;

    public App()
    {
    }

    private async void OnStartup(object sender, StartupEventArgs e)
    {
        var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        // For more information about .NET generic host see  https://docs.microsoft.com/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.0
        _host = Host.CreateDefaultBuilder(e.Args)
                .ConfigureAppConfiguration(c =>
                {
                    c.SetBasePath(appLocation);
                })
                .ConfigureServices(ConfigureServices)
                .Build();

        await _host.StartAsync();
    }

    internal static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        // App Host
        services.AddHostedService<ApplicationHostService>();

        // Activation Handlers

        // Core Services
        services.AddSingleton<IFileService, FileService>();

        // Services
        services.AddSingleton<IApplicationInfoService, ApplicationInfoService>();
        services.AddSingleton<IPersistAndRestoreService, PersistAndRestoreService>();
        services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
        services.AddSingleton<IPageService, PageService>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IAiMessageService, AiMessageService>();

        // Views and ViewModels
        services.AddTransient<IShellWindow, ShellWindow>();
        services.AddTransient<ShellViewModel>();

        services.AddTransient<OllamaViewModel>();
        services.AddTransient<OllamaPage>();

        services.AddTransient<OpenWebUiViewModel>();
        services.AddTransient<OpenWebUiPage>();

        services.AddTransient<SettingsViewModel>();
        services.AddTransient<SettingsPage>();

        services.AddHttpClient();

        // Configuration
        services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
    }

    private async void OnExit(object sender, ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();
        _host = null;
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        Console.WriteLine(e.Exception);
    }
}

using System.Reflection;
using DeepSeek.WPF.Core.Contracts.Services;
using DeepSeek.WPF.Core.Services;
using DeepSeek.WPF.UI.Contracts.Services;
using DeepSeek.WPF.UI.Models;
using DeepSeek.WPF.UI.Services;
using DeepSeek.WPF.UI.ViewModels;
using DeepSeek.WPF.UI.Views;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NUnit.Framework;

namespace DeepSeek.WPF.Tests;

[Category("Unit")]
public class PagesTests
{
    private IHost _host;

    [SetUp]
    public void Setup()
    {
        var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
        _host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => c.SetBasePath(appLocation))
            .ConfigureServices(ConfigureServices)
            .Build();
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        // Core Services
        services.AddSingleton<IFileService, FileService>();

        // Services
        services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
        services.AddSingleton<ISystemService, SystemService>();
        services.AddSingleton<IPersistAndRestoreService, PersistAndRestoreService>();
        services.AddSingleton<IApplicationInfoService, ApplicationInfoService>();
        services.AddSingleton<IPageService, PageService>();
        services.AddSingleton<INavigationService, NavigationService>();

        // ViewModels
        services.AddTransient<WebViewViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<MainViewModel>();

        // Configuration
        services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
    }

    // TODO: Add tests for functionality you add to WebViewViewModel.
    [Test]
    public void TestWebViewViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(WebViewViewModel));
        Assert.That(vm, Is.Not.Null);
    }

    [Test]
    public void TestGetWebViewPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(WebViewViewModel).FullName);
            Assert.That(typeof(WebViewPage), Is.EqualTo(pageType));
        }
        else
        {
            Assert.Fail($"Can't resolve {nameof(IPageService)}");
        }
    }

    // TODO: Add tests for functionality you add to SettingsViewModel.
    [Test]
    public void TestSettingsViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(SettingsViewModel));
        Assert.That(vm, Is.Not.Null);
    }

    [Test]
    public void TestGetSettingsPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(SettingsViewModel).FullName);
            Assert.That(typeof(SettingsPage), Is.EqualTo(pageType));
        }
        else
        {
            Assert.Fail($"Can't resolve {nameof(IPageService)}");
        }
    }

    // TODO: Add tests for functionality you add to MainViewModel.
    [Test]
    public void TestMainViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(MainViewModel));
        Assert.That(vm, Is.Not.Null);
    }

    [Test]
    public void TestGetMainPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(MainViewModel).FullName);
            Assert.That(typeof(MainPage), Is.EqualTo(pageType));
        }
        else
        {
            Assert.Fail($"Can't resolve {nameof(IPageService)}");
        }
    }
}

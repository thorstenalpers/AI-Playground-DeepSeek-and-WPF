using System.Reflection;
using AiPlayground.Core.Contracts.Services;
using AiPlayground.Core.Services;
using AiPlayground.UI.Contracts.Services;
using AiPlayground.UI.Models;
using AiPlayground.UI.Services;
using AiPlayground.UI.ViewModels;
using AiPlayground.UI.Views;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NUnit.Framework;

namespace AiPlayground.Tests;

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
        services.AddSingleton<IPersistAndRestoreService, PersistAndRestoreService>();
        services.AddSingleton<IApplicationInfoService, ApplicationInfoService>();
        services.AddSingleton<IPageService, PageService>();
        services.AddSingleton<INavigationService, NavigationService>();

        // ViewModels
        services.AddTransient<OpenWebUiViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<OllamaViewModel>();

        // Configuration
        services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
    }

    // TODO: Add tests for functionality you add to WebViewViewModel.
    [Test]
    public void TestWebViewViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(OpenWebUiViewModel));
        Assert.That(vm, Is.Not.Null);
    }

    [Test]
    public void TestGetOpenWebUiPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(OpenWebUiViewModel).FullName);
            Assert.That(typeof(OpenWebUiPage), Is.EqualTo(pageType));
        }
        else
        {
            Assert.Fail($"Can't resolve {nameof(IPageService)}");
        }
    }

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
        var vm = _host.Services.GetService(typeof(OllamaViewModel));
        Assert.That(vm, Is.Not.Null);
    }

    [Test]
    public void TestGetOllamaPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(OllamaViewModel).FullName);
            Assert.That(typeof(OllamaPage), Is.EqualTo(pageType));
        }
        else
        {
            Assert.Fail($"Can't resolve {nameof(IPageService)}");
        }
    }
}

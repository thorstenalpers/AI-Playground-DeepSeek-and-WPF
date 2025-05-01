using DeepSeek.WPF.UI.Contracts.Services;
using DeepSeek.WPF.UI.Models;
using DeepSeek.WPF.UI.ViewModels;

using Microsoft.Extensions.Options;

using Moq;

using NUnit.Framework;

namespace DeepSeek.WPF.Tests;

[Category("Unit")]
public class SettingsViewModelTests
{
	public SettingsViewModelTests()
	{
	}

	[Test]
	public void TestSettingsViewModel_SetCurrentTheme()
	{
		Mock<IThemeSelectorService> mockThemeSelectorService = new();
		mockThemeSelectorService.Setup(mock => mock.GetCurrentTheme()).Returns(AppTheme.Light);
		Mock<IOptions<AppConfig>> mockAppConfig = new();
		Mock<ISystemService> mockSystemService = new();
		Mock<IApplicationInfoService> mockApplicationInfoService = new();

		SettingsViewModel settingsVm = new(mockAppConfig.Object, mockThemeSelectorService.Object, mockSystemService.Object, mockApplicationInfoService.Object);
		settingsVm.OnNavigatedTo(null);

		Assert.That(AppTheme.Light, Is.EqualTo(settingsVm.Theme));
	}

	[Test]
	public void TestSettingsViewModel_SetCurrentVersion()
	{
		Mock<IThemeSelectorService> mockThemeSelectorService = new();
		Mock<IOptions<AppConfig>> mockAppConfig = new();
		Mock<ISystemService> mockSystemService = new();
		Mock<IApplicationInfoService> mockApplicationInfoService = new();
		Version testVersion = new(1, 2, 3, 4);
		mockApplicationInfoService.Setup(mock => mock.GetVersion()).Returns(testVersion);

		SettingsViewModel settingsVm = new(mockAppConfig.Object, mockThemeSelectorService.Object, mockSystemService.Object, mockApplicationInfoService.Object);
		settingsVm.OnNavigatedTo(null);

		Assert.That($"DeepSeek.WPF - {testVersion}", Is.EqualTo(settingsVm.VersionDescription));
	}

	[Test]
	public void TestSettingsViewModel_SetThemeCommand()
	{
		Mock<IThemeSelectorService> mockThemeSelectorService = new();
		Mock<IOptions<AppConfig>> mockAppConfig = new();
		Mock<ISystemService> mockSystemService = new();
		Mock<IApplicationInfoService> mockApplicationInfoService = new();

		SettingsViewModel settingsVm = new(mockAppConfig.Object, mockThemeSelectorService.Object, mockSystemService.Object, mockApplicationInfoService.Object);
		settingsVm.SetThemeCommand.Execute(AppTheme.Light.ToString());

		mockThemeSelectorService.Verify(mock => mock.SetTheme(AppTheme.Light));
	}
}

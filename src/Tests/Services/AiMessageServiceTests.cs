using System.Reflection;
using AiPlayground.Core.Contracts.Services;
using AiPlayground.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace AiPlayground.Tests.Services;

[TestFixture]
[Category("Integration")]
public class AiMessageServiceTests
{
    private IAiMessageService _aiMessageService;

    [SetUp]
    public void SetUp()
    {

        var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        var _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(c =>
                {
                    c.SetBasePath(appLocation);
                })
                .ConfigureServices(App.ConfigureServices)
                .Build();
        _aiMessageService = _host.Services.GetRequiredService<IAiMessageService>();
    }

    [Test]
    public async Task SendPromptViaHttpAsync_WithValidEntries_ReturnsResult()
    {
        // Arrange
        var prompt = "Hi";

        var model = "llama3";

        // Act
        var result = await _aiMessageService.SendPromptViaHttpAsync(model, prompt);

        // Assert
        Assert.That(result, Is.Not.Empty);
        Console.WriteLine(result);
    }

    [Test]
    public async Task SendPromptViaLibraryAsync_WithValidEntries_ReturnsResult()
    {
        // Arrange
        var prompt = "Hi";
        var model = "llama3";

        // Act
        var result = await _aiMessageService.SendPromptViaLibraryAsync(model, prompt);

        // Assert
        Assert.That(result, Is.Not.Empty);
        Console.WriteLine(result);
    }
}

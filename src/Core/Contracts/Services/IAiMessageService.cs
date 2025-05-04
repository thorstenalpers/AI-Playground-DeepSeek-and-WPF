namespace DeepSeek.WPF.Core.Contracts.Services;

public interface IAiMessageService
{
    Task<string> SendPromptViaHttpAsync(string prompt);
    Task<string> SendPromptViaLibraryAsync(string prompt);
}

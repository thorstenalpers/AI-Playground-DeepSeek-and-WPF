namespace DeepSeek.WPF.Core.Contracts.Services;

public interface IAiMessageService
{
    Task<string> SendPromptViaHttpAsync(string model, string prompt);
    Task<string> SendPromptViaLibraryAsync(string model, string prompt);
}

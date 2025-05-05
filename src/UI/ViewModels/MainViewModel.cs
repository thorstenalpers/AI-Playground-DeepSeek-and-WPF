using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeepSeek.WPF.Core.Contracts.Services;

namespace DeepSeek.WPF.UI.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IAiMessageService _aiMessageService;
    public MainViewModel(IAiMessageService aiMessageService)
    {
        _aiMessageService = aiMessageService;
    }

    [ObservableProperty]
    private string userInput;

    [ObservableProperty]
    private string output;

    [RelayCommand]
    private async Task SendAsync()
    {
        Output = string.Empty;

        if (string.IsNullOrWhiteSpace(UserInput))
        {
            Output = "Please enter a question.";
            return;
        }
        var result = await _aiMessageService.SendPromptViaLibraryAsync(UserInput);
        Output = result;
    }
}

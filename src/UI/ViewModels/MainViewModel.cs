using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeepSeek.WPF.Core.Contracts.Services;

namespace DeepSeek.WPF.UI.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IAiMessageService _aiMessageService;
    private ObservableCollection<string> _availableModels;
    private string _selectedModel;

    public MainViewModel(IAiMessageService aiMessageService)
    {
        _aiMessageService = aiMessageService;
        AvailableModels = ["deepseek-r1:1.5b", "llama3"];
        SelectedModel = AvailableModels.First();
    }

    public ObservableCollection<string> AvailableModels
    {
        get => _availableModels;
        set
        {
            _availableModels = value;
            OnPropertyChanged();
        }
    }

    public string SelectedModel
    {
        get => _selectedModel;
        set => SetProperty(ref _selectedModel, value);
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
        var result = await _aiMessageService.SendPromptViaLibraryAsync(SelectedModel, UserInput);
        Output = result;
    }
}

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeepSeek.WPF.Core.Contracts.Services;
using DeepSeek.WPF.Core.Models;
using DeepSeek.WPF.UI.Helpers;

namespace DeepSeek.WPF.UI.ViewModels;

public partial class OllamaViewModel : ObservableObject
{
    private readonly IAiMessageService _aiMessageService;
    private ObservableCollection<LlmModel> _availableModels;
    private LlmModel _selectedModel;

    public OllamaViewModel(IAiMessageService aiMessageService)
    {
        _aiMessageService = aiMessageService;
        AvailableModels = new ObservableCollection<LlmModel> { LlmModel.DeepSeek_R1_1_5b, LlmModel.Llama3 };
        SelectedModel = AvailableModels.First();
    }

    public ObservableCollection<LlmModel> AvailableModels
    {
        get => _availableModels;
        set
        {
            _availableModels = value;
            OnPropertyChanged();
        }
    }

    public LlmModel SelectedModel
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
        var modelName = SelectedModel.GetDisplayName();

        var result = await _aiMessageService.SendPromptViaLibraryAsync(modelName, UserInput);
        Output = result;
    }
}

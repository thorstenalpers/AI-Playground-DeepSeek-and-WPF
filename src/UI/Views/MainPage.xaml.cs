using System.Windows.Controls;
using DeepSeek.WPF.Core.Contracts.Services;
using DeepSeek.WPF.UI.ViewModels;

namespace DeepSeek.WPF.UI.Views;

public partial class MainPage : Page
{
    private readonly IAiMessageService _aiMessageService;
    public MainPage(MainViewModel viewModel, IAiMessageService aiMessageService)
    {
        InitializeComponent();
        DataContext = viewModel;
        _aiMessageService = aiMessageService;
    }

    private async void SendButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        OutputTextBox.Text = "";
        var userInput = UserInputTextBox.Text;
        var result = await _aiMessageService.SendPromptViaLibraryAsync(userInput);
        OutputTextBox.Text = result;
    }
}

using System.Windows.Controls;
using DeepSeek.WPF.UI.ViewModels;

namespace DeepSeek.WPF.UI.Views;

public partial class OllamaPage : Page
{
    public OllamaPage(OllamaViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}

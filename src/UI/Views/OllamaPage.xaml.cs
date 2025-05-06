using System.Windows.Controls;
using AiPlayground.UI.ViewModels;

namespace AiPlayground.UI.Views;

public partial class OllamaPage : Page
{
    public OllamaPage(OllamaViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}

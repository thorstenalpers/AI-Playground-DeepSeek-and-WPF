using System.Windows.Controls;
using AiPlayground.UI.ViewModels;

namespace AiPlayground.UI.Views;

public partial class OpenWebUiPage : Page
{
    public OpenWebUiPage(OpenWebUiViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}

using System.Windows.Controls;
using DeepSeek.WPF.UI.ViewModels;

namespace DeepSeek.WPF.UI.Views;

public partial class OpenWebUiPage : Page
{
    public OpenWebUiPage(OpenWebUiViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}

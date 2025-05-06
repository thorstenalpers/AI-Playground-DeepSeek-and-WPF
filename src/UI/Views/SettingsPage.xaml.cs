using System.Windows.Controls;
using AiPlayground.UI.ViewModels;

namespace AiPlayground.UI.Views;

public partial class SettingsPage : Page
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}

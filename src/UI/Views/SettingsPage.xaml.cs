using System.Windows.Controls;
using DeepSeek.WPF.UI.ViewModels;

namespace DeepSeek.WPF.UI.Views;

public partial class SettingsPage : Page
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}

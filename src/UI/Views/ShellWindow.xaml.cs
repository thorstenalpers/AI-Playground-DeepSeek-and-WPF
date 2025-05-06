using System.Windows.Controls;
using AiPlayground.UI.Contracts.Views;
using AiPlayground.UI.ViewModels;
using MahApps.Metro.Controls;

namespace AiPlayground.UI.Views;

public partial class ShellWindow : MetroWindow, IShellWindow
{
    public ShellWindow(ShellViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    public Frame GetNavigationFrame()
        => shellFrame;

    public void ShowWindow()
        => Show();

    public void CloseWindow()
        => Close();
}

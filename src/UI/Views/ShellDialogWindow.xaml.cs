using System.Windows.Controls;
using DeepSeek.WPF.UI.Contracts.Views;
using DeepSeek.WPF.UI.ViewModels;
using MahApps.Metro.Controls;

namespace DeepSeek.WPF.UI.Views;

public partial class ShellDialogWindow : MetroWindow, IShellDialogWindow
{
    public ShellDialogWindow(ShellDialogViewModel viewModel)
    {
        InitializeComponent();
        viewModel.SetResult = OnSetResult;
        DataContext = viewModel;
    }

    public Frame GetDialogFrame()
        => dialogFrame;

    private void OnSetResult(bool? result)
    {
        DialogResult = result;
        Close();
    }
}

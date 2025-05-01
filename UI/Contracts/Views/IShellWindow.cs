using System.Windows.Controls;

namespace DeepSeek.WPF.UI.Contracts.Views;

public interface IShellWindow
{
    Frame GetNavigationFrame();

    void ShowWindow();

    void CloseWindow();
}

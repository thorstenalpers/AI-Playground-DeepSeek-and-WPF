using System.Windows;
using System.Windows.Controls;

namespace DeepSeek.WPF.UI.Helpers;

public static class WindowExtensions
{
    public static object GetDataContext(this Window window)
    {
        if (window.Content is Frame frame)
        {
            return frame.GetDataContext();
        }

        return null;
    }
}

using DeepSeek.WPF.UI.Models;

namespace DeepSeek.WPF.UI.Contracts.Services;

public interface IThemeSelectorService
{
    void InitializeTheme();

    void SetTheme(AppTheme theme);

    AppTheme GetCurrentTheme();
}

using System.Windows.Controls;

namespace AiPlayground.UI.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);

    Page GetPage(string key);
}

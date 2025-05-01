using System.Windows.Controls;
using DeepSeek.WPF.UI.ViewModels;

namespace DeepSeek.WPF.UI.Views;

public partial class ContentGridDetailPage : Page
{
	public ContentGridDetailPage(ContentGridDetailViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
	}
}

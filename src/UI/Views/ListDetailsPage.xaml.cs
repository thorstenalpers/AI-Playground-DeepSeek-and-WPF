using System.Windows.Controls;
using DeepSeek.WPF.UI.ViewModels;

namespace DeepSeek.WPF.UI.Views;

public partial class ListDetailsPage : Page
{
	public ListDetailsPage(ListDetailsViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
	}
}

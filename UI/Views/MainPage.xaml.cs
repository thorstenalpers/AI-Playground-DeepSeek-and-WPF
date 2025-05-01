using System.Windows.Controls;
using DeepSeek.WPF.UI.ViewModels;

namespace DeepSeek.WPF.UI.Views;

public partial class MainPage : Page
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
	}
}

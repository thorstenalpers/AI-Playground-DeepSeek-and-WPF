using System.Windows.Controls;
using DeepSeek.WPF.UI.ViewModels;

namespace DeepSeek.WPF.UI.Views;

public partial class DataGridPage : Page
{
	public DataGridPage(DataGridViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
	}
}

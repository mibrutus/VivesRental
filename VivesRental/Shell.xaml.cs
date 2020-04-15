
using System.Windows;
using VivesRental.ViewModels;


namespace VivesRental
{
	/// <summary>
	/// Interaction logic for Shell.xaml
	/// </summary>
	public partial class Shell : Window
	{
		public Shell(ShellViewModel viewModel)
		{
			InitializeComponent();
			Loaded += (sender, args) => { DataContext = viewModel; };
		}
	}
}

using VivesRental.Core;
using VivesRental.Navigation;
using VivesRental.Services;
using VivesRental.Services.Contracts;

namespace VivesRental.ViewModels
{
	public class HomeViewModel : ObservableObject, INavigatableViewModel
	{
		private readonly IProductService _productService;
		private readonly INavigator _navigator;

		public RelayCommand NavigateToVerhuurInformatieCommand { get; private set; }

		public HomeViewModel(IProductService productService , INavigator navigator)
		{
		    _productService = productService;
			_navigator = navigator;

			InstantiateCommands();
		}

		private void InstantiateCommands()
		{
			NavigateToVerhuurInformatieCommand = new RelayCommand(()=>_navigator.NavigateTo<VerhuurInformatieViewModel>(viewModel => viewModel.VersionNumber ="2.0.6"));
		}
	}
}


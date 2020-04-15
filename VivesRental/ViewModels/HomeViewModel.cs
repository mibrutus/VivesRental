using VivesRental.Core;
using VivesRental.Navigation;
using VivesRental.Services;

namespace VivesRental.ViewModels
{
	public class HomeViewModel : ObservableObject, INavigatableViewModel
	{
		private readonly IDummyService _dummyService;
		private readonly INavigator _navigator;

		public RelayCommand NavigateToVerhuurInformatieCommand { get; private set; }

		public HomeViewModel(IDummyService dummyService, INavigator navigator)
		{
		    _dummyService = dummyService;
			_navigator = navigator;

			InstantiateCommands();
		}

		private void InstantiateCommands()
		{
			NavigateToVerhuurInformatieCommand = new RelayCommand(()=>_navigator.NavigateTo<VerhuurInformatieViewModel>(viewModel => viewModel.VersionNumber ="2.0.6"));
		}
	}
}


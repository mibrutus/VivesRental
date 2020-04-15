using System;
using System.Collections.Generic;
using System.Text;
using VivesRental.Core;
using VivesRental.Navigation;

namespace VivesRental.ViewModels
{
	public class ShellViewModel: ObservableObject, IViewModel
	{
		public INavigator Navigator { get; }

		public RelayCommand NavigateToHomeCommand { get; private set; }
		public RelayCommand NavigateToArtikelbeheerCommand { get; private set; }
		public RelayCommand NavigateToVerhuurInformatieCommand { get; private set; }
		

		public ShellViewModel(INavigator navigator)
		{
			Navigator = navigator;

			InstantiateCommands();

			//set standard page
			Navigator.NavigateTo<HomeViewModel>();

		}

		private void InstantiateCommands()
		{
			NavigateToHomeCommand = new RelayCommand(()=> Navigator.NavigateTo<HomeViewModel>());
			NavigateToArtikelbeheerCommand = new RelayCommand(()=> Navigator.NavigateTo<ArtikelbeheerViewModel>());
			NavigateToVerhuurInformatieCommand = new RelayCommand(()=> Navigator.NavigateTo<VerhuurInformatieViewModel>(viewModel => viewModel.VersionNumber ="1.0.1"));
		}

	}
}



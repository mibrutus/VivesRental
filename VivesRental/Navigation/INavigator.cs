using System;
using VivesRental.Core;

namespace VivesRental.Navigation
{
	public interface INavigator
	{
		INavigatableViewModel CurrentViewModel { get; set; }
		void NavigateTo<T>() where T:INavigatableViewModel ;

		void NavigateTo<T>(Action<T> executeViewModelLogic) where T : INavigatableViewModel;
	}
}


using System;
using Microsoft.Extensions.DependencyInjection;
using VivesRental.Core;

namespace VivesRental.Navigation
{
	public class Navigator: ObservableObject, INavigator
	{
		private readonly IServiceProvider _serviceProvider;
		private INavigatableViewModel _currentViewModel;

		public INavigatableViewModel CurrentViewModel
		{
			get => _currentViewModel;
			set
			{
				_currentViewModel = value;
				RaisePropertyChanged();
			}
		}

		public Navigator(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public void NavigateTo<T>() where T : INavigatableViewModel
		{
			CurrentViewModel = _serviceProvider.GetRequiredService<T>();
		}

		public void NavigateTo<T>(Action<T> executeViewModelLogic) where T : INavigatableViewModel
		{
			var viewModel = _serviceProvider.GetRequiredService<T>();

			//execute logic
			executeViewModelLogic(viewModel);

			CurrentViewModel = viewModel;
		}
	}
}

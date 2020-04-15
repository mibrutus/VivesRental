using System;
using System.Collections.Generic;
using System.Text;
using VivesRental.Core;

namespace VivesRental.ViewModels
{
	public class VerhuurInformatieViewModel : ObservableObject, INavigatableViewModel
	{
		private string _versionNumber;

		public string VersionNumber
		{
			get => _versionNumber;
			set
			{
				_versionNumber = value;
				RaisePropertyChanged();
			}
		}
	}
}

using System;
using System.Diagnostics;
using System.Windows.Input; 

namespace VivesRental.Core
{
	public class RelayCommand : ICommand
	{
		private readonly Func<bool> _canExecute;
		private readonly Action _execute;
	
		public RelayCommand(Action execute, Func<bool> canExecute = null)
		{
		
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
	        _canExecute = canExecute;
		}
		 
		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return _canExecute?.Invoke() ?? true;  
		}

		public void Execute(object parameter)
		{
			_execute();
		}

		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (_canExecute != null)
				{
					CommandManager.RequerySuggested += value;
				}
			}
			remove 
			{
				if (_canExecute != null)
				{
					CommandManager.RequerySuggested -= value;
				}
			}
		}
	}
}

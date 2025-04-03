using System;
using System.Windows.Input;

namespace WpfNoteManager.ViewModels
{
	class RelayCommand : ICommand
	{
		private readonly Action<object> execute_;
		private readonly Func<object, bool> can_execute_;

		public RelayCommand(Action<object> execute, Func<object, bool> can_execute = null)
		{
			execute_ = execute;
			can_execute_ = can_execute;
		}
		public bool CanExecute(object parameter)
		{
			return can_execute_ == null || can_execute_(parameter);
		}

		public void Execute(object parameter)
		{
			execute_(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
	}
}

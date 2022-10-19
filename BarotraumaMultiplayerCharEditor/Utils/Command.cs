using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BarotraumaMultiplayerCharEditor.Utils
{
	internal class Command : ICommand
	{
		private Action<object?> ExecuteAction { get; set; }
		private Func<object?,bool>? CanExecuteAction { get; set; }

		public Command(Action<object?> executeFunction, Func<object?,bool>? canExecuteFunction = null)
		{
			ExecuteAction = executeFunction;
			CanExecuteAction = canExecuteFunction;
		}

		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			if(CanExecuteAction is null)
			{
				return true;
			}else
			{
				return CanExecuteAction(parameter);
			}
		}

		public void Execute(object? parameter)
		{
			ExecuteAction?.Invoke(parameter);
		}
	}
}

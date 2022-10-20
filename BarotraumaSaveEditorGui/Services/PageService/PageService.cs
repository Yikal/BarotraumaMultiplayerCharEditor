using BarotraumaSaveEditorGui.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BarotraumaSaveEditorGui.Services.PageService
{
	internal class PageService : IPageService
	{
		private Stack<ViewModelBase> _pages = new Stack<ViewModelBase>();
		private MainWindow _mainWindow;


		public PageService(MainWindow mainWindow)
		{
			_mainWindow = mainWindow;
		}

		public void Close()
		{
			if (_pages.Count <= 1) return;
			_mainWindow.Content = _pages.Pop();
		}

		public void Show(ViewModelBase viewModel)
		{
			_pages.Push(viewModel);
			_mainWindow.Content = viewModel;
			if(!_mainWindow.IsVisible)
			{
				_mainWindow.Show();
			}
		}
	}
}

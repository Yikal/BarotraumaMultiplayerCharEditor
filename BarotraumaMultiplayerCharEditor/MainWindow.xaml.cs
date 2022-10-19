using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarotraumaMultiplayerCharEditor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OnFileDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] dataString = (string[]) e.Data.GetData(DataFormats.FileDrop);
				if (DataContext is not MainWindowViewModel viewModel) return;
				foreach(var item in dataString)
				{
					if(System.IO.Path.GetExtension(item) == ".xml" && File.Exists(item))
					{
						viewModel.CharacterXmlPath = item;
						break;
					}
				}
			}
		}

		private void OnFolderDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] dataString = (string[]) e.Data.GetData(DataFormats.FileDrop);
				if (DataContext is not MainWindowViewModel viewModel) return;
				foreach (var item in dataString)
				{
					if (Directory.Exists(item))
					{
						viewModel.BarotraumaPath = item;
						break;
					}
				}
			}
		}

		private void TextBox_PreviewDragEnter(object sender, DragEventArgs e)
		{
			e.Effects = DragDropEffects.All;
			e.Handled = true;
		}
	}
}

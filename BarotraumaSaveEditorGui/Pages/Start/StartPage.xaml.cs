using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace BarotraumaSaveEditorGui.Pages.Start
{
	/// <summary>
	/// Interaction logic for Start.xaml
	/// </summary>
	public partial class StartPage : Page
	{
		public StartPage()
		{
			InitializeComponent();
		}

		private void OnFileDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] dataString = (string[]) e.Data.GetData(DataFormats.FileDrop);
				if (DataContext is not StartViewModel viewModel) return;
				foreach (var item in dataString)
				{
					if (Path.GetExtension(item) == ".xml" && File.Exists(item))
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
				if (DataContext is not StartViewModel viewModel) return;
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

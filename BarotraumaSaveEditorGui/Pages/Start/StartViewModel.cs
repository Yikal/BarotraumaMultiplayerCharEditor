using BarotraumaContentParser;
using BarotraumaSaveEditorGui.Services.PageService;
using BarotraumaSaveEditorGui.Utils;
using BarotraumaSaveEditorGui.Views.Characters;
using Microsoft.Extensions.DependencyInjection;
using MultiplayerCharacterXmlParser.XmlModels;
using System.IO;
using System.Windows;

namespace BarotraumaSaveEditorGui.Pages.Start
{
	internal class StartViewModel : ViewModelBase
	{
		private const string DefaultBarotraumaPath = @"C:\Program Files (x86)\Steam\steamapps\common\Barotrauma";

		public Command StartCommand { get; }

		private ServiceProvider ServiceProvider { get; }

		public string? CharacterXmlPath
		{
			get => _characterXmlPath;
			set
			{
				if (value == _characterXmlPath) return;
				_characterXmlPath = value;
				OnPropertyChanged(nameof(CharacterXmlPath));
			}
		}

		public string? BarotraumaPath
		{
			get => _barotraumaPath;
			set
			{
				if (value == _barotraumaPath || !BarotraumaVerifier.IsValidBarotraumaFolder(value)) return;
				_barotraumaPath = value;
				OnPropertyChanged(nameof(BarotraumaPath));
			}
		}

		public StartViewModel()
		{
			StartCommand = new Command(Start);
			//try default path?
			if (Directory.Exists(DefaultBarotraumaPath))
			{
				BarotraumaPath = DefaultBarotraumaPath;
			}
			var app = (App) Application.Current;
			ServiceProvider = app.ServiceProvider;
		}

		public void Start(object? parameter)
		{
			if (!File.Exists(CharacterXmlPath)) return;
			var parsedData = CharacterData.ParseFromXml(_characterXmlPath);
			var pageService = ServiceProvider.GetService<IPageService>();
			pageService.Show(new CharacterSelectorViewModel(parsedData));
		}

		private string? _characterXmlPath = null;
		private string? _barotraumaPath = null;
	}
}

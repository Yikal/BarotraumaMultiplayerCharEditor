using BarotraumaContentParser;
using BarotraumaContentParser.CharacterTalents;
using BarotraumaSaveEditorGui.Services.BarotraumaContentService;
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
				Settings.Default["BarotraumaPath"] = _barotraumaPath;
				Settings.Default.Save();
				OnPropertyChanged(nameof(BarotraumaPath));
			}
		}

		public StartViewModel()
		{
			StartCommand = new Command(Start);			
			if (Directory.Exists(Settings.Default.BarotraumaPath) && BarotraumaVerifier.IsValidBarotraumaFolder(Settings.Default.BarotraumaPath))
			{
				BarotraumaPath = Settings.Default.BarotraumaPath;
			}
			var app = (App) Application.Current;
			ServiceProvider = app.ServiceProvider;
		}

		public void Start(object? parameter)
		{
			if (!File.Exists(CharacterXmlPath)) return;			
			var parsedData = CharacterData.ParseFromXml(_characterXmlPath);
			var pageService = ServiceProvider.GetService<IPageService>();
			FillContentService();
			pageService.Show(new CharacterSelectorViewModel(parsedData));
		}

		private void FillContentService()
		{
            var contentService = ServiceProvider.GetService<IBarotraumaContentService>();
			Talents talents = Talents.ParseFromXml(Path.Combine(BarotraumaPath,Talents.Path));
			contentService.Initialize(talents);
        }

		private string? _characterXmlPath = null;
		private string? _barotraumaPath = null;
	}
}

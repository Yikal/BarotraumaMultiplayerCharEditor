using BarotraumaSaveEditorGui.Utils;
using BarotraumaSaveEditorGui.ViewModels;
using MultiplayerCharacterXmlParser.XmlModels;
using System.IO;

namespace BarotraumaSaveEditorGui
{
	internal class MainWindowViewModel : ViewModelBase
	{
		private const string DefaultBarotraumaPath = @"C:\Program Files (x86)\Steam\steamapps\common\Barotrauma";

		public Command StartCommand { get; }

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
				if (value == _barotraumaPath) return;
				_barotraumaPath = value;
				OnPropertyChanged(nameof(BarotraumaPath));
			}
		}

		public MainWindowViewModel()
		{
			StartCommand = new Command(Start);
			//try default path?
			if (Directory.Exists(DefaultBarotraumaPath))
			{
				BarotraumaPath = DefaultBarotraumaPath;
			}
		}

		public void Start(object? parameter)
		{
			if (!File.Exists(CharacterXmlPath)) return;
			var parsedData = CharacterData.ParseFromXml(_characterXmlPath);
		}

		private string? _characterXmlPath = null;
		private string? _barotraumaPath = null;
	}
}

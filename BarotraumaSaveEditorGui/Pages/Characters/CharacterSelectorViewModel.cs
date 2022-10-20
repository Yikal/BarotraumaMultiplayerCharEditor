using BarotraumaSaveEditorGui.Utils;
using MultiplayerCharacterXmlParser.XmlModels;
using System.Collections.ObjectModel;

namespace BarotraumaSaveEditorGui.Views.Characters
{
	internal class CharacterSelectorViewModel : ViewModelBase
	{
		public ObservableCollection<CharacterCampaignData> Characters { get; } = new ObservableCollection<CharacterCampaignData>();

		public CharacterEditorViewModel SelectedCharacterContent
		{
			get => _selectedCharacterContent;
			set
			{
				if (value == _selectedCharacterContent) return;
				_selectedCharacterContent = value;
				OnPropertyChanged();
			}
		}

		public CharacterCampaignData SelectedCharacter 
		{
			get => _selectedCharacter;
			set
			{
				if (value == _selectedCharacter) return;
				_selectedCharacter = value;
				OnPropertyChanged();
				SelectedCharacterContent = new CharacterEditorViewModel() { Character = SelectedCharacter };
			}
		}

		public CharacterSelectorViewModel(CharacterData? data)
		{
			if (data == null) return;
			Characters = new ObservableCollection<CharacterCampaignData>(data.CharacterCampaignData);
		}

		private CharacterCampaignData _selectedCharacter;
		private CharacterEditorViewModel _selectedCharacterContent;
	}
}

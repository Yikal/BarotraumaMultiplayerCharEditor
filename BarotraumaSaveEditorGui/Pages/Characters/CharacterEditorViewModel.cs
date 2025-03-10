﻿using BarotraumaContentParser.CharacterTalents;
using BarotraumaSaveEditorGui.Pages.Characters.TalentView;
using BarotraumaSaveEditorGui.Services.BarotraumaContentService;
using BarotraumaSaveEditorGui.Utils;
using Microsoft.Extensions.DependencyInjection;
using MultiplayerCharacterXmlParser.XmlModels;
using System.Windows;

namespace BarotraumaSaveEditorGui.Views.Characters
{
    internal class CharacterEditorViewModel : ViewModelBase
    {
        public CharacterCampaignData Character
        {
            get => _character;
            set
            {
                if (_character == value) return;
                _character = value;
                var content = ((App)Application.Current).ServiceProvider.GetService<IBarotraumaContentService>();
                CharacterTalents = new TalentTabViewModel(_character.Character, content.GetParsedBarotraumaContent<Talents>());
                OnPropertyChanged();
            }
        }

        public TalentTabViewModel CharacterTalents 
        {
            get => _characterTalents;
            set
            {
                if(value == _characterTalents) return;
                _characterTalents = value;
                OnPropertyChanged();
            }
        }

        public Command ToggleCommand { get; }

        public CharacterEditorViewModel()
        {
            ToggleCommand = new Command(ExecuteToggleCommand);
        }

        public void ExecuteToggleCommand(object? id)
        {
            if (!(id is string stringId)) return;
            if(Character.Character.UnlockedTalents.Contains(stringId))
            {
                Character.Character.RemoveTalent(stringId);
            }else
            {
                Character.Character.AddTalent(stringId);
            }
            OnPropertyChanged(nameof(Character));
        }

        private CharacterCampaignData _character;
        private TalentTabViewModel _characterTalents;
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarotraumaContentParser.CharacterTalents;
using MultiplayerCharacterXmlParser.XmlModels;

namespace BarotraumaSaveEditorGui.Pages.Characters.TalentView
{
    internal class TalentTabViewModel
    {
        public Character Character { get; set; }
        public ObservableCollection<TalentSubTree> CharacterTrees { get; set; } = new ObservableCollection<TalentSubTree>();

        public TalentTabViewModel(Character character, Talents talentContent)
        {
            Character = character;
            foreach(var t in talentContent.TalentTrees.Single(tt => tt.JobId == character.Job.JobId).TalentSubTrees)
            {
                CharacterTrees.Add(t);
            }
        }
    }
}

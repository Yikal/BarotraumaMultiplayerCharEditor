using MultiplayerCharacterXmlParser.XmlModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace BarotraumaSaveEditorGui.Pages.Characters.TalentView
{
    internal class CharacterTalentIdMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values.Any(v => v is string) && values.Any(v => v is Character))
            {
                Character character = values.Single(v => v is Character) as Character;
                string id = values.Single(v => v is string) as string;
                if(character.UnlockedTalents.Contains(id))
                {
                    return new SolidColorBrush(Color.FromArgb(60,0,255,0));
                }
                return Brushes.Transparent;
            }
            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

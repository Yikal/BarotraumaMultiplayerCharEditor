using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MultiplayerCharacterXmlParser.BarotraumaContent.CharacterTalent
{
	public class TalentOptionArray
	{
		[XmlElement("TalentOption")]
		public IReadOnlyCollection<TalentOption> TalentOptions { get; set; }
	}
}

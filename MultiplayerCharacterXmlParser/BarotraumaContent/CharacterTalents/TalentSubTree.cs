using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MultiplayerCharacterXmlParser.BarotraumaContent.CharacterTalent
{
	public class TalentSubTree
	{
		[XmlAttribute("identifier")]
		public string Id { get; set; }

		[XmlElement("TalentOptions")]
		public IReadOnlyList<TalentOptionArray> TalentTiers { get; set; }
	}
}

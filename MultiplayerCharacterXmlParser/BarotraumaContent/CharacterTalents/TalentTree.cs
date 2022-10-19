using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MultiplayerCharacterXmlParser.BarotraumaContent.CharacterTalent
{
	public class TalentTree
	{
		[XmlAttribute("jobidentifier")]
		public string JobId { get; set; }

		[XmlElement("SubTree")]
		public List<TalentSubTree> TalentSubTrees { get; set; }
	}
}

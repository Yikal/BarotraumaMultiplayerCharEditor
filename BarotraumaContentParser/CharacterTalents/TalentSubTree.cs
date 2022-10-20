using System.Xml.Serialization;

namespace BarotraumaContentParser.CharacterTalents
{
	public class TalentSubTree
	{
		[XmlAttribute("identifier")]
		public string Id { get; set; }

		[XmlElement("TalentOptions")]
		public IReadOnlyList<TalentOptionArray> TalentTiers { get; set; }
	}
}

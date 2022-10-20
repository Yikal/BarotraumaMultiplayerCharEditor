using System.Xml.Serialization;

namespace BarotraumaContentParser.CharacterTalents
{
	public class TalentOption
	{
		[XmlAttribute("identifier")]
		public string Id { get; set; }
	}
}

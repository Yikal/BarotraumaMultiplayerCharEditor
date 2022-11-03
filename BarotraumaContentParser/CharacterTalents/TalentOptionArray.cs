using System.Xml.Serialization;

namespace BarotraumaContentParser.CharacterTalents
{
	public class TalentOptionArray
	{
		[XmlElement("TalentOption")]
		public List<TalentOption> TalentOptions { get; set; }
	}
}

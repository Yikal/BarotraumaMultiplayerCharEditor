using System.Xml.Serialization;

namespace BarotraumaContentParser.CharacterTalents
{
	public class TalentOptionArray
	{
		[XmlElement("TalentOption")]
		public IReadOnlyCollection<TalentOption> TalentOptions { get; set; }
	}
}

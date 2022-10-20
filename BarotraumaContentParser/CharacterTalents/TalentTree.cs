using System.Xml.Serialization;

namespace BarotraumaContentParser.CharacterTalents
{
	public class TalentTree
	{
		[XmlAttribute("jobidentifier")]
		public string JobId { get; set; }

		[XmlElement("SubTree")]
		public List<TalentSubTree> TalentSubTrees { get; set; }
	}
}

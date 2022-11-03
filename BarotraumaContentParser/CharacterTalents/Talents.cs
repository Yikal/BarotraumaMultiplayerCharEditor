using System.Xml.Linq;
using System.Xml.Serialization;

namespace BarotraumaContentParser.CharacterTalents
{
	[XmlRoot("TalentTrees")]
	public class Talents : IBarotraumaContent
	{
		public Talents()
		{
			TalentTrees = new List<TalentTree>();
		}

		[XmlElement("TalentTree")]
		public List<TalentTree> TalentTrees { get; set; }

		public string RelativePath => Path;

		public const string Path = @"Content\Talents\TalentTrees.xml";

        public static Talents? ParseFromXml(string? inputXml)
		{
			if (inputXml == null) return null;
			XDocument xmlDocument = XDocument.Load(inputXml);
			XElement dataNode = xmlDocument.Root;
			var serializer = new XmlSerializer(typeof(Talents));
			return (Talents?) serializer.Deserialize(dataNode.CreateReader());
		}
	}
}

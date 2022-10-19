using MultiplayerCharacterXmlParser.XmlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MultiplayerCharacterXmlParser.BarotraumaContent.CharacterTalent
{
	[XmlRootAttribute("TalentTrees")]
	public class Talents : IBarotraumaContent
    {
        private Talents() 
        {
            TalentTrees = new List<TalentTree>();
        }

		[XmlElement("TalentTree")]
		public IReadOnlyCollection<TalentTree> TalentTrees { get; set; }

        public string RelativePath => @"\Content\Talents\TalentTrees.xml";

        public static Talents? ParseFromXml(string? inputXml)
        {
            if (inputXml == null) return null;
            XDocument xmlDocument = XDocument.Load(inputXml);
            XElement dataNode = xmlDocument.Root;
            var serializer = new XmlSerializer(typeof(Talents));
            return (Talents?)serializer.Deserialize(dataNode.CreateReader());
        }

        
    }
}

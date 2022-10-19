using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MultiplayerCharacterXmlParser.XmlModels
{
	[XmlRootAttribute("CharacterData")]
	public class CharacterData
    {
        private CharacterData()
        {
            CharacterCampaignData = new List<CharacterCampaignData>();
        }

        [XmlElement("CharacterCampaignData")]
        public List<CharacterCampaignData> CharacterCampaignData { get; set; }

        public static CharacterData? ParseFromXml(string? inputXml)
        {
            if (inputXml == null) return null;
            XDocument xmlDocument = XDocument.Load(inputXml);
            XElement dataNode = xmlDocument.Root;
            var serializer = new XmlSerializer(typeof(CharacterData));
            return (CharacterData?)serializer.Deserialize(dataNode.CreateReader());
        }
    }
}
using System.Xml.Serialization;

namespace MultiplayerCharacterXmlParser.XmlModels
{
	public class CharacterCampaignData
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("accountid")]
        public string AccountId { get; set; }

        [XmlElement("Character")]
        public Character Character { get; set; }
    }
}

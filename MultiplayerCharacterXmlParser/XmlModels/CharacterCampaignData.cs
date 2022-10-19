using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

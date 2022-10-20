using System.Xml.Serialization;

namespace MultiplayerCharacterXmlParser.XmlModels
{
	public class Character
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("salary")]
        public int Salary { get; set; }

        [XmlAttribute("experiencepoints")]
        public int ExperiencePoints { get; set; }
    }
}

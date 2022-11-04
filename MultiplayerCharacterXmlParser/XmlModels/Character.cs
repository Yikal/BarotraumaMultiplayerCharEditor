using System.Text.RegularExpressions;
using System.Xml;
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

        [XmlAttribute("additionaltalentpoints")]
        public int Talentpoints { get; set; }

        [XmlAttribute("unlockedtalents")]
        public string UnlockedTalents { get; set; }

        [XmlElement("job")]
        public Job Job { get; set; }

        [XmlAnyElement]
        public XmlElement[] OtherElements { get; set; }

        [XmlAnyAttribute]
        public XmlAttribute[] OtherAttributes { get; set; }

        public void AddTalent(string talentId)
        {
            if(UnlockedTalents == "")
            {
                UnlockedTalents = talentId;
            }else
            {
                UnlockedTalents += "," + talentId;
            }
        }

        public void RemoveTalent(string talentId)
        {
            Regex removeRegex = new Regex(talentId + @",?");
            removeRegex.Replace(UnlockedTalents, "");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MultiplayerCharacterXmlParser.XmlModels
{
    public class Job
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("identifier")]
        public string JobId { get; set; }
    }
}

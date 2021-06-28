using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    public class OrgCollection
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("military")]
        public string Type { get; set; }
    }

}

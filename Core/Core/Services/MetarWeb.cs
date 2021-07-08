using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    [XmlRoot("response")]
    public class MetarWeb
    {
        [XmlElement("data")]
        public List<MetarCollection> Metars;
    }
}

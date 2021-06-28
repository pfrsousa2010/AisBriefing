using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    public class MetarCollection
    {
        [XmlElement("METAR")]
        public List<Metar> Items;
    }
}

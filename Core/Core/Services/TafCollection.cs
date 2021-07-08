using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    public class TafCollection
    {
        [XmlElement("TAF")]
        public List<Taf> Items;
    }
}

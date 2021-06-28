using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    public class RunwayCollection
    {
        [XmlElement("runway")]
        public List<RunwayItems> Items { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    public class NotamCollection
    {
        [XmlElement("item")]
        public List<Notam> Items { get; set; }
    }

}

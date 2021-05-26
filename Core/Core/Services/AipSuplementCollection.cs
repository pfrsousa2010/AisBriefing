using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    public class AipSuplementCollection
    {
        [XmlElement("item")]
        public List<AipSuplement> Items { get; set; }      
    }
}

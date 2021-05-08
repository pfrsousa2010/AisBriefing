using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    public class Notam
    {
        [XmlElement("n")]
        public string IdNotam { get; set; }
        [XmlElement("loc")]
        public string Icao { get; set; }
        [XmlElement("e")]
        public string Text { get; set; }
        [XmlElement("b")]
        public string StDate { get; set; }
        [XmlElement("c")]
        public string EdDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    public class Notam
    {
        [XmlElement("loc")]
        public string Icao { get; set; }

        [XmlElement("e")]
        public string Text { get; set; }
    }
}

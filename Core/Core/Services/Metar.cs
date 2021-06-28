using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    
    public class Metar
    {
        [XmlElement("raw_text")]
        public string MsgMetar { get; set; }

        [XmlElement("flight_category")]
        public string FlightCat { get; set; }

    }
}

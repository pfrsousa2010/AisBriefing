using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    
    public class Taf
    {
        [XmlElement("raw_text")]
        public string MsgTaf { get; set; }

        [XmlElement("station_id")]
        public string StationId { get; set; }

    }
}

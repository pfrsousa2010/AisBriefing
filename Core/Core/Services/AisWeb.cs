using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    [XmlRoot("aisweb")]
    public class AisWeb
    {
        [XmlElement("notam")]
        public List<NotamCollection> Notams { get; set; }
    }

}

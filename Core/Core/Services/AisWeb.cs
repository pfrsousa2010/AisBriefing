using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Core.Services
{
    [XmlRoot("aisweb")]
    public class AisWeb
    {
        [XmlElement("notam")]
        public List<NotamCollection> Notams { get; set; }

        [XmlElement("suplementos")]
        public List<AipSuplementCollection> AipSuplements { get; set; }  

    }

}

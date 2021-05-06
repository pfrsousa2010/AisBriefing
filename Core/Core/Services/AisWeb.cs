using System.Collections.Generic;
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

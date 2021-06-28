using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Services
{
    [XmlRoot("aisweb")]
    public class RotaerAisWeb
    {
        [XmlElement("org")]
        public List<OrgCollection> Orgs { get; set; }

        [XmlElement("runways")]
        public List<RunwayCollection> Runways { get; set; }

        [XmlElement("latRotaer")]
        public string LatRotaer { get; set; }

        [XmlElement("lngRotaer")]
        public string LngRotaer { get; set; }

        [XmlElement("type")]
        public string TypeRotaer { get; set; }

        [XmlElement("typeUtil")]
        public string TypeUtilRotaer { get; set; }

        [XmlElement("typeOpr")]
        public string TypeOprRotaer { get; set; }

        [XmlElement("cat")]
        public string CategoryRotaer { get; set; }
        
        [XmlElement("utc")]
        public string UtcRotaer { get; set; }

        [XmlElement("altM")]
        public string altMetersRotaer { get; set; }

        [XmlElement("altFt")]
        public string altFeetRotaer { get; set; }

        [XmlElement("fir")]
        public string FirRotaer { get; set; }





    }

}

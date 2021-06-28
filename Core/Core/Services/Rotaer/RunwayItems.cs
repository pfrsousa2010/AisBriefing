using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    public class RunwayItems
    {
        [XmlElement("ident")]
        public string IdentRwy { get; set; }
        [XmlElement("surface")]
        public string SurfaceRwy { get; set; }
        [XmlElement("length")]
        public string LengthRwy { get; set; }
        [XmlElement("width")]
        public string WidthRwy { get; set; }
    }
}

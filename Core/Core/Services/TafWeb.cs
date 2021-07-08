using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    [XmlRoot("response")]
    public class TafWeb
    {
        [XmlElement("data")]
        public List<TafCollection> Tafs;
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    public class DayCollection
    {
        [XmlElement ("sunrise")]
        public string SunRiseWeb { get; set; }

        [XmlElement("sunset")]
        public string SunSetWeb { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Core.Services
{
    public class AipSuplement
    {
        [XmlElement("local")]
        public string IcaoSup { get; set; }
        [XmlElement("n")]
        public string SerieSup { get; set; }
        [XmlElement("titulo")]
        public string TitleSup { get; set; }
        [XmlElement("texto")]
        public string TextSup { get; set; }
        [XmlElement("duracao")]
        public string PeriodSup { get; set; }
    }
}

using System.Xml.Serialization;

namespace ABMData.Models
{
    [XmlRoot(ElementName = "Reference")]
    public class Reference
    {
        [XmlElement(ElementName = "RefText")]
        public string RefText { get; set; }
        [XmlAttribute(AttributeName = "RefCode")]
        public string RefCode { get; set; }
    }
}

using System.Xml.Serialization;

namespace ABMData.Models
{
    [XmlRoot(ElementName = "Country")]
    public class Country
    {
        [XmlAttribute(AttributeName = "CodeType")]
        public string CodeType { get; set; }
        [XmlAttribute(AttributeName = "CountryType")]
        public string CountryType { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}

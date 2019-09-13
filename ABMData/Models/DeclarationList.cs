using System.Xml.Serialization;

namespace ABMData.Models
{
    [XmlRoot(ElementName = "DeclarationList")]
    public class DeclarationList
    {
        [XmlElement(ElementName = "Declaration")]
        public Declaration Declaration { get; set; }
    }
}

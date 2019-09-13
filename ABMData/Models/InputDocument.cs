using System.Xml.Serialization;

namespace ABMData.Models
{
    [XmlRoot(ElementName = "InputDocument")]
    public class InputDocument
    {
        [XmlElement(ElementName = "DeclarationList")]
        public DeclarationList DeclarationList { get; set; }
    }
}

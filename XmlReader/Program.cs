using System;
using System.Xml;
using System.Collections.Generic;
using XmlReader.Models;

namespace XmlReader
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string theXml = "<InputDocument><DeclarationList><Declaration Command=\"DEFAULT\" Version=\"5.13\"><DeclarationHeader><Jurisdiction>IE</Jurisdiction><CWProcedure>IMPORT</CWProcedure><DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination><DocumentRef>71Q0019681</DocumentRef><SiteID>DUB</SiteID><AccountCode>G0779837</AccountCode><Reference RefCode=\"MWB\"><RefText>586133622</RefText></Reference><Reference RefCode=\"KEY\"><RefText>DUB16049</RefText></Reference><Reference RefCode=\"CAR\"><RefText>71Q0019681</RefText></Reference><Reference RefCode=\"COM\"><RefText>71Q0019681</RefText></Reference><Reference RefCode=\"SRC\"><RefText>ECUS</RefText></Reference><Reference RefCode=\"TRV\"><RefText>1</RefText></Reference><Reference RefCode=\"CAS\"><RefText>586133622</RefText></Reference><Reference RefCode=\"HWB\"><RefText>586133622</RefText></Reference><Reference RefCode=\"UCR\"><RefText>586133622</RefText></Reference><Country CodeType=\"NUM\" CountryType=\"Destination\">IE</Country><Country CodeType=\"NUM\" CountryType=\"Dispatch\">CN</Country></DeclarationHeader></Declaration></DeclarationList></InputDocument>";
            xmlDoc.LoadXml(theXml);

            string xpath = "InputDocument/DeclarationList/Declaration/DeclarationHeader/Reference";
            var nodes = xmlDoc.SelectNodes(xpath);

            List<XmlResult> test = new List<XmlResult>();
            for (int i = 0; i < nodes.Count; ++i)
            {
                switch (nodes.Item(i).Attributes.GetNamedItem("RefCode").InnerText)
                {
                    case "MWB":
                        WriteTheResult(nodes.Item(i).InnerText, nodes.Item(i).Attributes.GetNamedItem("RefCode").InnerText);
                        break;
                    case "TRV":
                        WriteTheResult(nodes.Item(i).InnerText, nodes.Item(i).Attributes.GetNamedItem("RefCode").InnerText);
                        break;
                    case "CAR":
                        WriteTheResult(nodes.Item(i).InnerText, nodes.Item(i).Attributes.GetNamedItem("RefCode").InnerText);
                        break;
                    default:
                        break;
                }

            }
        }

        public static void WriteTheResult(string refText, string refCode)
        {
            Console.WriteLine(string.Format("RefText: {0} of RefCode: {1}", refText, refCode));
        }
    }
}

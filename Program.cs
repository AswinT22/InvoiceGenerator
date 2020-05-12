using System;

namespace InvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            convertXmlToPdf();
            convertJsonToPdf();
        }

        static void convertXmlToPdf() {
            Console.WriteLine("Reading Xml file......");
            Base64Utils base64Utils =  new Base64Utils();
            string base64 =  base64Utils.get("./input/xmldoc.xml");
            Console.WriteLine("Base64 generated:\n" + base64 + "\n");
            XmlUtils xmlUtils = new XmlUtils();
            Console.WriteLine("Generating PDF file......");
            xmlUtils.GeneratePdf(base64);
        }

        static void convertJsonToPdf() {
            Console.WriteLine("Reading Json file......");
            Base64Utils base64Utils =  new Base64Utils();
            string base64 =  base64Utils.get("./input/jsondoc.json");
            Console.WriteLine("Base64 generated:\n" + base64 + "\n");
            JsonUtils jsonUtils = new JsonUtils();
            Console.WriteLine("Generating PDF file......");
            jsonUtils.GeneratePdf(base64);
        }
    }
}

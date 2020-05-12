using System;
using System.Xml;
using System.Text;
using GemBox.Document.Tables;
using GemBox.Document;

namespace InvoiceGenerator {
    class XmlUtils {
         XmlDocument GetXmlDocument(string base64) {
            string decode = Encoding.UTF8.GetString(Convert.FromBase64String(base64));
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(decode);
            Console.WriteLine("For XML:\n" + decode + "\n");
            return xml;
        }

        public void GeneratePdf(string base64) {
              ComponentInfo.SetLicense("FREE-LIMITED-KEY");
              DocumentModel pdfDocument = new DocumentModel();
              Table table = new Table(pdfDocument);
              table.TableFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);
              pdfDocument.Sections.Add(new Section(pdfDocument, table));
              XmlDocument xmlDocument = GetXmlDocument(base64);
              foreach (XmlNode xmlRow in xmlDocument.SelectNodes("/root/invoice")){
                    foreach (XmlNode child in xmlRow.ChildNodes) {
                        TableRow row = new TableRow(pdfDocument);
                        table.Rows.Add(row);
                        row.Cells.Add(
                            new TableCell(pdfDocument,
                                new Paragraph(pdfDocument, child.Name)
                                )        
                        );
                        row.Cells.Add(
                            new TableCell(pdfDocument,
                                new Paragraph(pdfDocument, child.InnerText)
                            )        
                        );
                    }
                }     

              pdfDocument.Save("output/XmlToPdf.pdf");
              Console.WriteLine("PDF generated for xml : output/XmlToPdf.pdf\n");
        }
    }
}

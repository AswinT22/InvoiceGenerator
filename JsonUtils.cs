using System;
using Newtonsoft.Json;
using GemBox.Document.Tables;
using GemBox.Document;

using InvoiceGenerator.Models;

namespace InvoiceGenerator {
    class JsonUtils {
         public static Invoice Base64DecodeObject(string base64String)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64String);
            String jsonString = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            Console.WriteLine("For Json:\n" + jsonString + "\n");
            return  JsonConvert.DeserializeObject<JsonResponse>(jsonString).invoice;
        }

        public void GeneratePdf(string base64) {
                ComponentInfo.SetLicense("FREE-LIMITED-KEY");
                DocumentModel pdfDocument = new DocumentModel();
                Table table = new Table(pdfDocument);
                table.TableFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);
                pdfDocument.Sections.Add(new Section(pdfDocument, table));
                Invoice invoice = Base64DecodeObject(base64);
              
             
                TableRow row = new TableRow(pdfDocument);
                table.Rows.Add(row);
                row.Cells.Add(
                    new TableCell(pdfDocument,
                        new Paragraph(pdfDocument, "Name")
                        )        
                );
                row.Cells.Add(
                    new TableCell(pdfDocument,
                        new Paragraph(pdfDocument, invoice.name)
                    )        
                );

                row = new TableRow(pdfDocument);
                table.Rows.Add(row);
                row.Cells.Add(
                    new TableCell(pdfDocument,
                        new Paragraph(pdfDocument, "Amount")
                        )        
                );
                row.Cells.Add(
                    new TableCell(pdfDocument,
                        new Paragraph(pdfDocument, invoice.amount.ToString())
                    )        
                );
                
              pdfDocument.Save("output/JsonToPdf.pdf");
              Console.WriteLine("PDF generated for Json : output/JsonToPdf.pdf\n");
        }
    }
}

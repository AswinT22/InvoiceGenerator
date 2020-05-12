using System;
using System.IO;

namespace InvoiceGenerator {
    class Base64Utils {
        public string get(string path) {
            string encodedData = "";
            using (FileStream fs = System.IO.File.OpenRead(path)) {
                byte[] filebytes = new byte[fs.Length];
                fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
                encodedData = 
                    Convert.ToBase64String(filebytes,                 
                                            Base64FormattingOptions.InsertLineBreaks);
            }
            return encodedData;
        }

    }
}
using System;
using System.IO;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Text;
using System.Text.RegularExpressions;

namespace Joshyba
{
    public class Unir_PDF
    {
        public static void Uniendo(ref string[] lstFiles, string salida)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath=salida;
            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            //Open the output file
            sourceDocument.Open();

            try
            {
            //Loop through the files list
                for (int f = 0; f < lstFiles.Length; f++)
                {
                    if (lstFiles[f] != null)
                    {
                        int pages = get_pageCcount(lstFiles[f]);
                        reader = new PdfReader(lstFiles[f]);
                        //Add pages of current file
                        for (int i = 1; i <= pages; i++)
                        {
                            importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                            pdfCopyProvider.AddPage(importedPage);
                        }
                        reader.Close();
                    }
                }
                //At the end save the output file
                sourceDocument.Close();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
                throw ex;
            }
        }

        private static int get_pageCcount(string file)
        {
            iTextSharp.text.pdf.PdfReader oReader = new iTextSharp.text.pdf.PdfReader(file);
            return oReader.NumberOfPages;
            //using (StreamReader sr = new StreamReader(File.OpenRead(file)))
            //{
            //    Regex regex = new Regex(@"/Type\s*/Page[^s]");
            //    MatchCollection matches = regex.Matches(sr.ReadToEnd());
            //    return matches.Count;
            //}
        }
    }
}

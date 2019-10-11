using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace Joshyba
{
    public class Rellenar_pdf
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombres"></param>
        /// <param name="Rs">Recibe un dataTable en vez de un arreglo</param>
        /// <param name="origen"></param>
        /// <param name="destino"></param>
        /// <param name="Abrir">si al terminar de escribir el pdf se abrira con el programa predetminado</param>
        /// <param name="xSellado">True el pdf generado no es editable</param>
        public static void rellenar(string[] nombres, DataTable Rs, string origen, string destino, bool Abrir = true, bool xSellado = true)
        {
            try
            {
                string pdforiginal = origen;
                string nuevopdf = destino;
                PdfReader pdfreader = new PdfReader(pdforiginal);
                PdfStamper pdfstamper = new PdfStamper(pdfreader, new FileStream(nuevopdf, FileMode.Create));
                AcroFields pdfFormFields = pdfstamper.AcroFields;

                for (int x = 0; x < nombres.Length; x++)
                {
                    if (Rs.Rows[0][x] == null) Rs.Rows[0][x] = " ";
                    pdfFormFields.SetField(nombres[x], Rs.Rows[0][x].ToString());
                }
                pdfstamper.FormFlattening = xSellado;
                pdfstamper.Close();
                pdfreader.Close();
                if (Abrir) Process.Start(nuevopdf);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Escritura de archivos pdf \n Descripción => " + ex.Message + "\n tamaño campos => " + nombres.Length + " \n tamaño valores => " + Rs.Rows.Count);
                Exepciones.Mostrar_Mensaje(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombres"></param>
        /// <param name="Rs"></param>
        /// <param name="origen"></param>
        /// <param name="destino"></param>
        /// <param name="Abrir">si al terminar de escribir el pdf se abrira con el programa predetminado</param>
        /// <param name="xSellado">True el pdf generado no es editable</param>
        public static void rellenar(string[] nombres, string[] Rs, string origen, string destino, bool Abrir = true, bool xSellado = true)
        {
            try
            {
                string pdforiginal = origen;
                string nuevopdf = destino;
                PdfReader pdfreader = new PdfReader(pdforiginal);
                PdfStamper pdfstamper = new PdfStamper(pdfreader, new FileStream(nuevopdf, FileMode.Create));
                AcroFields pdfFormFields = pdfstamper.AcroFields;

                for (int x = 0; x < nombres.Length; x++)
                {
                    if (Rs[x] == null) Rs[x] = " ";
                    pdfFormFields.SetField(nombres[x], Rs[x]);
                }
                pdfstamper.FormFlattening = xSellado;
                pdfstamper.Close();
                pdfreader.Close();
                if (Abrir) Process.Start(nuevopdf);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Escritura de archivos pdf \n Descripción => " + ex.Message + "\n tamaño campos => " + nombres.Length + " \n tamaño valores => " + Rs.Length);
                Exepciones.Mostrar_Mensaje(ex);
            }
        }
    }
}
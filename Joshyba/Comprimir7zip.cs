using System;
using System.Collections.Generic;
using System.Text;

namespace Joshyba
{
    /// <summary>
    /// Comprimir arrchivos en formato 7Z y ZIP
    /// </summary>
   public class Comprimir7zip
    {
        public enum xTipo
        {
            _7Z,
            _ZIP,
        }

        public xTipo vTipo;
        /// <summary>
        /// Comprimir archivo o carpeta
        /// </summary>
        /// <param name="xNombreArchivo">Nombre del archivo que se generará</param>
        /// <param name="xFormatoComprimir">Elegir un formato a generar en 7Z o ZIP | Joshyba.Comprimir7zip.xTipo._ZIP | Joshyba.Comprimir7zip.xTipo._7Z</param>
        /// <param name="xRutaArchivo">nombre y ubicacion del archivo o carpeta a comprimir con ruta completa, si la ruta tiene espacios tomar dobles comillas</param>
        public static void Comprimir(ref string xNombreArchivo, xTipo xFormatoComprimir,string xRutaArchivo)
        {
            string xArgumentos = "a " + xNombreArchivo + new Comprimir7zip().TipoFormato() + " " + xRutaArchivo;
            System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + "\\7Z.exe", xArgumentos);
        }
        /// <summary>
        /// Descromprimir archivo 7Z o ZIP
        /// </summary>
        /// <param name="xRutaArchivo">nombre y ubicacion del archivo o carpeta a descomprimir con ruta completa, si la ruta tiene espacios tomar dobles comillas</param>
        /// <param name="xFormatoComprimir">Elegir un formato a generar en 7Z o ZIP | Joshyba.Comprimir7zip.xTipo._ZIP | Joshyba.Comprimir7zip.xTipo._7Z</param>
        /// <param name="xRutaArchivoSalida">Aplica cuando se va a descomprimir en una ruta en especifica, si se deja en blanco se crea en la misma ruta donde se esta ejecutando el descompresor</param>
        public static void DesComprimir(ref string xRutaArchivo, xTipo xFormatoComprimir, string xRutaArchivoSalida = "")
        {
            string xArgumentos = "";
            if (xRutaArchivoSalida == "")
            {
                xArgumentos = "x " + xRutaArchivo + " -o\\..\\";
            }
            else
            {
                xArgumentos = "x " + xRutaArchivo + " -o" + xRutaArchivoSalida;
            }
            System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + "\\7Z.exe", xArgumentos);
        }

        private string TipoFormato()
        {
            if(vTipo==xTipo._7Z)
            {
                return ".7z";
            }
            else
            {
                return ".zip";
            }
        }
    }
}

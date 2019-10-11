using System;
using System.Collections.Generic;
using System.Text;


namespace Joshyba
{
    public class Cadenas
    {
        //public static Cadenas cads;
        public Cadenas()
        {
            //Cadenas.cads = this;
        }

        /// <summary>
        /// reemplaza parte de la direccion de un archivo \\\\ por \\ 
        /// </summary>
        /// <param name="url">direccion que se genera.</param>
        /// <returns></returns>
        public static string modificarurl(string url)  
        {

            return url.Replace("\\", "\\\\");
        }

        /// <summary>
        /// Quita todas las palabras que no son comunes en una cadena
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static string reemplazador_full(string cadena)
        {
            return cadena.Replace("#", "").Replace("\"", "").Replace("/", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("á", "A").Replace("é", "E").Replace("í", "I").Replace("ó", "O").Replace("ú", "U").Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U").Replace("ñ", "N").Replace("Ñ", "N").Replace("=", "").Replace(".", "").Replace("-", "").Replace("\\", "").Replace("{", "").Replace("}", "");
        }


        /// <summary>
        /// Permite concatenar el parametro REPRODUCIR con CADENA repitiendo TAMANIO de veces REPRODUCIR Colocandolo el valor del LADO der o izq la CADENA
        /// </summary>
        /// <param name="REPRODUCIR">Palabra que se reproducirá varias veces</param>
        /// <param name="TAMANIO">Cantidad de veces que se reproducirá PALABRA</param>
        /// <param name="CADENA">Valor Principal que ira en el generador</param>
        /// <param name="Lado">define de que lado se colocara el Valor principal</param>
        /// <param name="dgv_rs">Complemento para colocar el nombre del datagrid o datatable</param>
        /// <param name="campo">Complemento para colocar el campo donde se esta usando la funcion</param>
        /// <returns></returns>
        public static string Generador2(string REPRODUCIR,int TAMANIO,string CADENA,string Lado,string dgv_rs="ninguna",string campo="ninguna")
        {
            string cad = "";
            string result = "";
            if (CADENA.Length == 0) CADENA = " ";
            try
            {
                for (int x = 1; x <= TAMANIO; x++)
                {
                    cad += REPRODUCIR;
                }
                if (Lado == "der")
                {
                    if (CADENA.Length > TAMANIO)
                        result = CADENA.Substring(1, TAMANIO);
                    else
                        result = cad.Substring(1, TAMANIO - CADENA.Length) + CADENA;
                }
                else if (Lado == "izq")
                {
                    if (CADENA.Length > TAMANIO)
                        result = CADENA.Substring(1, TAMANIO);
                    else
                        result = CADENA + cad.Substring(1, TAMANIO - CADENA.Length);
                }
                return result;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\nReproducir:\"" + REPRODUCIR + "\"\n Tamanio:" + TAMANIO + "\nCadena:\"" + CADENA + "\"\ndgv_rs:" + dgv_rs + "\n campo:" + campo);
                return result;
            }             
        }

        /// <summary>
        /// Retorna la cadena antecedida con el tamaño de caracteres, ejemplo 05JOSEI
        /// </summary>
        /// <param name="cad">cadena que se retornara</param>
        /// <param name="max">valor maximo a tomar en cuenta</param>
        /// <returns></returns>
        public static string Generar_Tamanio(string  cad,int max)
        {
            string tam ="";
            string cad2 = "";
            cad=cad.Trim();
            if (cad.Length < 10)
            {
                tam = "0" + cad.Length;
            }
            else
            {
                tam = "" + cad.Length;
            }
            if (cad.Length > max)
            {
                cad2 = cad.Substring(0, max);
            }
            else
            {
                cad2 = cad;
            }
            return tam + cad2;
        }

        public static string convertidor_a_monedas(string cadena)
        {
            //if (cadena.IndexOf(".") == -1)
            //{
            //    cadena = "  " + cadena + ".00";
            //}
            //else
            //{
            //    string decimales = cadena.Substring(cadena.IndexOf("."));
            //    if(decimales.Length==2)
            //        cadena = "  " + cadena+"0";
            //    else
            //    cadena = "  " + cadena;
            //}
            double monto = Double.Parse(cadena);

            return String.Format("{0:$#,##0.00}", monto);
            //return cadena;
         }
        public static int contador_de_caracter_en_una_cadena(string cadena, string caracter)
        {
            int xResultado = 0;
            if (caracter.Length > 1)
            {
                System.Windows.Forms.MessageBox.Show("El parametro caracter solo permite un caracter, se retornará cero(0)");

            }
            else
            {
                xResultado =cadena.Length - cadena.Replace(caracter, "").Length;
            }
            return xResultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xValor"></param>
        /// <returns></returns>
        public static string RetornaBooleantoInt(Object xValor)
        {
            string Return="";
            if (Convert.ToInt32(xValor) > 0)
                Return= "True";
            else if (Convert.ToInt32(xValor) == 0)
                Return = "False";
            return Return;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xValor"></param>
        /// <returns></returns>
        public static string RetornaInttoBoolean(Object xValor)
        {
            string Return = "";
            if (xValor.ToString().ToUpper()=="TRUE")
                Return = "1";
            else if (xValor.ToString().ToUpper() == "FALSE")
                Return = "0";
            return Return;
        }
        /// <summary>
        /// Retorna SI en en formato cadena si es verdadero y NO en lo contrario.
        /// </summary>
        /// <param name="xValor">Tipo Booleano</param>
        /// <returns></returns>
        public static string RetornaSINOtoBoolean(Object xValor)
        {
            string Return = "";
            if (Convert.ToInt32(xValor) > 0)
                Return = "SI";
            else if (Convert.ToInt32(xValor) == 0)
                Return = "NO";
            return Return;
        }

        public static Int32 Instr(Int32 StartPos, String SearchString, String SearchFor, Int32 IgnoreCaseFlag)
        {
            Int32 result = -1;

            if (IgnoreCaseFlag == 1)
                result = SearchString.IndexOf(SearchFor, StartPos, StringComparison.OrdinalIgnoreCase);
            else
                result = SearchString.IndexOf(SearchFor, StartPos);



            return result;
        }

    }
}

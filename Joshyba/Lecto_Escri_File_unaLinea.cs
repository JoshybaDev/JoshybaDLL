using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Joshyba
{
    public class Lecto_Escri_File_unaLinea
    {
        StreamReader lectura;
        StreamWriter escritura;
        public string leyendo(string filename, int posicion)
        {
            string[] resultado = new string[100];
            string mientras = "";
            string contenido;
            int conteo = 0;
            int tamano;
            lectura = new StreamReader(filename);
            contenido = lectura.ReadLine();
            if (contenido != null)
            {
                tamano = contenido.Length;
                for (int i = 0; i < tamano; i++)
                {
                    if (contenido.Substring(i, 1) == ";")
                    {
                        resultado[conteo] = mientras;
                        conteo++;
                        mientras = "";
                    }
                    else
                    {
                        mientras += contenido.Substring(i, 1);
                    }
                }
                lectura.Close();
                return resultado[posicion];
            }
            else
            {
                lectura.Close(); return "";

            }

        }

        public void grabando(string filename2, string cadena)//+textBox.Text+";"
        {
            escritura = new StreamWriter(filename2);
            escritura.WriteLine(cadena);
            escritura.Close();
        }
    }
}

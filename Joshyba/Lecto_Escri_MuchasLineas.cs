using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Joshyba
{
    public class Lecto_Escri_MuchasLineas
    {
        Encoding Tipo;
        public Lecto_Escri_MuchasLineas()
        {
            Tipo = Encoding.UTF8;
        }
        public Lecto_Escri_MuchasLineas(System.Text.Encoding cual)
        {
            Tipo = cual;
        }
        
        StreamWriter escritura;
        private string nombre;
        /// <summary>
        /// Genera el nombre del archivo a trabajar
        /// </summary>
        /// <param name="Nombre"></param>
        
        public void Nombre_Archivo(string Nombre)
        {
            nombre = Nombre;
        }
        /// <summary>
        /// leer todas las lineas del archivo
        /// </summary>
        /// <param name="tamanio">Para crear el tamaño del arreglo que se va a retornar</param>
        public string[] Leer(int tamanio) //lee el archivo Data.dat
        {
            string[] cad = new string[tamanio];//arreglo que almacena
            int cont = 0;
            try
            {
                using (StreamReader sr = File.OpenText(nombre))
                {                    
                    String input;
                    while ((input = sr.ReadLine()) != null)
                    {
                        cad[cont] = input;//almacena la informacion en el arreglo
                        cont++;
                    }
                    sr.Close();
                }
                //if (cont < cad.Length)
                //{
                //    for (int x = cont; x <= cad.Length; x++)
                //        cad[x] = "";
                //}
                //MessageBox.Show("Bien");
                //for (int checar = 0; checar < tamanio; checar++)
                //{
                //    MessageBox.Show(cad[checar]);
                //}
                return cad;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"\n Tamaño de lectura="+tamanio+ "\n Tamaño de arreglo="+cad.Length,"Joshyba error");
                return cad;
            }
        }


        /// <summary>
        /// leer todas las lineas del archivo
        /// </summary>
        /// <param name="tamanio">Para crear el tamaño del arreglo que se va a retornar</param>
        public void Leer(ref DataGridView Data_Grid) //lee el archivo Data.dat
        {
            try
            {
                if (Data_Grid.Columns.Count > 0)
                {
                    using (StreamReader sr = File.OpenText(nombre))
                    {
                        String input;
                        while ((input = sr.ReadLine()) != null)
                        {
                            if (input.Length > 0 && input.Substring(0, 3) != "*.*" && input.Substring(0, 3) != "---")
                                Data_Grid.Rows.Add(input, 0);
                        }
                        sr.Close();
                    }
                }
                else
                {
                    MessageBox.Show("El datagrid debe de tener al menos una columna");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n Joshyba error");
            }
        }




        /// <summary>
        /// escribe todas las lineas del arreglo
        /// </summary>
        /// <param name="cadena"></param>
        public void escribir(string[] cadena)//escribe 
        {
            escritura = new StreamWriter(nombre, false, Tipo);//escribe el nuevo archivo
            for (int i = 0; i < cadena.Length; i++)
            {
                escritura.WriteLine(cadena[i]);//escribe la 1ra linea el nombre
            }
            escritura.Close(); //cierra la escritura
        }   

        public void crear_archivo_full()
        {
            escritura = new StreamWriter(nombre, false, Tipo);//escribe el nuevo archivo
        }



        /// <summary>
        /// Escribe una linea con salto de carro
        /// </summary>
        /// <param name="cadena"></param>
        public void escribir_linea_full(string cad)
        {
            escritura.WriteLine(cad);//escribe la 1ra linea el nombre
        }


        /// <summary>
        /// Escribe una linea con salto de carro
        /// </summary>
        /// <param name="cadena"></param>
        public void escribir_linea_sincarro(string cad)
        {
            escritura.Write(cad);
        }
        public void cerrar_archivo_full()
        {
            escritura.Close(); //cierra la escritura
        }

        public void guardar_archivo_full()
        {
            escritura.Flush(); //cierra la escritura
        }
    }
}

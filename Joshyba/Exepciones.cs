using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace Joshyba
{
    public static class Exepciones
    { 
        public static void Mostrar_Mensaje(Exception ex)
        {
            StackTrace st = new StackTrace(ex, true);
            StackFrame frame = st.GetFrame(st.FrameCount - 1);
            // Los datos separados de nuestra excepción   
            // se encuentran en la variable frame.  

            //Obtener el nombre de archivo  
            string fileName = frame.GetFileName();

            //Obtener el nombre del método  
            string nombreMetodo = frame.GetMethod().DeclaringType.Name;

            //Obtener el número de línea  
            int linea = frame.GetFileLineNumber();

            //Obtener el número de columna  
            int columna = frame.GetFileColumnNumber();

            //Obtener código del error  
            int codigo = frame.GetHashCode();




            MessageBox.Show("nombre del archivo: " + fileName + "\t\r nombre del metodo: " + nombreMetodo + "\t\r se ubica en la linea: " + linea.ToString() + "\t\r y en la columna: " + codigo.ToString());
        }
    }
}

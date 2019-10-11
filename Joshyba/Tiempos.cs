using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Joshyba
{
    public class Tiempos
    {
        //public static Tiempos tiempos;
        public Tiempos()
        {
            //Tiempos.tiempos = this;
        }
        /// <summary>
        /// Recibe los segundos y retorna el tiempo en horas:minutos:segundos
        /// </summary>
        /// <param name="tiempo"></param>
        /// <returns></returns>
        public static string tiempo_dividido(string tiempo)//super funcion que convierte los segundos
        {// en horas : minutos : segundos
            Int32 segundos = Convert.ToInt32(tiempo);
            int segun_final = segundos % 60;
            int minu = segundos / 60;
            int minutos = minu % 60;
            int horas = minu / 60;
            return horas.ToString() + ":" + minutos.ToString() + ":" + segun_final.ToString();// retorna el tiempos bien claro
        }
        /// <summary>
        /// Recibe la fecha dd/mm/yyyy y la retorna yyyy/mm/dd
        /// </summary>
        /// <param name="tiempo"></param>
        /// <returns></returns>		
        public static string retornafecha(DateTimePicker tiempo)
        {
            string fecha = String.Format("yyyy/mm/dd", tiempo.Value);
            return fecha;
        }
        /// <summary>
        /// Recibe la fecha yyyy/mm/dd y la retorna dd/mm/yyyy
        /// </summary>
        /// <param name="tiempo"></param>
        /// <returns></returns>		
        public static string retornafechaEuToMx(DateTimePicker tiempo)
        {
            string fecha = String.Format("dd/mm/yyyy", tiempo.Value);
            return fecha;
        }
        /// <summary>
        /// Recibe la fecha dd/mm/yyyy y la retorna yyyy/mm/dd
        /// </summary>
        /// <param name="tiempo"></param>
        /// <returns></returns>		
        public static string retornafecha(DateTime tiempo)
        {
            return tiempo.ToString().Substring(6, 4) + "/" + tiempo.ToString().Substring(3, 2) + "/" + tiempo.ToString().Substring(0, 2);
        }
        /// <summary>
        /// Recibe la fecha yyyy/mm/dd y la retorna dd/mm/yyyy
        /// </summary>
        /// <param name="tiempo"></param>
        /// <returns></returns>		
        public static string retornafechaEuToMx(DateTime tiempo)
        {
            return tiempo.ToString().Substring(8, 2) + "/" + tiempo.ToString().Substring(5, 2) + "/" + tiempo.ToString().Substring(0, 4);
        }
        /// <summary>
        /// Recibe la fecha dd/mm/yyyy y la retorna yyyy/mm/dd
        /// </summary>
        /// <param name="tiempo"></param>
        /// <returns></returns>
        public static string retornafecha(string tiempo)
        {
            return tiempo.ToString().Substring(6, 4) + "/" + tiempo.ToString().Substring(3, 2) + "/" + tiempo.ToString().Substring(0, 2);
        }
        /// <summary>
        /// Recibe la fecha yyyy/mm/dd y la retorna dd/mm/yyyy
        /// </summary>
        /// <param name="tiempo"></param>
        /// <returns></returns>
        public static string retornafechaEuToMx(string tiempo)
        {
            return tiempo.ToString().Substring(8, 2) + "/" + tiempo.ToString().Substring(5, 2) + "/" + tiempo.ToString().Substring(0, 4);
        }

        public static string Retornar_fin_de_mes_actual(DateTime Str_Date,string modo)
        {
            string modo2 = modo;
            string cad="";
            string mes_actual = String.Format("{0:MM}", Str_Date);
            int anio = int.Parse(String.Format("{0:yyyy}", Str_Date));
            if(modo== "ddmmyyyy")
            {
                switch(mes_actual)
                {
                    case "01":  
                        cad = "3101" + anio;
                        break;
                    case "02":
                        if (anio % 4 == 0)
                        {
                            cad = "2902" + anio;
                        }
                        else
                        {
                            cad = "2802" + anio;
                        }
                        break;
                    case "03":
                        cad = "3103" + anio;
                        break;
                    case "04":
                        cad = "3004" + anio;
                        break;
                    case "05":
                        cad = "3105" + anio;
                        break;
                    case "06":
                        cad = "3006" + anio;
                        break;
                    case "07":
                        cad = "3007" + anio;
                        break;
                    case "08":
                        cad = "3108" + anio;
                        break;
                    case "09":
                        cad = "3009" + anio;
                        break;
                    case "10":
                        cad = "3110" + anio;
                        break;
                    case "11":
                        cad = "3011" + anio;
                        break;
                    case "12":
                        cad = "3112" + anio;
                        break;
                }
            }
            else if(modo == "dd-mm-yyyy")
            {
                switch (mes_actual)
                {
                    case "01":
                        cad = "31-01-" + anio;
                        break;
                    case "02":
                        if (anio % 4 == 0)
                        {
                            cad = "29-02-" + anio;
                        }
                        else
                        {
                            cad = "28-02-" + anio;
                        }
                        break;
                    case "03":
                        cad = "31-03-" + anio;
                        break;
                    case "04":
                        cad = "30-04-" + anio;
                        break;
                    case "05":
                        cad = "3-105-" + anio;
                        break;
                    case "06":
                        cad = "30-06-" + anio;
                        break;
                    case "07":
                        cad = "30-07-" + anio;
                        break;
                    case "08":
                        cad = "31-08-" + anio;
                        break;
                    case "09":
                        cad = "30-09-" + anio;
                        break;
                    case "10":
                        cad = "31-10-" + anio;
                        break;
                    case "11":
                        cad = "30-11-" + anio;
                        break;
                    case "12":
                        cad = "31-12-" + anio;
                        break;
                }
            }
            else if (modo == "yyyymmdd"|| modo == "yyyyMMdd")
            {
                switch (mes_actual)
                {
                    case "01":
                        cad = anio + "0131";
                        break;
                    case "02":
                        if (anio % 4 == 0)
                        {
                            cad = anio + "0229";
                        }
                        else
                        {
                            cad = anio + "0228";
                        }
                        break;
                    case "03":
                        cad = anio + "0331";
                        break;
                    case "04":
                        cad = anio + "0430";
                        break;
                    case "05":
                        cad = anio + "0531";
                        break;
                    case "06":
                        cad = anio + "0630";
                        break;
                    case "07":
                        cad = anio + "0730";
                        break;
                    case "08":
                        cad = anio + "0831";
                        break;
                    case "09":
                        cad = anio + "0930";
                        break;
                    case "10":
                        cad = anio + "1031";
                        break;
                    case "11":
                        cad = anio + "1130";
                        break;
                    case "12":
                        cad = anio + "1231";
                        break;
                }
            }
            else if (modo2 == "dd/MM/yyyy" || modo2 == "dd/mm/yyyy")
            {
                switch (mes_actual)
                {
                    case "01":
                        cad = anio + "/01/31";
                        break;
                    case "02":
                        if (anio % 4 == 0)
                        {
                            cad = anio + "/02/29";
                        }
                        else
                        {
                            cad = anio + "/02/28";
                        }
                        break;
                    case "03":
                        cad = anio + "/03/31";
                        break;
                    case "04":
                        cad = anio + "/04/30";
                        break;
                    case "05":
                        cad = anio + "/05/31";
                        break;
                    case "06":
                        cad = anio + "/06/30";
                        break;
                    case "07":
                        cad = anio + "/07/30";
                        break;
                    case "08":
                        cad = anio + "/08/31";
                        break;
                    case "09":
                        cad = anio + "/09/30";
                        break;
                    case "10":
                        cad = anio + "/10/31";
                        break;
                    case "11":
                        cad = anio + "/11/30";
                        break;
                    case "12":
                        cad = anio + "/12/31";
                        break;
                }
            }
            return cad;
        }
        /*
month/day numbers without/with leading zeroes
String.Format("{0:M/d/yyyy}", dt);            // "3/9/2008"
String.Format("{0:MM/dd/yyyy}", dt);          // "03/09/2008"

// day/month names
String.Format("{0:ddd, MMM d, yyyy}", dt);    // "Sun, Mar 9, 2008"
String.Format("{0:dddd, MMMM d, yyyy}", dt);  // "Sunday, March 9, 2008"

// two/four digit year
String.Format("{0:MM/dd/yy}", dt);            // "03/09/08"
String.Format("{0:MM/dd/yyyy}", dt);          // "03/09/2008"
         */


        /*
 LIMPIAR TXT DE UN CONTENEDOR O FORM
         * 
         * 
forech(object control in this.controls)
{
if(control is a TextBox)
{
TextBox tx=(TextBox)control;
tx.Text=String.Empty;
}

}
Donde controls es el contenedor y control la variable 
         * 
         * 
         * 
         * 
          OBTENER LOS DATOS DE UNA MAQUINA C#
string maquina=string.Empty;

maquina += "Sistema operativo: " + Environment.OSVersion + "\n ";
maquina += "Version: " + Environment.Version + "\n ";
maquina += "Hostname: " + Environment.MachineName + "\n ";
maquina += "RAM: " + Environment.WorkingSet + "";
MessageBox.Show(maquina); 
         * 
         * 
         * 
CONVERTIR A BINARIO EN VB
Private Function GetPhoto(ByVal filePath As String) As Byte()

Dim stream As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
Dim reader As BinaryReader = New BinaryReader(stream)

Dim photo As Byte() = reader.ReadBytes(stream.Length)

reader.Close()
stream.Close()

Return photo

End Function 
         * * 
         * 
 RESTAR FECHAS C#
primero se necesita dos variables de tipo fecha y un objeto de tipo:
System.TimeSpan

System.TimeSpan diffResult = SiguienteFecha.Subtract(UltimaFecha);

el diffResult es el resultado de SiguienteFecha - la UltimaFecha y siempre es una variable taetime
con la propiedad day y esas cosas...

Estas son las variables de tipo DateTime
SiguienteFecha
UltimaFecha 
         * 
         * * 
         */

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Joshyba
{
    public class Conexion_SqlServer
    {
        public static Conexion_SqlServer Conec;
        public SqlConnection Conectado;
        public string Mensaje_Conexion;
        public string Cadena_Conexion = "";
        public Conexion_SqlServer()
        {
            Conexion_SqlServer.Conec = this;
        }
        public bool Iniciar_Conexion()
        {
            Conectado = new SqlConnection();
            Conectado.ConnectionString = Cadena_Conexion;
            //SalesApp.Properties.Settings.Default.conexion;
            try
            {
                Conectado.Open();
                return true;
            }
            catch (Exception e)
            {
                Mensaje_Conexion = e.Message.ToString();
                return false;

            }
        }
        public bool Iniciar_Conexion(string xServidor, string xBD, string xUsuario, string xPass, string xTiempo="10")
        {
            Cadena_Conexion = "data source=" + xServidor + ";Initial Catalog=" + xBD + ";User ID=" + xUsuario + ";Password=" + xPass + ";Connect Timeout=" + xTiempo;
            Conectado = new SqlConnection();
            Conectado.ConnectionString = Cadena_Conexion;
            //SalesApp.Properties.Settings.Default.conexion;
            try
            {
                Conectado.Open();
                return true;
            }
            catch (Exception e)
            {
                Mensaje_Conexion = e.Message.ToString();
                return false;

            }
        }
        public void Cerrar_Conexion()
        {
            Conectado.Close();
        }
    }
}

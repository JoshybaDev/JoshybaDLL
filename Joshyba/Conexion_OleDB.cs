using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
//"Data Source=" & xAbrir.FileName & "; Provider=Microsoft.ACE.OLEDB.12.0; Extended Properties=Excel 8.0;
namespace Joshyba
{
    public class Conexion_OleDB
    {
        public static Conexion_OleDB Conec;
        public OleDbConnection Conectado;
        public string Mensaje_Conexion;
        public string Cadena_Conexion = "";
        public Conexion_OleDB()
        {
            Conexion_OleDB.Conec = this;
        }

        public bool Iniciar_Conexion()
        {
            Conectado = new OleDbConnection();
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
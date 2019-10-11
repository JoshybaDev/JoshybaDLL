using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using MySql.Data;

namespace Joshyba
{
    public class Conexion_MySql
    {
        public static Conexion_MySql Conec;
        public MySqlConnection Conectado;
        public string Mensaje_Conexion;
        /// <summary>
        /// cadena de conexion para insertarla y realizar la conexion
        /// opc1.- SalesApp.Properties.Settings.Default.conexion;
        /// opc2.- "data source=localhost;database=videoclub;UID='root';PWD='admin'";
        /// </summary>
        public string Cadena_Conexion="";
        public Conexion_MySql()
        {
            Conexion_MySql.Conec = this;
        }
        public bool Iniciar_Conexion()
        {
            Conectado = new MySqlConnection();
            Conectado.ConnectionString = Cadena_Conexion;
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

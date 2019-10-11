using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using MySql.Data.Common;

namespace Joshyba
{
    public class Manejador_MySql
    {
        //public static Manejador_MySql manejamysql;
        public string mensaje_Error = "";
        public Manejador_MySql()
        {
            //Manejador_MySql.manejamysql = this;
        }
        /// <summary>
        /// Funcion que retorna un datareader para leer cada item del data de forma facil
        /// </summary>
        /// <param name="XCon"></param>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public MySqlDataReader DataReader_Ejecutar(MySqlConnection xCon, string xConsulta)
        {
            MySqlCommand xcomando = new MySqlCommand(xConsulta, xCon);
            MySqlDataReader xData;
            xData = xcomando.ExecuteReader();
            return xData;
        }
        /// <summary>
        /// Funcion que ejecuta de un procedimiento sin parametro
        /// secentencias select
        /// </summary>
        /// <param name="xCon">nombre de la conexion activa</param>
        /// <param name="Nombre_procedimiento">nombre del parametro o consulta</param>
        /// <returns></returns>
        public bool Datatable_Leer_Consultas(DataTable Datatable, MySqlConnection xCon, string xConsulta)
        {
            if (xConsulta.Substring(0, 1) == "_")
            {
                MySqlCommand CM = new MySqlCommand();
                CM.Connection = xCon;
                CM.CommandText = xConsulta;
                CM.CommandType = CommandType.StoredProcedure;
                try
                {
                    MySqlDataAdapter DA = new MySqlDataAdapter();
                    DA.SelectCommand = CM;
                    DA.Fill(Datatable);
                    return true;
                }
                catch (Exception es)
                {
                    mensaje_Error = es.Message.ToString();
                    return false;
                }
            }
            else
            {
                try
                {
                    MySqlDataAdapter oDataAdapter = new MySqlDataAdapter(xConsulta, xCon);
                    MySqlCommandBuilder oCommandBuild = new MySqlCommandBuilder(oDataAdapter);
                    oDataAdapter.Fill(Datatable);
                    return true;
                }
                catch (Exception es)
                {
                    mensaje_Error = es.Message.ToString();
                    return false;
                }
            }
        }
        /// <summary>
        /// Funcion que genera un data table de un procedimiento con parametros
        /// secentencias select
        /// <param name="Con">nombre de la conexion activa</param>
        /// <param name="consulta">la consulta a realizar</param>
        /// <param name="parametros">parametros</param>
        /// <returns></returns>
        public bool Datatable_Leer_Consultas(DataTable Rs, MySqlConnection xCon, string Nombre_procedimiento, object[,] parametros)
        {
            MySqlCommand CM = new MySqlCommand();
            CM.Connection = xCon;
            CM.CommandText = Nombre_procedimiento;
            CM.CommandType = CommandType.StoredProcedure;
            int tamanio = parametros.Length / 2;
            MySqlDataAdapter DA = new MySqlDataAdapter();
            for (int i = 0; i < tamanio; i++)
            {
                CM.Parameters.AddWithValue(parametros[i, 0].ToString(), parametros[i, 1]);
            }
            try
            {
                DA.SelectCommand = CM;
                DA.Fill(Rs);
                return true;
            }
            catch (Exception es)
            {
                mensaje_Error = es.Message.ToString();
                return false;
            }
        }
        /// <summary>
        /// Funcion que ejecuta de un procedimiento con parametros
        /// secentencias insert,delete,update
        /// </summary>
        /// <param name="xCon">nombre de la conexion activa</param>
        /// <param name="Nombre_procedimiento">nombre del parametro</param>
        /// <param name="parametros">parametros</param>
        /// <returns></returns>
        public bool _Datatable_Ejecutar_Consultas(MySqlConnection xCon, string Nombre_procedimiento, object[,] parametros = null)
        {
            MySqlCommand CM = new MySqlCommand();
            CM.Connection = xCon;
            CM.CommandText = Nombre_procedimiento;
            CM.CommandType = CommandType.StoredProcedure;
            int tamanio = parametros.Length / 2;
            for (int i = 0; i < tamanio; i++)
            {
                CM.Parameters.AddWithValue(parametros[i, 0].ToString(), parametros[i, 1]);
            }
            try
            {
                CM.ExecuteNonQuery();
                return true;
            }
            catch (Exception es)
            {
                mensaje_Error = es.Message.ToString();
                return false;
            }
        }
        /// <summary>
        /// Funcion que ejecuta de un procedimiento con parametros
        /// secentencias insert,delete,update
        /// </summary>
        /// <param name="xCon">nombre de la conexion activa</param>
        /// <param name="Nombre_procedimiento">nombre del parametro</param>
        /// <param name="parametros">parametros</param>
        /// <returns></returns>
        public bool _Datatable_Ejecutar_Consultas(MySqlConnection xCon, string Nombre_procedimiento)
        {
            try
            {
                DataTable Rs = new DataTable();
                MySqlDataAdapter oDataAdapter = new MySqlDataAdapter(Nombre_procedimiento, xCon);
                MySqlCommandBuilder oCommandBuild = new MySqlCommandBuilder(oDataAdapter);
                oDataAdapter.Fill(Rs);
                return true;
            }
            catch (Exception es)
            {
                mensaje_Error = es.Message.ToString();
                return false;
            }
        }
    }
}

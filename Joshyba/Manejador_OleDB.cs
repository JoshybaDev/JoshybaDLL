using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Joshyba
{
    public class Manejador_OleDB
    {
        //public static Manejador_OleDB manejaoledb;
        public string mensaje_Error = "";
        public Manejador_OleDB()
        {
            //Manejador_OleDB.manejaoledb = this;
        }
        /// <summary>
        /// Funcion que retorna un datareader para leer cada item del data de forma facil
        /// </summary>
        /// <param name="XCon"></param>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public OleDbDataReader DataReader_Ejecutar(OleDbConnection xCon, string xConsulta)
        {
            OleDbCommand xcomando = new OleDbCommand(xConsulta, xCon);
            OleDbDataReader xData;
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
        public bool Datatable_Leer_Consultas(DataTable Datatable, OleDbConnection xCon, string xConsulta)
        {
            if (xConsulta.Substring(0, 1) == "_")
            {
                OleDbCommand CM = new OleDbCommand();
                CM.Connection = xCon;
                CM.CommandText = xConsulta;
                CM.CommandType = CommandType.StoredProcedure;
                try
                {
                    OleDbDataAdapter DA = new OleDbDataAdapter();
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
                    OleDbDataAdapter oDataAdapter = new OleDbDataAdapter(xConsulta, xCon);
                    OleDbCommandBuilder oCommandBuild = new OleDbCommandBuilder(oDataAdapter);
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
        public bool Datatable_Leer_Consultas(DataTable Rs, OleDbConnection xCon, string Nombre_procedimiento, object[,] parametros)
        {
            OleDbCommand CM = new OleDbCommand();
            CM.Connection = xCon;
            CM.CommandText = Nombre_procedimiento;
            CM.CommandType = CommandType.StoredProcedure;
            int tamanio = parametros.Length / 2;
            OleDbDataAdapter DA = new OleDbDataAdapter();
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
        public bool _Datatable_Ejecutar_Consultas(OleDbConnection xCon, string Nombre_procedimiento, object[,] parametros = null)
        {
            OleDbCommand CM = new OleDbCommand();
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
        public bool _Datatable_Ejecutar_Consultas(OleDbConnection xCon, string Nombre_procedimiento)
        {
            try
            {
                DataTable Rs = new DataTable();
                OleDbDataAdapter oDataAdapter = new OleDbDataAdapter(Nombre_procedimiento, xCon);
                OleDbCommandBuilder oCommandBuild = new OleDbCommandBuilder(oDataAdapter);
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

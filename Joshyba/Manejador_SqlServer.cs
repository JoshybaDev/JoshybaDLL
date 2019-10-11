using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;


namespace Joshyba
{
    public class Manejador_SqlServer
    {
        //public static Manejador_SqlServer ManejadorSqlServer;
        public string mensaje_Error = "";
        public int Num_Filas_Afectadas = 0;
        Thread proceso_1;
        Formularios_Full mientras;


        public Manejador_SqlServer()
        {
            //Manejador_SqlServer.ManejadorSqlServer = this;
        }



        //private List<Parametros> parametros;


        /// <summary>
        /// Funcion que retorna un datareader para leer cada item del data de forma facil
        /// </summary>
        /// <param name="xCon">nombre de la conexion activa</param>
        /// <param name="xconsulta">la consulta a realizar</param>
        /// <returns></returns>
        public bool _Dtr_Ejecutar_Cosultas(SqlDataReader Datareader, SqlConnection xCon, string xconsulta)
        {
            if (xCon.State == ConnectionState.Broken || xCon.State == ConnectionState.Closed)
                xCon.Open();
            try
            {
                SqlCommand xcomando = new SqlCommand(xconsulta, xCon);
                Datareader = xcomando.ExecuteReader();
                return true;
            }
            catch (Exception es)
            {
                mensaje_Error = es.Message.ToString();
                return false;
            }
        }
        /***************************************************************************************************/
        /// <summary>
        /// Funcion que ejecuta de un procedimiento sin parametro
        /// secentencias select
        /// </summary>
        /// <param name="xCon">nombre de la conexion activa</param>
        /// <param name="Nombre_procedimiento">nombre del parametro o consulta</param>
        /// <returns></returns>
        public bool _Datatable_Leer_Consultas(DataTable Rs, SqlConnection xCon, string Consulta, int xEsProcedimiento = 1, SqlTransaction Transaccion = null)
        {
            if (xCon.State == ConnectionState.Broken || xCon.State == ConnectionState.Closed)
                xCon.Open();
            //if (xEsProcedimiento == 1)
            //{
                SqlCommand CM = new SqlCommand();
                CM.Connection = xCon;
                CM.CommandText = Consulta;
                if (xEsProcedimiento == 1)
                {
                    CM.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                   CM.CommandType = CommandType.Text;
                }

                CM.CommandTimeout = 1600;
                CM.Transaction = Transaccion;
                try
                {
                    SqlDataAdapter DA = new SqlDataAdapter();
                    DA.SelectCommand = CM;
                    Num_Filas_Afectadas = DA.Fill(Rs);
                    DA.Dispose();
                    DA=null;
                    return true;
                }
                catch (Exception es)
                {
                    if (Transaccion != null)
                    {
                        Transaccion.Rollback();
                        Transaccion = null;
                    }
                    mensaje_Error = es.Message.ToString();
                    return false;
                }
            //}
            //else
            //{
            //    try
            //    {
            //        SqlDataAdapter oDataAdapter = new SqlDataAdapter(Consulta, xCon);
            //        SqlCommandBuilder oCommandBuild = new SqlCommandBuilder(oDataAdapter);
            //        oDataAdapter.Fill(Rs);
            //        return true;
            //    }
            //    catch (Exception es)
            //    {
            //        mensaje_Error = es.Message.ToString();
            //        return false;
            //    }
            //}
        }
        /// <summary>
        /// Funcion que genera un data table de un procedimiento con parametros
        /// secentencias select
        /// <param name="Con">nombre de la conexion activa</param>
        /// <param name="consulta">la consulta a realizar</param>
        /// <param name="parametros">parametros</param>
        /// <returns></returns>
        public bool _Datatable_Leer_Consultas(DataTable Rs, SqlConnection xCon, string Nombre_procedimiento, object[,] parametros, bool hilo = false, SqlTransaction Transaccion = null)
        {
            if (xCon.State == ConnectionState.Broken || xCon.State == ConnectionState.Closed)
                xCon.Open();
            SqlCommand CM = new SqlCommand();
            CM.Connection = xCon;
            CM.CommandText = Nombre_procedimiento;
            CM.Transaction = Transaccion;
            CM.CommandType = CommandType.StoredProcedure;
            CM.CommandTimeout = 1600;
            int tamanio = parametros.Length / 2;
            SqlDataAdapter DA = new SqlDataAdapter();
            for (int i = 0; i < tamanio; i++)
            {
                CM.Parameters.AddWithValue((parametros[i, 0].ToString()), parametros[i, 1]);
            }
            try
            {

                DA.SelectCommand = CM;
                if (hilo == true)
                {
                    proceso_1 = new Thread(new ThreadStart(barra_de_espera));
                    proceso_1.Start();
                }
                Num_Filas_Afectadas = DA.Fill(Rs);
                //mientras.cerrar();
                if (hilo == true) proceso_1.Abort();
                return true;
            }
            catch (SqlException ex)
            {
                mensaje_Error = ex.Message.ToString();
                if (Transaccion != null)
                {
                    Transaccion.Rollback();
                    Transaccion = null;
                }
                return false;
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
        public bool _Datatable_Ejecutar_Consultas(SqlConnection xCon, string Nombre_procedimiento, object[,] parametros, SqlTransaction Transaccion = null)
        {
            if (xCon.State == ConnectionState.Broken || xCon.State == ConnectionState.Closed)
                xCon.Open();
            SqlCommand CM = new SqlCommand();
            CM.Connection = xCon;
            CM.CommandText = Nombre_procedimiento;
            CM.Transaction = Transaccion;
            CM.CommandType = CommandType.StoredProcedure;
            CM.CommandTimeout = 1600;
            int tamanio = parametros.Length / 2;
            for (int i = 0; i < tamanio; i++)
            {
                CM.Parameters.AddWithValue(parametros[i, 0].ToString(), parametros[i, 1]);
            }
            try
            {
                Num_Filas_Afectadas=CM.ExecuteNonQuery();
                return true;
            }
            catch (Exception es)
            {
                if (Transaccion != null)
                {
                    Transaccion.Rollback();
                    Transaccion = null;
                }
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
        public bool _Datatable_Ejecutar_Consultas(SqlConnection xCon, string Nombre_procedimiento, int xEsProcedimiento = 1, SqlTransaction Transaccion = null)
        {
            if (xCon.State == ConnectionState.Broken || xCon.State == ConnectionState.Closed)
                xCon.Open();
            try
            {
                //DataTable Rs = new DataTable();
                //SqlDataAdapter oDataAdapter = new SqlDataAdapter(Nombre_procedimiento, xCon);
                //SqlCommandBuilder oCommandBuild = new SqlCommandBuilder(oDataAdapter);
                //oDataAdapter.Fill(Rs);
                SqlCommand CM = new SqlCommand();
                CM.Connection = xCon;
                CM.Transaction = Transaccion;
                CM.CommandText = Nombre_procedimiento;
                if (xEsProcedimiento == 1)
                {
                    CM.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    CM.CommandType = CommandType.Text;
                }


                CM.CommandTimeout = 1600;
                Num_Filas_Afectadas = CM.ExecuteNonQuery();
                return true;
            }
            catch (Exception es)
            {
                mensaje_Error = es.Message.ToString();
                if (Transaccion != null)
                {
                    Transaccion.Rollback();
                    Transaccion = null;
                }
                return false;
            }
        }

        private void barra_de_espera()
        {
            mientras = new Formularios_Full();
            mientras.cantidad = 100;
            mientras.formulario("consultado la base de datos", "consultado la base de datos", 99);
        }


        //======================================================================================================================================
        //  Parametros a traves de Listas
        //======================================================================================================================================


        /// <summary>
        /// Funcion que genera un data table de un procedimiento con una lista parametros
        /// secentencias select
        /// <param name="Con">nombre de la conexion activa</param>
        /// <param name="consulta">la consulta a realizar</param>
        /// <param name="parametros">parametros</param>
        /// <returns></returns>
        public bool _Datatable_Leer_Consultas(DataTable Rs, SqlConnection xCon, string Nombre_procedimiento, List<Parametros> parametros, bool hilo = false, SqlTransaction Transaccion = null)
        {
            if (xCon.State == ConnectionState.Broken || xCon.State == ConnectionState.Closed)
                xCon.Open();
            SqlCommand CM = new SqlCommand();
            CM.Connection = xCon;
            CM.CommandText = Nombre_procedimiento;
            CM.Transaction = Transaccion;
            CM.CommandType = CommandType.StoredProcedure;
            CM.CommandTimeout = 1600;
            int tamanio = parametros.Count;
            SqlDataAdapter DA = new SqlDataAdapter();
            for (int i = 0; i < tamanio; i++)
            {
                CM.Parameters.AddWithValue(parametros[i].get_campo(), parametros[i].get_valor());
            }
            try
            {

                DA.SelectCommand = CM;
                if (hilo == true)
                {
                    proceso_1 = new Thread(new ThreadStart(barra_de_espera));
                    proceso_1.Start();
                }
                Num_Filas_Afectadas = DA.Fill(Rs);
                //mientras.cerrar();
                if (hilo == true) proceso_1.Abort();
                return true;
            }
            catch (SqlException ex)
            {
                mensaje_Error = ex.Message.ToString();
                if (Transaccion != null)
                {
                    Transaccion.Rollback();
                    Transaccion = null;
                }
                return false;
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
        public bool _Datatable_Ejecutar_Consultas(SqlConnection xCon, string Nombre_procedimiento, List<Parametros> parametros, SqlTransaction Transaccion = null)
        {
            if (xCon.State == ConnectionState.Broken || xCon.State == ConnectionState.Closed)
                xCon.Open();
            SqlCommand CM = new SqlCommand();
            CM.Connection = xCon;
            CM.CommandText = Nombre_procedimiento;
            CM.Transaction = Transaccion;
            CM.CommandType = CommandType.StoredProcedure;
            CM.CommandTimeout = 1600;
            int tamanio = parametros.Count;
            for (int i = 0; i < tamanio; i++)
            {
                CM.Parameters.AddWithValue(parametros[i].get_campo(), parametros[i].get_valor());
            }
            try
            {
                Num_Filas_Afectadas = CM.ExecuteNonQuery();
                return true;
            }
            catch (Exception es)
            {
                mensaje_Error = es.Message.ToString();
                if (Transaccion != null)
                {
                    Transaccion.Rollback();
                    Transaccion = null;
                }
                return false;
            }

        }
    }
}
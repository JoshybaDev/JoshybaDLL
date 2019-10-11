using System;
using System.Collections.Generic;
using System.Text;

namespace Joshyba
{
    public static class  generador_continuo
    {
        //public generador_continuo()
        //{
        // Las clases estaticas no pueden tener constructores de intancia
        //}
        //cadena_conexion almacena la cadena para realizacion la conexion
        //tabla contiene el nombre de la tabla de la cual se generará la reproduccion del identificaodr
        //idprincipal contiene el nombre del campo identificador
        //baseidentificador contiene las letras que forman parte de la clave
        //tamanio es el numero del cual se generara el identificador variable
        // ejemplo
        // Generar(conexion,'empleados','idempleado','EMP-',7);
        // esto generaria EMP-0000010
        // esto generaria EMP-0000910
        // valor maximo 9,999,9999
        //SELECT LAST_INSERT_ID() consulta que retorna el ultimo valor insertado en mysql
        //
        //
        //
        //
        //===>MsgBox(Joshyba.generador_continuo.Generar("sqlserver", "aditorias", "idauditoria", "2", "clave", "AUD-", 8))
        //
        //
        //
        public static string Generar(string cadena_conexion, string tabla, string idprincipal,string ValorId,string modificar, string baseidentificador, int tamanio)
        {
            //generando la reproduccion
            string incrementado = Cadenas.Generador2("0", tamanio, ValorId, "der");
            string resultado = "update "+tabla+ " set "+modificar+"='"+baseidentificador+incrementado+"' where "+idprincipal +"="+ValorId ;

            return resultado;
        }
    }
}

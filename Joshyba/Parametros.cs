using System;
using System.Collections.Generic;
using System.Text;

namespace Joshyba
{
    public class Parametros
    {
        private String Nombre_campo;
        private Object Valor;

        public Parametros() { }

        public Parametros(String campo, Object valor)
        {
            Nombre_campo=campo;
            Valor=valor;
        }
        public Parametros(String campo, Object[] valor)
        {
            Nombre_campo = campo;
            Valor = valor;
        }
        /// <summary>
        /// Retornar el nombre del campo
        /// </summary>
        /// <returns>String</returns>
        public String  get_campo()
        {
            return Nombre_campo;
        }
        /// <summary>
        /// Retorna el valor del campo
        /// </summary>
        /// <returns>Object</returns>
        public Object get_valor()
        {
            return Valor;
        }

        public void setCampo(Object xCampo)
        {
            Valor = xCampo;
        }

        public void setNombre_campo(String xNombre_Campo)
        {
            Nombre_campo = xNombre_Campo;
        }
    }
}

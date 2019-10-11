using System;
using System.Collections.Generic;
using System.Text;
/*
 * Autor: Ing. Jose Israel Gomez Rodriguez. (Joshyba)
 *clase para convertir numero a letras
 * 1=uno
 * 100=cien
 * 1000 = mil
 * 2569 = dos mil quinientos sesenta y nueve
 * 19 = diecinueve
 */
namespace Joshyba
{
    public class Numeros_a_Letras
    {
        public Numeros_a_Letras()
        {
        }
        string[] NumeroBase ={
                                 "",
                                 "uno",
                                 "dos",
                                 "tres",
                                 "cuatro",
                                 "cinco",
                                 "seis",
                                 "siete",
                                 "ocho",
                                 "nueve",
                                 "diez",
                                 "once",
                                 "doce",
                                 "trece",
                                 "catorce",
                                 "quince",
                                 "dieciseis",
                                 "diecisiete",
                                 "dieciocho",
                                 "diecinueve",
                            };
        string[] NumeroBase2 = {
                                   "",
                                   "",
                                   "veinte",
                                   "treinta",
                                   "cuarenta",
                                   "ciencuenta",
                                   "sesenta",
                                   "setenta",
                                   "ochenta",
                                   "noventa"
                               };
        /// <summary>
        /// Funcion que convierte numero en letras
        /// </summary>
        /// <param name="xNum">Un numero en forma de cadena</param>
        /// <returns></returns>
        public static string Convertir_Numero(string xNum)//convierte numeros enteros
        {
             Numeros_a_Letras xy=new Numeros_a_Letras();
            return xy.Numero(xNum);
        }

        /// <summary>
        /// Funcion que convierte numero en letras
        /// </summary>
        /// <param name="num">Un numero en forma de cadena</param>
        /// <param name="tipo">[mone] para representar monedas, [deci] para puntos decimal</param>
        /// <returns></returns>
        public static  string Convertir_Numero(string num, string tipo)//convrrte numeros decimales y a monedas
        {
            Numeros_a_Letras xy = new Numeros_a_Letras();
            return xy.Convertir_x(num, tipo);
        }

        private string Convertir_x(string num, string tipo)
        {
            string resultado = "";
            try
            {

                if (tipo == "deci")
                {
                    int posicion = 0;
                    posicion = num.IndexOf(".");
                    if (posicion == -1)
                        resultado = Numero(num);
                    else
                        resultado = Numero(num.Substring(0, posicion)) + " punto " + Numero(num.Substring(posicion + 1, num.Length - (posicion + 1)));
                }
                else
                {
                    int posicion = 0;
                    posicion = num.IndexOf(".");
                    if (posicion == -1)
                    {
                        resultado = Numero(num);
                        resultado += " PESOS 00/100 M.N.";
                    }
                    else
                    {
                        resultado = Numero(num.Substring(0, posicion)) + " PESOS ";
                        string xDecimales = "";
                        //xDecimales = Numero(num.Substring(posicion + 1, num.Length - (posicion + 1)));
                        xDecimales = num.Substring(posicion + 1, num.Length - (posicion + 1));
                        if (xDecimales.Length > 0)
                        {
                            if(xDecimales.Length==1)
                            {
                                resultado += xDecimales+"0";
                            }
                            else
                            {
                                resultado += xDecimales;
                            }
                        }
                        else
                        {
                            resultado += "00";
                        }
                        resultado += "/100 M.N.";
                    }
                }
            }
            catch (Exception EX)
            {
                System.Windows.Forms.MessageBox.Show(EX.Message);
            }
            return resultado;
        }
        private string Numero(string numx="")
        {
            string Resultado = "";
            int Tama_Cadena = numx.Length;
            if (Tama_Cadena < 4)//3
                Resultado = Trio(Tama_Cadena, numx);
            else if (Tama_Cadena < 7)//6
            {
                int millares = Tama_Cadena - 3;
                if(numx.Substring(0,1)=="1" && Tama_Cadena==4)
                    Resultado = "mil " + Trio(3, numx.Substring(millares, 3));
                else
                Resultado = Trio(millares, numx.Substring(0, millares)) + " mil " + Trio(3, numx.Substring(millares, 3));
            }
            else if (Tama_Cadena < 10)//9
            {
                int millares = Tama_Cadena - 3;
                int millon = Tama_Cadena - 6;
                if (numx.Substring(0, 1) == "1" && Tama_Cadena == 7)
                {
                    if (Trio(3, numx.Substring(millon, 3)) == "")
                    { 
                    Resultado = "un millon " + Trio(3, numx.Substring(millares, 3));
                    }
                else
                    {
                        Resultado = "millon " + Trio(3, numx.Substring(millon, 3)) + " mil " + Trio(3, numx.Substring(millares, 3));
                        if(numx.Substring(0, 1) == "1")
                        {
                            Resultado = "un " + Resultado;
                        }
                    }
                    
                        
                }
                else
				{
					string Mil="mil";
					if(Trio(3, numx.Substring(millares, 3))=="")
					{
						Mil="";
					}
					Resultado = Trio(millon, numx.Substring(0, millon)) + " millones " + Trio(3, numx.Substring(millon, 3)) + Mil + Trio(3, numx.Substring(millares, 3));
				}
            }
            else if (Tama_Cadena < 13)
			{
				string Mil="mil";
				if(Trio(3, numx.Substring(6, 3))=="")
				{
					Mil="";
				}				
                Resultado = Trio(3, numx.Substring(0, 3)) + " mil " + Trio(3, numx.Substring(3, 3)) + " milllones " + Trio(3, numx.Substring(6, 3)) + Mil + Trio(3, numx.Substring(9, 3));
			}
            else if (Tama_Cadena < 16)
                Resultado = Trio(3, numx.Substring(0, 3)) + " billones " + Trio(3, numx.Substring(4, 3)) + " mil " + Trio(3, numx.Substring(7, 3)) + " milllones " + Trio(3, numx.Substring(10, 3)) + " mil " + Trio(3, numx.Substring(13, 3));
            else if (Tama_Cadena < 19)
                Resultado = Trio(3, numx.Substring(0, 3)) + " mil " + Trio(3, numx.Substring(4, 3)) + " billones " + Trio(3, numx.Substring(7, 3)) + " mil " + Trio(3, numx.Substring(10, 3)) + " milllones " + Trio(3, numx.Substring(13, 3)) + " mil " + Trio(3, numx.Substring(13, 3));
            else if (Tama_Cadena < 21)
                Resultado = "";
            else if (Tama_Cadena < 24)
                Resultado = "";
            return Resultado;
        }
        string Unidades(string numx)
        {
            return NumeroBase[Convert.ToInt32(numx)];
        }
        string Decenas(string numx)
        {
            string Pre = "";
            int Num=Convert.ToInt32(numx);
            if (Num < 20)
            {
                Pre = NumeroBase[Num];
            }
            else
            {
                if (numx.Substring(0, 1) == "2")
                    Pre = NumeroBase2[2] + Unidades(numx.Substring(1, 1));
                else
                {
                    if (numx.Substring(1, 1) == "0")
                        Pre = NumeroBase2[Convert.ToInt32(numx.Substring(0, 1))];
                    else
                        Pre = NumeroBase2[Convert.ToInt32(numx.Substring(0, 1))] + " y " + Unidades(numx.Substring(1, 1));
                }
            }
            return Pre;
        }
         string Centenas(string numx)
        {
            string Pre = "";
            if (numx.Substring(0, 1) == "1")
            {
                if (numx.Substring(1, 1) == "0" && numx.Substring(2, 1) == "0")
                    Pre = "cien ";
                else
                    Pre = "ciento " + Decenas(numx.Substring(1, 2));
            }
            else if (numx.Substring(0, 1) == "0")
            {
                Pre = "" + Decenas(numx.Substring(1, 2));
            }
            else if (numx.Substring(0, 1) == "5")
            {
                Pre = "quinientos " + Decenas(numx.Substring(1, 2));
            }
            else if (numx.Substring(0, 1) == "7")
            {
                Pre = "setecientos " + Decenas(numx.Substring(1, 2));
            }
            else if (numx.Substring(0, 1) == "9")
            {
                Pre = "novecientos " + Decenas(numx.Substring(1, 2));
            }
            else
            {
                Pre = NumeroBase[Convert.ToInt32(numx.Substring(0, 1))] + "cientos " + Decenas(numx.Substring(1, 2));
            }
            return Pre;
        }
        string  Trio(int cant, string Val)
        {
            string CadenaFinal = "";
            switch (cant)
            {
                case 1:CadenaFinal = Unidades(Val);
                    break;
                case 2: CadenaFinal = Decenas(Val);
                    break;
                case 3: CadenaFinal = Centenas(Val);
                    break;
            }
            return CadenaFinal;
        }
    }
}

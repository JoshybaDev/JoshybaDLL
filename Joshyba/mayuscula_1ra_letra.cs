using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Joshyba
{
    public static class mayuscula_1ra_letra
    {
        public static string ConvertirPrimeraLetraEnMayuscula(string texto)
        {  
        string str = "";  
        str = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto);  
        return str;  
        }  
    }
}

/*
Ejemplo de uso:
view plaincopy to clipboardprint?

    string texto = "hola mundo";  
      
    texto = ConvertirPrimeraLetraEnMayuscula(texto);  
      
    Console.WriteLine (texto);  

El resultado de la impresión será: Hola Mundo
 * */
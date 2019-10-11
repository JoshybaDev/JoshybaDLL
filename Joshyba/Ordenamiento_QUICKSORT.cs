using System;
using System.Collections.Generic;
using System.Text;
//using System.Windows.Forms;

namespace Joshyba
{
    public class Ordenamiento_QUICKSORT
    {
        //public int[] arreglo;
        public string Cadena_Cuotas = "";
        public int[] ordernar(int[] vect)
        {
            int aux=0;
            for (int i = 0; i < vect.Length- 1; i++)
            {
                for (int j = 0; j < (vect.Length - 1) - i; j++)
                {                                 
                    if (vect[j] > vect[j+1] )
                    {                               
                        aux = vect[j];
                        //System.Console.WriteLine("aux="+ aux);
                        //MessageBox.Show("aux="+ aux);
                        vect[j] = vect[j+1];
                        //System.Console.WriteLine("vect[j+1]" + vect[j + 1]); 
                        //MessageBox.Show("vect[j+1]" + vect[j + 1]);
                        vect[j+1] = aux;
                        //System.Console.WriteLine("aux" + aux); 
                        //MessageBox.Show("aux" + aux);
                    }

                  }
            }
            return vect;
        }

        public void generar_num_tickets(ref int[] vect)
        {
            int[,] valores = new int[vect.Length,2];
            Cadena_Cuotas=Convert.ToString(vect[0]);
            valores[0, 0] = vect[0];
            valores[0, 1] = 1;
            for (int x = 0; x < vect.Length; x++)
            {
                if ((x + 1) < vect.Length - 1)
                {
                    if (vect[x] + 1 == vect[x + 1])
                    {
                        valores[x + 1, 0] = vect[x + 1];
                        valores[x + 1, 1] = 1;
                    }
                    else
                    {
                        valores[x + 1, 0] = vect[x + 1];
                        valores[x + 1, 1] = 0;
                    }
                }
                else if (x == vect.Length - 1)
                {
                    if (vect[x]-1 == vect[x - 1])
                    {
                        valores[x, 0] = vect[x];
                        valores[x, 1] = 1;
                    }
                    else
                    {
                        valores[x, 0] = vect[x];
                        valores[x, 1] = 0;
                    }
                }
                //else
                //{
                //    valores[x, 0] = vect[x];
                //    valores[x, 1] = 1;
                //}
            }
            //////////////////////////////////////////////
            ///2  creacion de los tikets
            ///////////////////////////////////////////////

            for (int x = 1; x < vect.Length; x++)
            {
                if (valores[x, 1] == 0 && x < (vect.Length))
                {
                    Cadena_Cuotas += ("-" + valores[x-1, 0]);
                    Cadena_Cuotas += ("," + valores[x, 0]);
                }
                else if (valores[x, 1] == 1 && x == (vect.Length-1))
                {
                    Cadena_Cuotas += ("-" + valores[x, 0]);
                }
            }
        }
    }

}


/****
# Numerical Sequences Generator
# Generates several mathematical sequences by calculating their terms individually
# Language: Python

# 2018, Jose Cintra
# josecintra@josecintra.com

# initialization
import math 
formulas = {'Fibonacci numbers': ['round((pow((1+math.sqrt(5))/2,i)-
                         pow((1-math.sqrt(5))/2,i))/ math.sqrt(5))',1],
            'Lucas numbers':['((1 + math.sqrt(5))/2) ** i + ((1 - math.sqrt(5))/2) ** i',0],
            'Triangular numbers': ['(i*(i+1))/2',1],
            'Square numbers': ['i*i',1],
            'Pentagonal numbers': ['(i*(3*i-1))/2',1],
            'Hexagonal numbers': ['i*(2*i-1)',1],
            'Catalan numbers': ['math.factorial(2*i)/(math.factorial(i+1)*math.factorial(i))',0],
            'Cullen numbers': ['i*2**i + 1',0],
            'Pronic numbers': ['i*(i+1)',0],
            'Woodall numbers': ['i*2**i-1',1]
           }

# Data entry
print("Mathematical sequences generator\n")
n = int(input("Enter the number of terms in the sequence: "))

# shows the sequences
for key,value in formulas.items():
  print()
  print (key)
  start = value[1]
  for i in range(0, (n + start)):
    item = int(eval(value[0]))
    if (i < start) :
      continue
    print(item,'  ', end = '')
  print()
        
# end
****/

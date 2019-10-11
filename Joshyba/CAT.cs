using System;
using System.Text;
using System.Windows.Forms;

namespace Joshyba
{
    public class CAT
    {
        //public static CAT cat;
        public CAT()
        {
            //CAT.cat = this;
        }
        /// <summary>
        /// funcion exclusiva para visual basic
        /// </summary>
        /// <param name="cuotas"></param>
        /// <param name="monto"></param>
        /// <param name="pagoinicial"></param>
        /// <param name="tipo_cuota"></param>
        /// <param name="hy"></param>
        /// <returns></returns>
        public double Calcular_cat(double[] cuotas, double monto, double pagoinicial, double tipo_cuota,double NumDias = 0)
        {
            //MessageBox.Show(" "+cuotas.Length);
            DataGridView dgv_cuotas = new DataGridView();
            dgv_cuotas.ColumnCount = 1;
            dgv_cuotas.AllowUserToAddRows = false;
            dgv_cuotas.AllowUserToDeleteRows = false;
            for (int i = 0; i < cuotas.Length; i++)
            {
                Application.DoEvents();
                dgv_cuotas.Rows.Add(cuotas[i]);
            }
            double vExponente, vNumerador, vDenominador;
            double vCat;
            double vSuma = 0;

            ulong vMontoMinimo, vMontoMaximo;
            bool vFlag;

            vFlag = true;
            vMontoMinimo = (ulong)(monto - monto * 0.0001);
            vMontoMaximo = (ulong)(monto + monto * 0.0001);

            vCat = 0.0001;
            if (NumDias > 0)
            {
                if (tipo_cuota != 360) NumDias = NumDias * tipo_cuota;
            }
            while (vFlag == true)
            {
                Application.DoEvents();
                vSuma = 0;
                if (NumDias >0)
                {
                    vExponente = NumDias / 360;
                    vNumerador = double.Parse(dgv_cuotas.Rows[0].Cells[0].Value.ToString());
                    vDenominador = Math.Pow((1 + vCat), vExponente);
                    vSuma = vSuma + (vNumerador / vDenominador);
                }
                else
                {
                    if (pagoinicial > 0)
                    {
                        for (int i = 1; i < dgv_cuotas.Rows.Count; i++)
                        {
                            vExponente = (double)i / tipo_cuota;
                            vNumerador = double.Parse(dgv_cuotas.Rows[i].Cells[i-1].Value.ToString());
                            vDenominador = Math.Pow((1 + vCat), vExponente);
                            vSuma = vSuma + (vNumerador / vDenominador);
                        }
                        vSuma = vSuma + (pagoinicial / Math.Pow((1 + vCat), (0 / tipo_cuota)));
                    }
                    else
                    {
                        for (int i = 0; i < dgv_cuotas.Rows.Count; i++)
                        {
                            vExponente = (double)i / tipo_cuota;
                            vNumerador = double.Parse(dgv_cuotas.Rows[i].Cells[0].Value.ToString());
                            vDenominador = Math.Pow((1 + vCat), vExponente);
                            vSuma = vSuma + (vNumerador / vDenominador);
                        }
                    }
                }
                if ((Math.Round(vSuma,2)) >= (Math.Round((double)(vMontoMinimo),0)) && (Math.Round(vSuma,2)) <= (Math.Round((double)vMontoMaximo,0)))
                {
                    vFlag = false;
                    vCat = Math.Round(vCat, 4);
                }
                else
                {
                    if (vSuma > vMontoMaximo)
                    {
                        vCat = vCat + 0.0001;
                    }
                    else if (vSuma < vMontoMinimo)
                    {
                        vCat = vCat - 0.0001;
                    }
                }
                if (vCat > 1) vFlag = false; ;
            }
            return vCat;
        }
        //======================= PARA CALCULAR MONTOS MAYORES O IGUALES A 12000 - PAGO DE APERTURA
        public double Calcular_cat_derecho(double[] cuotas, double monto, double pagoinicial, double tipo_cuota,bool Log,ref Form formu)
        {
            Joshyba.Lecto_Escri_MuchasLineas escribo= new Joshyba.Lecto_Escri_MuchasLineas();
            if (Log == true)
            {
                escribo.Nombre_Archivo("prueba.txt");
                escribo.crear_archivo_full();
            }
            double vExponente, vNumerador, vDenominador;
            double vCat=0.0001;
            double vSuma = 0;

            ulong vMontoMinimo, vMontoMaximo;
            bool vFlag;
            vFlag = true;
            vMontoMinimo = (ulong)(monto - monto * 0.0001);
            vMontoMaximo = (ulong)(monto + monto * 0.0001);

            vCat = 0.001;
            while (vFlag == true)
            {
                        vSuma = 0;
                for (int i = 0; i < cuotas.Length-1; i++)
                {
                    vExponente = (double)(i+1) / tipo_cuota;
                    vNumerador = cuotas[i];
                    vDenominador = Math.Pow((1 + vCat), vExponente);
                    vSuma = vSuma + (vNumerador / Math.Round(vDenominador,8));
                    if (Log == true)
                        escribo.escribir_linea_full("monto " + monto + "tipocuota " + tipo_cuota + " vcat: " + vCat + " cuota " + i + "  vsuma" + vSuma + "exp " + vExponente + " numera: " + vNumerador + " denonima: " + vDenominador);
                }
                vSuma = vSuma + pagoinicial;
                if (vSuma < vMontoMaximo && vSuma>=monto)
                {
                    vFlag = false;
                    vCat = Math.Round(vCat, 4);
                    if (Log == true)
                    {
                        escribo.escribir_linea_full("Fue exacto");
                        escribo.escribir_linea_full("sumando " + vCat.ToString() + " --- " + vSuma);
                        escribo.cerrar_archivo_full();
                    }
                }
                else if (vSuma >= vMontoMaximo && vSuma<=vMontoMinimo)
                {
                    vFlag = false;
                    if (Log == true)
                    {
                        escribo.escribir_linea_full("Fue mayor");
                        escribo.escribir_linea_full("sumando " + vCat.ToString() + " --- " + vSuma);
                        escribo.cerrar_archivo_full();
                    }
                }
                else
                {
                    vCat = vCat + (vCat * 0.0001);
                        if (Log == true)  escribo.escribir_linea_full("sumando " + vCat.ToString() + " --- " + vSuma);
                }
            }
            return vCat;
        }
    }
}
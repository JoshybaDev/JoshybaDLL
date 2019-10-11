using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;


namespace Joshyba
{
    public class CSV_FULL
    {
        private DialogResult resultado;
        OpenFileDialog archivoa = new OpenFileDialog();
        private string Archivo = "";
        public CSV_FULL()
        {

        }
        public void Buscar_archivo()
        {
            archivoa.Title = "Abrir Archivo de CSV";
            archivoa.Filter = "Todos *.csv|";
            resultado = archivoa.ShowDialog();
        }
        public void Retornar_Datatble(ref DataTable Rs,char separador)
        {
            if (resultado == DialogResult.OK)
            {
                Archivo = archivoa.FileName;
                if (Archivo.Length > 0)
                {
                    DataRow fila;
                    int i = 0;
                    String[] Valores;
                    StreamReader Leer;
                    int contar = 0;
                    try
                    {
                        Leer = File.OpenText(Archivo);
                        Valores = Leer.ReadLine().Split(separador);
                        Formularios_Full F_F = new Formularios_Full();
                        F_F.cantidad = 200000;
                        F_F.formulario("Leyendo archivo CSV", "0 fila");
                        for (i = 0; i <= Valores.Length - 1; i++)
                        {
                            Rs.Columns.Add(new DataColumn(" "+Valores[i].ToString()));
                        }
                        Leer.Close();
                        Leer = File.OpenText(Archivo);
                        while (Leer.Peek() != -1)
                        {
                            Valores = Leer.ReadLine().Split(separador);
                            fila = Rs.NewRow();
                            for (i = 0; i <= Valores.Length - 1; i++)
                            {
                                fila[i] = Valores[i].ToString();
                            }
                            Rs.Rows.Add(fila);
                            contar++;
                            F_F.incrementar(contar, "" + contar + " filas");
                        }
                        Leer.Close();
                        F_F.cerrar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}

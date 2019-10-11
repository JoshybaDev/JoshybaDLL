using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Joshyba.Controles
{
    public class datagridview
    {
        public static void MarcarConBotonDerechoMouse(ref DataGridView Grid,  MouseEventArgs e)
        {
            DataGridView.HitTestInfo Hitest = Grid.HitTest(e.X, e.Y);
            if(Hitest.Type==DataGridViewHitTestType.Cell)
            {
                Grid.CurrentCell = Grid.Rows[Hitest.RowIndex].Cells[Hitest.ColumnIndex];
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Grid">DataGridView a aplicar el formato automatico</param>
        public static void pintar_datagridview(ref DataGridView Grid, bool xElegirTodaFila = true)
        {
            //formato column
            Grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //formato row
            Grid.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point,Convert.ToByte(0));
            Grid.ForeColor = System.Drawing.Color.Black;
            Grid.RowHeadersVisible = false;
            Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            Grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.AllowUserToAddRows = false;
            Grid.AllowUserToDeleteRows = false;
            Grid.GridColor = Color.OldLace;
            Grid.BackgroundColor = Color.White;
            Grid.ScrollBars = ScrollBars.Both;
            //Variables
            if (xElegirTodaFila) Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        }	

		//===============================================>
        public static void pintar_datagridview(ref DataGridView Grid, bool TodosNotSortable, bool xElegirTodaFila = true)
        {
            Grid.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point,Convert.ToByte(0));
            Grid.ForeColor = System.Drawing.Color.Black;
            if(xElegirTodaFila) Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            Grid.RowHeadersVisible = false;
            Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen;
            Grid.BackgroundColor = Color.White;
            int posicion = 0;
			
			if(TodosNotSortable)
			{		
				for(int z=0;z<Grid.Columns.Count;z++)
				{
				Grid.Columns[z].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
            try
            {
                //para checar las columnas
                for (int z = 0; z < Grid.Columns.Count; z++)
                {
                    if (Grid.Columns[z].ValueType.ToString() == "System.Decimal")
                    {
                        Grid.Columns[z].DefaultCellStyle.Format = "c";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Registro = " + posicion + " num registros " + (Grid.Rows.Count-1));
                Exepciones.Mostrar_Mensaje(ex);
            }
        }


        public static void convertir_a_datatable(ref DataGridView dgv, ref DataTable dt, String[] SystemTypes=null)
        {
            //DataTable dt = new DataTable();
            //DataColumn[] dcs = new DataColumn[] { };
            int x=0;
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                
                //MessageBox.Show(c.Name + " " + x);
                try
                {
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = c.Name;
                    if (SystemTypes != null)
                    {
                        dc.DataType = System.Type.GetType(SystemTypes[x]);
                        x++;
                    }
                    else
                    {
       
                        
                        if (c.ValueType == null)
                        {
                            dc.DataType = System.Type.GetType("System.String");
                        }
                        else
                        {
                            dc.DataType = c.ValueType;
                        }
                    }
                    dt.Columns.Add(dc);
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                    //throw;
                }


            }

            //MessageBox.Show("terminado");
            foreach (DataGridViewRow r in dgv.Rows)
            {
                DataRow drow = dt.NewRow();

                foreach (DataGridViewCell cell in r.Cells)
                {
                    drow[cell.OwningColumn.Name] = cell.Value;
                }

                dt.Rows.Add(drow);
            }  
        }
    }
}

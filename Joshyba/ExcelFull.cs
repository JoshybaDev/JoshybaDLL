using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.CSharp;
using Microsoft.Office.Interop.Excel;
namespace Joshyba
{
    public class ExcelFull
    {
        //public static ExcelFull excell_full;
        private string Archivo = "";
        private DialogResult resultado;
        OpenFileDialog archivoa = new OpenFileDialog();
        private int cantidad = 0;
        private Barra_Progreso_2 progreso;
        private Form Cargando;
        public ExcelFull()
        {
            //ExcelFull.excell_full = this;
        }
        ///
        /// Abre el cuadro de dialogo abrir para leer el nombre del archivo de excel
        public void Buscar_archivo()
        {
            archivoa.Title = "Abrir Archivo de excel";
            archivoa.Filter = "Todos *.xls|*.xls*|Archivo XLS|*.xls|Archivo XLSX|*.xlsx";
            resultado = archivoa.ShowDialog();
        }
        /// Abre el cuadro de dialogo abrir para leer el nombre del archivo de excel
        /// ademas retoran el nombre ruta del  archivo para alguna cosa
        public string Buscar_archivo(int retornar)
        {
            archivoa.Title = "Abrir Archivo de excel";
            archivoa.Filter = "Todos *.xls|*.xls*|Archivo XLS|*.xls|Archivo XLSX|*.xlsx";
            resultado = archivoa.ShowDialog();
            return Archivo = archivoa.FileName;
        }
        /// <summary>
        /// retorna el numero de filas para usarlo para alguna informacion
        /// </summary>
        /// <returns></returns>

        public string retornar_num_filas()
        {
            if (resultado == DialogResult.OK)
            {
                string cant = "";
                Workbook Libro;
                Worksheet Hoja;
                Microsoft.Office.Interop.Excel.Application wapp = default(Microsoft.Office.Interop.Excel.Application);
                wapp = new Microsoft.Office.Interop.Excel.Application();
                Libro = wapp.Workbooks.Open(Archivo);
                Hoja = (Microsoft.Office.Interop.Excel.Worksheet)Libro.Worksheets.get_Item(1);
                Range xlRangos;
                xlRangos = Hoja.UsedRange;
                cant = xlRangos.Rows.Count.ToString();
                Libro.Close();
                wapp.Quit();
                return cant;
            }
            else
            {
                return "";
            }
        }

        public void incrementar(int incremento)
        {
            if (progreso.Value1 == cantidad)
            {
                Cargando.Close();
                MessageBox.Show("Carga terminada");
            }
            progreso.Value1 = incremento;
        }
        //lee el archivo excel y almacena el contenido del excel en un datagridview
        public void Cargar_datagridview(ref DataGridView contentexcell, bool msj = true)
        {
            if (resultado == DialogResult.OK)
            {
                Archivo = archivoa.FileName;
                if (Archivo.Length > 0)
                {
                    Workbook Libro;
                    Worksheet Hoja;
                    Cargando = new Form();
                    progreso = new Barra_Progreso_2();
                    System.Windows.Forms.Label Info = new System.Windows.Forms.Label();
                    progreso.Location = new System.Drawing.Point(24, 12);
                    progreso.Name = "progreso";
                    progreso.Size = new System.Drawing.Size(361, 54);

                    Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
                    Info.Location = new System.Drawing.Point(26, 80);
                    Info.Name = "Info";
                    Info.Size = new System.Drawing.Size(358, 51);
                    Info.Text = "Cargando 8 de 10000 filas";
                    Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    Cargando.Text = "Leyendo Archivo de excel";
                    Cargando.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                    Cargando.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    Cargando.ClientSize = new System.Drawing.Size(397, 135);
                    Cargando.Controls.Add(progreso);
                    Cargando.Controls.Add(Info);
                    Cargando.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Cargando.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    Cargando.ResumeLayout(false);
                    Cargando.Show();
                    Microsoft.Office.Interop.Excel.Application wapp = default(Microsoft.Office.Interop.Excel.Application);
                    wapp = new Microsoft.Office.Interop.Excel.Application();
                    Libro = wapp.Workbooks.Open(Archivo);
                    Hoja = (Microsoft.Office.Interop.Excel.Worksheet)Libro.Worksheets.get_Item(1);
                    Range xlRangos;
                    xlRangos = Hoja.UsedRange;
                    contentexcell.ColumnCount = xlRangos.Columns.Count;
                    for (int j = 1; j <= xlRangos.Columns.Count; j++)
                    {
                        contentexcell.Columns[j - 1].Name = "" + (xlRangos.Cells[1, j] as Range).Value + "";
                    }
                    progreso.Minimum1 = 0;
                    progreso.ProgressBarColor = Color.FromArgb(150, 0, 0);
                    contentexcell.RowCount = xlRangos.Rows.Count;
                    progreso.Maximum1 = contentexcell.RowCount;
                    for (int i = 1; i <= xlRangos.Rows.Count; i++)
                    {
                        for (int j = 1; j <= xlRangos.Columns.Count; j++)
                        {
                            contentexcell.Rows[i - 1].Cells[j - 1].Value = "" + (xlRangos.Cells[i, j] as Range).Text + "";
                        }
                        progreso.Value1 = i;

                        Info.Text = "Cargando " + i + " de " + contentexcell.RowCount + " filas";
                    }
                    Cargando.Close();
                    Libro.Close();
                    wapp.Quit();
                    if (msj) Joshyba.mensaje_temporal.Show("Carga terminada", "JoshybaDLL", 2, false);
                }
            }
        }

        public void Cargar_datagridview(ref DataGridView contentexcell, bool msj, bool num_filas = false)
        {
            if (resultado == DialogResult.OK)
            {
                Archivo = archivoa.FileName;
                if (Archivo.Length > 0)
                {
                    Workbook Libro;
                    Worksheet Hoja;
                    Cargando = new Form();
                    progreso = new Barra_Progreso_2();
                    System.Windows.Forms.Label Info = new System.Windows.Forms.Label();
                    progreso.Location = new System.Drawing.Point(24, 12);
                    progreso.Name = "progreso";
                    progreso.Size = new System.Drawing.Size(361, 54);

                    Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
                    Info.Location = new System.Drawing.Point(26, 80);
                    Info.Name = "Info";
                    Info.Size = new System.Drawing.Size(358, 51);
                    Info.Text = "Cargando 8 de 10000 filas";
                    Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    Cargando.Text = "Leyendo Archivo de excel";
                    Cargando.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                    Cargando.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    Cargando.ClientSize = new System.Drawing.Size(397, 135);
                    Cargando.Controls.Add(progreso);
                    Cargando.Controls.Add(Info);
                    Cargando.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Cargando.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    Cargando.ResumeLayout(false);
                    Microsoft.Office.Interop.Excel.Application wapp = default(Microsoft.Office.Interop.Excel.Application);
                    wapp = new Microsoft.Office.Interop.Excel.Application();
                    Libro = wapp.Workbooks.Open(Archivo);
                    Hoja = (Microsoft.Office.Interop.Excel.Worksheet)Libro.Worksheets.get_Item(1);
                    Range xlRangos;
                    xlRangos = Hoja.UsedRange;
                    if (num_filas)
                    {
                        contentexcell.ColumnCount = xlRangos.Columns.Count + 1;
                        contentexcell.Columns[0].Name = "NUMFILA";
                        for (int j = 2; j <= xlRangos.Columns.Count + 1; j++)
                        {
                            contentexcell.Columns[j - 1].Name = "" + (xlRangos.Cells[1, j - 1] as Range).Value + "";
                            //MessageBox.Show("" + (xlRangos.Cells[1, j - 1] as Range).Value + " J=" + j + " Columns.Count=" + xlRangos.Columns.Count);
                        }
                        progreso.Minimum1 = 0;
                        progreso.ProgressBarColor = Color.FromArgb(150, 0, 0);
                        contentexcell.RowCount = xlRangos.Rows.Count;
                        progreso.Maximum1 = contentexcell.RowCount;
                        for (int i = 1; i <= xlRangos.Rows.Count; i++)
                        {
                            for (int j = 1; j <= xlRangos.Columns.Count; j++)
                            {
                                contentexcell.Rows[i - 1].Cells[0].Value = "" + (i - 1);
                                contentexcell.Rows[i - 1].Cells[(j + 1) - 1].Value = "" + (xlRangos.Cells[i, j] as Range).Text + "";
                            }
                            progreso.Value1 = i;

                            Info.Text = "Cargando " + i + " de " + contentexcell.RowCount + " filas";
                        }
                    }
                    else
                    {
                        contentexcell.ColumnCount = xlRangos.Columns.Count;
                        for (int j = 1; j <= xlRangos.Columns.Count; j++)
                        {
                            contentexcell.Columns[j - 1].Name = "" + (xlRangos.Cells[1, j] as Range).Value + "";
                        }
                        progreso.Minimum1 = 0;
                        progreso.ProgressBarColor = Color.FromArgb(150, 0, 0);
                        contentexcell.RowCount = xlRangos.Rows.Count;
                        progreso.Maximum1 = contentexcell.RowCount;
                        for (int i = 1; i <= xlRangos.Rows.Count; i++)
                        {
                            for (int j = 1; j <= xlRangos.Columns.Count; j++)
                            {
                                contentexcell.Rows[i - 1].Cells[j - 1].Value = "" + (xlRangos.Cells[i, j] as Range).Text + "";
                            }
                            progreso.Value1 = i;

                            Info.Text = "Cargando " + i + " de " + contentexcell.RowCount + " filas";
                        }
                    }
                    Cargando.Close();
                    Libro.Close();
                    wapp.Quit();
                    if (msj) Joshyba.mensaje_temporal.Show("Carga terminada", "JoshybaDLL", 2, false);
                }
            }
        }
        //lee el archivo excel y almacena el contenido del excel en la base de datos
        public void Cargar_y_Guardar(string[] variables, string procedimiento, string cadenaConexion, int tamanio)
        {
            if (resultado == DialogResult.OK)
            {
                Archivo = archivoa.FileName;
                if (Archivo.Length > 0)
                {

                    Workbook Libro;
                    Worksheet Hoja;
                    Cargando = new Form();
                    progreso = new Joshyba.Barra_Progreso_2();
                    System.Windows.Forms.Label Info = new System.Windows.Forms.Label();
                    progreso.Location = new System.Drawing.Point(24, 12);
                    progreso.Name = "progreso";
                    progreso.Size = new System.Drawing.Size(361, 54);

                    Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
                    Info.Location = new System.Drawing.Point(26, 80);
                    Info.Name = "Info";
                    Info.Size = new System.Drawing.Size(358, 51);
                    Info.Text = "Cargando 8 de 10000 filas";
                    Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    Cargando.Text = "Leyendo Archivo de excel";
                    Cargando.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                    Cargando.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    Cargando.ClientSize = new System.Drawing.Size(397, 135);
                    Cargando.Controls.Add(progreso);
                    Cargando.Controls.Add(Info);
                    Cargando.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Cargando.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    Cargando.ResumeLayout(false);
                    Cargando.Show();

                    Microsoft.Office.Interop.Excel.Application wapp = default(Microsoft.Office.Interop.Excel.Application);
                    wapp = new Microsoft.Office.Interop.Excel.Application();
                    Libro = wapp.Workbooks.Open(Archivo);
                    Hoja = (Microsoft.Office.Interop.Excel.Worksheet)Libro.Worksheets.get_Item(1);
                    Range xlRangos;
                    xlRangos = Hoja.UsedRange;
                    cantidad = xlRangos.Rows.Count;
                    progreso.Maximum = cantidad;
                    Manejador_SqlServer Consulta = new Manejador_SqlServer();
                    Conexion_SqlServer Conexion = new Conexion_SqlServer();
                    Conexion.Cadena_Conexion = cadenaConexion;
                    Conexion.Iniciar_Conexion();
                    string[,] parametros;

                    for (int i = 2; i <= xlRangos.Rows.Count; i++)
                    {
                        parametros = new string[tamanio, 2];
                        for (int j = 1; j <= xlRangos.Columns.Count; j++)
                        {
                            //contentexcell.Rows[i - 1].Cells[j - 1].Value = "" + (xlRangos.Cells[i, j] as Range).Value + "";
                            parametros[j - 1, 0] = variables[j - 1];
                            parametros[j - 1, 1] = "" + (xlRangos.Cells[i, j] as Range).Text + "";
                        }
                        if (parametros[0, 1].Length > 0)
                        {
                            if (Consulta._Datatable_Ejecutar_Consultas(Conexion.Conectado, procedimiento, parametros))
                            {
                            }
                        }
                        progreso.Value = i;
                        Info.Text = "Cargando " + i + " de " + cantidad + " filas";
                    }
                    if (progreso.Value == cantidad) Cargando.Close();
                    Libro.Close();
                    wapp.Quit();
                    Joshyba.mensaje_temporal.Show("Carga terminada", "JoshybaDLL", 2, false);
                }
            }
        }

        public void SendToExcel(System.Data.DataTable dataTable, bool formatted, ref DataGridView datagrid)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

            Microsoft.Office.Interop.Excel.Application wapp = default(Microsoft.Office.Interop.Excel.Application);
            Worksheet wsheet = default(Worksheet);
            Workbook wbook = default(Workbook);
            wapp = new Microsoft.Office.Interop.Excel.Application();
            wapp.Visible = false;
            wbook = wapp.Workbooks.Add();
            wsheet = (Microsoft.Office.Interop.Excel.Worksheet)wbook.ActiveSheet;
            wsheet.Range["a1:cu5000"].NumberFormat = "@";
            datagrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            datagrid.MultiSelect = true;
            datagrid.SelectAll();
            DataObject dataObj = datagrid.GetClipboardContent();
            Clipboard.SetDataObject(dataObj);
            wsheet.Range["A1"].PasteSpecial(Microsoft.Office.Interop.Excel.XlPasteType.xlPasteAll);
            wapp.Visible = true;
            if (formatted == true)
            {
                Microsoft.Office.Interop.Excel.Range last = wsheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                Microsoft.Office.Interop.Excel.Range range = wsheet.get_Range("A1", last);
                range.AutoFormat(Format: Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatSimple, Number: true, Font: true, Alignment: true, Border: true, Pattern: true, Width: true);
            }
            //wsheet.Range["A1"].EntireColumn.Delete();
            wapp.Visible = true;
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            Clipboard.Clear();
        }
    }
}

        //'Dim app As Microsoft.Office.Interop.Excel._Application = New Microsoft.Office.Interop.Excel.Application()
        //'Dim workbook As Microsoft.Office.Interop.Excel._Workbook = app.Workbooks.Add(Type.Missing)
        //'Dim worksheet As Microsoft.Office.Interop.Excel._Worksheet = Nothing
        //'worksheet = CType(workbook.Sheets("Hoja1"), Microsoft.Office.Interop.Excel._Worksheet)
        //'worksheet = CType(workbook.ActiveSheet, Microsoft.Office.Interop.Excel._Worksheet)

        //'worksheet.Cells(3, 15).AutoFilter(1, Type.Missing, Microsoft.Office.Interop.Excel.XlAutoFilterOperator.xlAnd, Type.Missing, True)
        //'worksheet.Columns(8, 9).AutoFilter(1, Type.Missing, Microsoft.Office.Interop.Excel.XlAutoFilterOperator.xlAnd, Type.Missing, True)
        //'worksheet.Cells(5, 15) = "A"
        //'worksheet.Cells(6, 15) = "A"
        //'worksheet.Cells(14, 15) = "A"
        //'worksheet.Cells(15, 15) = "B"
        //'worksheet.Cells(16, 15) = "A"
        //'worksheet.Cells(17, 15) = "C"
        //'worksheet.Cells(18, 15) = "D"
        //'worksheet.Cells(19, 15) = "C"
        //'worksheet.Cells(20, 15) = "B"
        //'worksheet.Range("f13:j13").Interior.Color = RGB(15, 36, 62)
        //'worksheet.Range("f14:j14").Interior.Color = RGB(221, 217, 196)
        //'worksheet.Range("f15:j15").Interior.Color = RGB(54, 96, 146)
        //'worksheet.Range("f16:j16").Interior.Color = RGB(218, 238, 243)
        //'worksheet.Range("f17:j17").Interior.Color = RGB(148, 138, 84)
        //'worksheet.Shapes.AddPicture(Application.StartupPath & "\imagenes\logo.jpg", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 100, 0, 654, 157)
        //'workbook.Worksheets(CObj("Hoja1")).Name = CObj("Prueba_1")
        //'workbook.Protect(txt_pass.Text, True, False)
        //'worksheet.Protect(txt_pass.Text, True, True, True, False, False, False, False, False, False, False, False, False, False, True, False)
        //'worksheet.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection
        //'app.Visible = True
        //'app = Nothing
        //'workbook = Nothing
        //'worksheet = Nothing
        //'FileClose(1)
        //'GC.Collect()
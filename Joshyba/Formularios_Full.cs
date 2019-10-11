using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Joshyba
{
    public class Formularios_Full
    {
        //public static Formularios_Full FFull;
        private ProgressBar progreso;
        private Form Cargando;
        private System.Windows.Forms.Label Info;
        public int cantidad = 0;
        public Formularios_Full()
        {
            //Formularios_Full.FFull = this;
        }
        public enum TipoTextBox
        {
            PuroTexto,
            PuroNumero
        };

        //muestra el formulario de tiempo de avance
        public void formulario(string titulo, string infoprogreso,int _Value)
        {
            try
            {
                Cargando = new Form();
                progreso = new ProgressBar();
                Info = new System.Windows.Forms.Label();
                progreso.Location = new System.Drawing.Point(24, 12);
                progreso.Name = "progreso";
                progreso.Size = new System.Drawing.Size(361, 54);
                progreso.Value = _Value;

                Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
                Info.Location = new System.Drawing.Point(26, 80);
                Info.Name = "Info";
                Info.Size = new System.Drawing.Size(358, 51);
                Info.Text = infoprogreso;
                Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;


                Cargando.Text = titulo;
                Cargando.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                Cargando.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                Cargando.ClientSize = new System.Drawing.Size(397, 135);
                Cargando.Controls.Add(progreso);
                Cargando.Controls.Add(Info);
                Cargando.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                Cargando.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                Cargando.ResumeLayout(false);
                Cargando.Show();
                progreso.Maximum = cantidad;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public void formulario(string titulo, string infoprogreso)
        {
            Cargando = new Form();
            progreso = new ProgressBar();
            Info = new System.Windows.Forms.Label();
            progreso.Location = new System.Drawing.Point(24, 12);
            progreso.Name = "progreso";
            progreso.Size = new System.Drawing.Size(361, 54);

            Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Info.Location = new System.Drawing.Point(26, 80);
            Info.Name = "Info";
            Info.Size = new System.Drawing.Size(358, 51);
            Info.Text = infoprogreso;
            Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;


            Cargando.Text = titulo;
            Cargando.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Cargando.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Cargando.ClientSize = new System.Drawing.Size(397, 135);
            Cargando.Controls.Add(progreso);
            Cargando.Controls.Add(Info);
            Cargando.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Cargando.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Cargando.ResumeLayout(false);
            Cargando.Show();
            progreso.Maximum = cantidad;
        }
        public void incrementar(int incremento, string infoprogreso)
        {
            if (progreso.Value == cantidad)
            {
                Cargando.Close();
                MessageBox.Show("Carga terminada");
            }
            progreso.Value = incremento;
            Info.Text = infoprogreso;
        }
        public void cerrar()
        {
            Cargando.Close();
        }

        public static DialogResult InputBox(string title, string promptText, ref String value, TipoTextBox tipo= TipoTextBox.PuroTexto)
        {
            DialogResult dialogResult;
            Form form = new Form();
            Label label = new Label();
 

            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            //textBox.Text = value;


            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            //textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            //textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 170);
            //form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            //form.FormBorderStyle = FormBorderStyle.Sizable;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            //form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            

            if (tipo == TipoTextBox.PuroTexto)
            {
                TextBox textBox = new TextBox();
                textBox.Text = value;
                textBox.SetBounds(12, 36, 372, 20);
                textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
                textBox.Multiline = true;
                textBox.MaxLength = 1000;
                textBox.Height = 100;
                textBox.ScrollBars = ScrollBars.Both;
                textBox.Focus();


                buttonOk.SetBounds(228, 135, 75, 23);
                buttonOk.Refresh();
                buttonCancel.SetBounds(309, 135, 75, 23);
                buttonCancel.Refresh();


                form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                dialogResult = form.ShowDialog();
                value = textBox.Text;
            }
            else
            {
                Controles.TextBoxNumeric textBox = new Controles.TextBoxNumeric();
                textBox.Text = value;
                textBox.SetBounds(12, 36, 372, 20);
                textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
                form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                dialogResult = form.ShowDialog();
                value = textBox.Text;
            }

      
            
            return dialogResult;
        }
        public static DialogResult InputBox_Pass(string title, string promptText, ref String value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            textBox.PasswordChar = 'x';

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        public static string InputBox_Pass(string title, string promptText)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = "";

            textBox.PasswordChar = 'x'; 

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            return textBox.Text;
        }

        /*
         * 
         * [C#]

string value = "Document 1";
if (Tmp.InputBox("New document", "New document name:", ref value) == DialogResult.OK)
{
  myDocument.Name = value;
}
        otras formas de usarlo en vb
         * str1 = Microsoft.VisualBasic.Interaction.InputBox("Please enter your name","your Name","",100,100);

         * 
         * */
    }
}

using System;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace Joshyba.Controles
{
    [ToolboxBitmap(typeof(TextBox))]
    public partial class TextBoxFullBordes: UserControl
    {
        #region "Variables"
        Color colBorde = Color.SteelBlue;
        private IContainer Components= null;
        private int intBorderSize = 1;
        private int intLeftpad = 2;
        private int intToppad = 2;
        private PictureBox picBoth = new PictureBox();
        private PictureBox picLeft = new PictureBox();
        private PictureBox picRight = new PictureBox();
        private PictureBox picTop = new PictureBox();
        private TextBox txtTextbox = new TextBox();
        #endregion

        #region "Constructor"
        public TextBoxFullBordes()
        {
            //base;
            IniciaComponentes();
            colBorde = Color.DeepSkyBlue;
        }
        #endregion

        #region "Funciones"
        private void IniciaComponentes()
        {
            this.SuspendLayout();
            //'Establecemos los parametros del textbox del control
            //'Indicamos el tipo de borde
            this.txtTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //'El tipo de fuente y estilo
            this.txtTextbox.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Byte.Parse("0"));
            //'Establecemos una ubicacion
            this.txtTextbox.Location = new Point(8, 5);
            //'La longitud máxima
            this.txtTextbox.MaxLength = 0;
            //'El nombre
            this.txtTextbox.Name = "TextBox1";
            //'Un tamaño
            this.txtTextbox.Size = new Size(192, 23);
            //'Texto por default
            this.txtTextbox.Text = "TextBox";
            this.txtTextbox.Dock= DockStyle.Fill;
            //'Establecemos los parametros de la linea que dibuaremos del lado izquierdo

            //'Color de fondo
            this.picLeft.BackColor = colBorde; //' Color.DeepSkyBlue
            this.picLeft.Dock = DockStyle.Left;
            //'establecemos una ubicacion
            this.picLeft.Location = new Point(193, 1);
            //'el nombre
            this.picLeft.Name = "picLeft";
            //'un tamaño
            this.picLeft.Size = new Size(1, 22);
            this.picLeft.TabStop = false;
            
            //'Establecemos los parametros de la linea que dibuaremos del lado izquierdo
            //'Establecemos el color de fondo
            this.picRight.BackColor = colBorde; //'Color.DeepSkyBlue
            this.picRight.Dock = DockStyle.Right;
            //'una ubicacion
            this.picRight.Location = new Point(193, 1);
            //'el nombre
            this.picRight.Name = "picRight";
            //'un tamaño
            this.picRight.Size = new Size(1, 22);
            this.picRight.TabStop = false;            

            //'Establecemos los parametros de la linea que dibuaremos en la parte superior
            //'establecemos el color de fondo
            this.picTop.BackColor = colBorde; //'Color.DodgerBlue;
            this.picTop.Dock = DockStyle.Top;
            //'el nombre
            this.picTop.Name = "picTop";
            //'un tamaño
            this.picTop.Size = new Size(193, 1);
            this.picTop.TabStop = false;

            //'Establecemos los parametros de la linea que dibuaremos en la parte inferior
            //'establecemos el color de fondo
            this.picBoth.BackColor = colBorde; //'Color.DodgerBlue
            this.picBoth.Dock = DockStyle.Bottom;
            //'una ubicacion
            this.picBoth.Location = new Point(0, 23);
            //'un nombre
            this.picBoth.Name = "picBoth";
            //'un tamaño
            this.picBoth.Size = new Size(193, 1);
            this.picBoth.TabStop = false;

            //'establecemos el color de fondo
            this.BackColor = Color.White;
            this.Controls.AddRange(new Control[]{this.txtTextbox, this.picRight, this.picLeft, this.picBoth, this.picTop});
            //'el nombre del control
            this.Name = "TextBox";
            //'un tamaño
            this.Size = new Size(193, 24);
            this.ResumeLayout(false);
            }
        #endregion

        #region "Métodos"
        protected override void Dispose(Boolean disposing)
        {
            if(disposing)
            {
                if(!(Components == null)) Components.Dispose();
                base.Dispose(disposing);
            }
        }

        private void TextBox_Resize(Object sender,EventArgs e)
        {
            picTop.Width = this.Width;
            picLeft.Height = this.Height;
            picRight.Height = this.Height;
            if(txtTextbox.Multiline)
            {
                picBoth.Width = this.Width;
            }
            txtTextbox.Location = new Point(intLeftpad, intToppad);
            txtTextbox.Width = this.Width - (intBorderSize * 2) - intLeftpad;
            txtTextbox.Height = this.Height - (intBorderSize * 2) - intToppad;
        }
        private void txtTextbox_KeyDown(Object sender,KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        private void txtTextbox_KeyPress(Object sender,KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }
        private void txtTextbox_KeyUp(Object sender,KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter) MessageBox.Show("Chingon");
            base.OnKeyUp(e);
        }
        #endregion

        #region "Propiedades"
        [Category("CustomProperties"), Description("Establece el color de fondo del control")]
        public Color BackGroudColor
        {
            get
            {
                return this.BackColor;
            }
            set
            {
                this.BackColor = value;
                txtTextbox.BackColor = value;
            }
        }

        [Category("CustomProperties"), Description("Establece el color de borde del control")]
        public Color BorderColor
        {
            get
            {
                return colBorde;
            }
            set
            {
                colBorde = value;
                picBoth.BackColor = value;
                picLeft.BackColor = value;
                picRight.BackColor = value;
                picTop.BackColor = value;
            }
        }


        [Category("CustomProperties"), Description("Establece el tamaño del borde del control")]
        public int BorderSize
        {
            get
            {
                return intBorderSize;
            }
            set
            {
                intBorderSize = value;
                this.Refresh();
            }
        }

        //'JE Propiedad bastante logica no XD
        public  override Font Font
        {
            get
            {
                return txtTextbox.Font;
            }
            set
            {
                txtTextbox.Font = value;
                this.Refresh();
            }
        }

        [Category("CustomProperties"), Description("Establece el color de la fuente del control")]
        public override Color ForeColor
        {
            get
            {
                return txtTextbox.ForeColor;
            }
            set
            {
                txtTextbox.ForeColor = value;
            }
        }


        [Category("CustomProperties"), Description("Indica si el control sera multilinea")]
        public Boolean Multiline
        {
            get
            {
                return txtTextbox.Multiline;
            }
            set
            {
                txtTextbox.Multiline = value;
                this.Refresh();
            }
        }


        public int PaddingLeft
        {
            get
            {
                return intLeftpad;
            }
            set
            {
                intLeftpad = value;
                this.Refresh();
            }
        }


        public int PaddingTop
        {
            get
            {
                return intToppad;
            }
            set
            {
                intToppad = value;
            }

        }


        [Category("CustomProperties"), Description("Establece el caracter a utilizar para encriptar un password")]
        public String PasswordChar
        {
            get
            {
                return txtTextbox.PasswordChar.ToString();
            }
            set
            {
                txtTextbox.PasswordChar = char.Parse(value);
                this.Refresh();
            }
        }


        [Category("CustomProperties"), Description("Indica si el control tendra scrolls y que tipo sera")]
        public ScrollBars ScrollBars
        {
            get
            {
                return txtTextbox.ScrollBars;
            }
            set
            {
                txtTextbox.ScrollBars = value;
            }
        }

        [Category("CustomProperties"), Description("Establece la alineacion del texto del control")]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return txtTextbox.TextAlign;
            }
            set
            {
                txtTextbox.TextAlign = value;
                this.Refresh();
            }
        }

        [Category("CustomProperties"), Description("Establece el texto que sera mostrado en el control")]
       public String Text2
        {
            get
            {
                return txtTextbox.Text;
            }
            set
            {
                txtTextbox.Text = value;
                this.Refresh();
            }
        }


        public Boolean WordWrap
        {
            get
            {
                return txtTextbox.WordWrap;
            }
            set
            {
                txtTextbox.WordWrap = value;
                this.Refresh();
            }
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TextBoxFullBordes
            // 
            this.Name = "TextBoxFullBordes";
            this.Size = new System.Drawing.Size(248, 106);
            this.ResumeLayout(false);

        }
    }
}

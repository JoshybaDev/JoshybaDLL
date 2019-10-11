using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Joshyba.Controles
{
    [ToolboxBitmap(typeof(TextBox))]
    //[ToolboxBitmap(@"D:\afelipelcDocs\images\NumericTextbox.bmp")]
    public partial class TextFull : TextBox
    {


        private static uint EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, String lParam);
        private string _marcaAguaText = "Ingrese un Dato...";
        private string vFormato_Numero;
        private bool vAplicar_Formato;
        private bool vSolo_Lectura;
        public double _Valor;




        //lo siguiente es la Propiedad que modificara y seteara el atributo
        ///<summary>
        /// Obtiene o setea el texto <see cref="TextBox"/> que mostrará el texto ayuda al usuario.
        /// </summary>
        [Description("El Texto que se mostrará como ayuda al usuario.")]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string MarcaAguaText
        {
            get { return _marcaAguaText; }
            set
            {
                if (value == null)
                {
                    value = String.Empty;
                }

                if (!_marcaAguaText.Equals(value, StringComparison.CurrentCulture))
                {
                    _marcaAguaText = value;
                    UpdateMensaje();
                    OnMarcaAguaTextChanged(EventArgs.Empty);
                }
            }
        }
        //Definimos el evento que se disparará cuando la propiedad Text cambie y su Handler
        /// <summary>
        /// Ocurre cuando el valor de la propiedad de <see cref="MarcaAguaText"/>  cambie.
        /// </summary>
        public event EventHandler MarcaAguaTextChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnMarcaAguaTextChanged(EventArgs e)
        {
            EventHandler handler = MarcaAguaTextChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //Creamos la propiedad que permitirá en tiempo de diseño establecer, si queremos que la marca de agua se mantenga o no visible aun cuando el control tenga el enfoque
        private bool _mostrarMarcaAguaConEnfoque = false;

        /// <summary>
        ///Obtiene o setea un valor que indica si el <see cref="TextBox"/> mostrará la marca de agua, aun cuando el control tenga el enfoque
        /// </summary>
        [Description("Indica si el Control mostrará la marca de agua, aun cuando el control tenga el enfoque.")]
        [Category("Appearance")]
        [DefaultValue(false)]
        [Localizable(true)]
        public bool MostrarMarcaAguaConEnfoque
        {
            get { return _mostrarMarcaAguaConEnfoque; }
            set
            {
                if (_mostrarMarcaAguaConEnfoque != value)
                {
                    _mostrarMarcaAguaConEnfoque = value;
                    UpdateMensaje();
                    OnMostrarMarcaAguaConEnfoqueChanged(EventArgs.Empty);
                }
            }
        }
        //Generamos el evento que se disparará cuando se realice un cambio en la propiedad junto con su manejador
        /// <summary>
        /// Ocurre cuando la propiedad <see cref="MostrarMarcaAguaConEnfoque"/> cambia de valor.
        /// </summary>
        public event EventHandler MostrarMarcaAguaConEnfoqueChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnMostrarMarcaAguaConEnfoqueChanged(EventArgs e)
        {
            EventHandler handler = MostrarMarcaAguaConEnfoqueChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        //sobreescribimos el Manejador OnHandleCreated:
        protected override void OnHandleCreated(EventArgs e)
        {
            UpdateMensaje();

            base.OnHandleCreated(e);
        }

        //y por ultimo creamos la función que envia el mensaje de actualización del mensaje al control:
        private void UpdateMensaje()
        {
            // Si el manejador no se ha creado
            // este sera llamado cuando sea creado
            if (this.IsHandleCreated)
            {
                SendMessage(new HandleRef(this, this.Handle), EM_SETCUEBANNER, (_mostrarMarcaAguaConEnfoque) ? new IntPtr(1) : IntPtr.Zero, _marcaAguaText);
            }
        }

        public string _Formato_Numero
        {
            get
            {
                return this.vFormato_Numero;
            }
            set
            {
                this.vFormato_Numero = value.Trim();
                if (String.Compare(this.vFormato_Numero, "", false) != 0)
                {
                    this.vAplicar_Formato = true;
                }
                else
                {
                    this.vAplicar_Formato = false;
                }
            }
        }


        public bool _Solo_Lectura
        {
            get
            {
                return this.vSolo_Lectura;
            }
            set
            {
                this.vSolo_Lectura = value;
                if (value)
                {
                    this.ReadOnly = true;
                    this.TabStop = false;
                    //this.BackColor = this.vFondo_Inactivo;
                    //this.ForeColor = this.vFuente_Inactiva;
                }
                else
                {
                    this.ReadOnly = false;
                    this.TabStop = true;
                    //this.BackColor = this.vFondo_Activo;
                    //this.ForeColor = this.vFuente_Activa;
                }
            }
        }

        public TextFull()
        {
            //base.GotFocus += new EventHandler(this.TextBox_GotFocus);
            //base.KeyPress += new KeyPressEventHandler(this.TextBox_KeyPress);
            //base.LostFocus += new EventHandler(this.TextBox_LostFocus);
            //base.TextChanged += new EventHandler(this.TextBox_TextChanged);
            this.vFormato_Numero = "";
            InitializeComponent();
        }

        protected override void OnKeyPress( KeyPressEventArgs e)
        {
            if (this.vAplicar_Formato)
            {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (String.Compare(Convert.ToString(e.KeyChar), ".", false) == 0 &  Cadenas.Instr(0,this.Text,".",1) == 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }



        protected override void OnLostFocus( EventArgs e)
        {
            try
            {
                if (!this.vSolo_Lectura)
                {
                    //this.BackColor = this.vFondo_Activo;
                    //this.ForeColor = this.vFuente_Activa;
                    if (this.vAplicar_Formato)
                    {
                        this.vAplicar_Formato = false;
                        this.Text = String.Format(this.vFormato_Numero, this._Valor);
                        this.vAplicar_Formato = true;
                    }
                }
                base.OnLostFocus(e);
            }
            catch (Exception ex)
            {
                ///MessageBox.Show(ex.Message + this._Valor);
                if (String.Compare(this.vFormato_Numero, "", false) != 0)
                {
                    this.vAplicar_Formato = true;
                }
                else
                {
                    this.vAplicar_Formato = false;
                }
                this._Valor = 0.0;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            try
            {
                if (this.vAplicar_Formato & String.Compare(this.Text.Trim(), "", false) != 0 & !this.Focused)
                {
                    this.vAplicar_Formato = false;
                    this._Valor = Convert.ToDouble(this.Text);
                    this.Text = String.Format(this.vFormato_Numero, this._Valor);
                    this.vAplicar_Formato = true;
                }
                else if (String.Compare(this.vFormato_Numero, "", false) != 0)
                {
                    this._Valor = Convert.ToDouble(this.Text);
                }
                else
                {
                    this._Valor = 0.0;
                }
                base.OnTextChanged(e);
            }
            catch (Exception ex)
            {
                if (String.Compare(this.vFormato_Numero, "", false) != 0)
                {
                    this.vAplicar_Formato = true;
                }
                else
                {
                    this.vAplicar_Formato = false;
                }
                this._Valor = 0.0;
            }
        }
    }
}

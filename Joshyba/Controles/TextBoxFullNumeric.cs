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
    public partial class TextBoxNumeric : TextBox
    {
        public TextBoxNumeric()
        {
            this.vFormato_Numero = "";
            base.TextAlign = HorizontalAlignment.Right;
            InitializeComponent();
        }

        public virtual void AplicandoFormato()
        {
            if (this.vAplicar_Formato)
            {
                this.vAplicar_Formato = false;
                this.Text = String.Format(this.vFormato_Numero, double.Parse(this.Text));
                this.vAplicar_Formato = true;
            }
        }


        private static uint EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, String lParam);
        private string _marcaAguaText = "Ingrese un Dato...";
        private string vFormato_Numero;
        private bool vAplicar_Formato;


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //solo permitir numeros y teclas de control
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar=='.' || e.KeyChar=='0')
            {

                if (this.Text.IndexOf('.') > 0 && e.KeyChar == '.')
                {
                    e.Handled = true; //rechazar el caracter
                }
                else
                {
                    e.Handled = false; //permitir el caracter
                }
            }
            else
            {
                e.Handled = true; //rechazar el caracter
            }
        }





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


 
        protected override void OnLostFocus(EventArgs e)
        {
            try
            {
                if (!this.ReadOnly)
                {
                    AplicandoFormato();
                    base.OnLostFocus(e);
                }
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
            }
        }

        //protected override void OnTextChanged(EventArgs e)
        //{
        //    try
        //    {
        //        if (this.vAplicar_Formato & String.Compare(this.Text.Trim(), "", false) != 0 & !this.Focused)
        //        {
        //            this.vAplicar_Formato = false;
        //            this.Text = String.Format(this.vFormato_Numero, double.Parse(this.Text));
        //            this.vAplicar_Formato = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (String.Compare(this.vFormato_Numero, "", false) != 0)
        //        {
        //            this.vAplicar_Formato = true;
        //        }
        //        else
        //        {
        //            this.vAplicar_Formato = false;
        //        }
        //    }
        //}
    }
}

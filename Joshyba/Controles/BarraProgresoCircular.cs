using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Joshyba.Controles
{
    [ToolboxBitmap(typeof(ProgressBar))]
    public partial class BarraProgresoCircular : UserControl
    {
        int vValorProgreso;
        int vAncho = 0;
        int vAlto = 0;
        Color Progreso=Color.DarkRed;
        Color FondoProgreso = Color.LightCoral;
        Color FondoCentral = Color.Linen;
        Color Texto = Color.DarkRed;

        public BarraProgresoCircular()
        {
            InitializeComponent();
            vValorProgreso = 10;
            vAncho = this.Width;
            vAlto = this.Height;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Opaque, false);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            try
            {
                //verificamos cual es el punto mas pequeño
                if (vAlto < vAncho)
                {
                    this.vAncho = vAlto;
                }
                else
                {
                    this.vAlto = vAncho;
                }
                e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);


                //fondo del circulo===============================================================
                e.Graphics.RotateTransform(-90);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen obj_penx = new Pen(FondoProgreso);
                Rectangle rectx = new Rectangle(0 - this.vAlto / 2 + 12, 0 - this.vAncho / 2 + 12, this.vAlto - 28, this.vAncho - 28);
                //e.Graphics.DrawPie(obj_penx, rectx, 0, 360);
                e.Graphics.FillPie(new SolidBrush(FondoProgreso), rectx, 0, 360);



                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen obj_pen = new Pen(Progreso);
                Rectangle rect1 = new Rectangle(0 - this.vAlto / 2 + 12, 0 - this.vAncho / 2 + 12, this.vAlto - 28, this.vAncho - 28);
                e.Graphics.DrawPie(obj_pen, rect1, 0, (int)(this.vValorProgreso * 3.6));
                e.Graphics.FillPie(new SolidBrush(Progreso), rect1, 0, (int)(this.vValorProgreso * 3.6));


                //el que tapa el circulo============================================
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen obj_pen2 = new Pen(FondoCentral);
                Rectangle rect2 = new Rectangle(0 - this.vAlto / 2 + 32, 0 - this.vAncho / 2 + 32, this.vAlto - 65, this.vAncho - 65);
                e.Graphics.DrawPie(obj_pen2, rect2, 0, 360);
                e.Graphics.FillPie(new SolidBrush(FondoCentral), rect2, 0, 360);

                e.Graphics.RotateTransform(90);
                StringFormat ft = new StringFormat();
                ft.LineAlignment = StringAlignment.Center;
                ft.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(vValorProgreso.ToString() + " %", new Font("Arial", (int)(this.vAncho * 0.135)), new SolidBrush(Texto), rect1, ft);
            }
            catch (Exception)
            {


            }

           
        }

        #region "Propiedades"
        [Category("CustomProperties"), Description("Valor de la barra de progreso")]
        public int Value
        {
            get
            {
                return this.vValorProgreso;
            }
            set
            {
                Application.DoEvents();
                this.vValorProgreso = value;
                this.Refresh();
            }
        }
        [Category("CustomProperties"), Description("Color del progreso")]
        public Color ColorProgreso
        {
            get
            {
                return this.Progreso;
            }
            set
            {
                this.Progreso = value;
            }
        }
        [Category("CustomProperties"), Description("Color del fondo del progreso")]
        public Color ColorFondoProgreso
        {
            get
            {
                return this.FondoProgreso;
            }
            set
            {
                this.FondoProgreso = value;
            }
        }

        [Category("CustomProperties"), Description("Color del fondo del centro del progreso")]
        public Color ColorFondoCentral
        {
            get
            {
                return this.FondoCentral;
            }
            set
            {
                this.FondoCentral = value;
            }
        }

        [Category("CustomProperties"), Description("Color del texto")]
        public Color ColorTexto
        {
            get
            {
                return this.Texto;
            }
            set
            {
                this.Texto = value;
            }
        }

        #endregion

        protected override void OnResize( EventArgs e)
        {
            vAncho = this.Width;
            vAlto = this.Height;
            if(this.ActiveControl !=null)
            {
                this.Refresh();
            }
            base.OnResize(e);
        }

        //Aun no se usa
        private void UpdatePos()
        {
            if (base.IsHandleCreated)
            {
                base.Refresh();
            }
        }
    }
}

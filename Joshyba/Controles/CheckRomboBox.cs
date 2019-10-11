using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Joshyba
{
    [ToolboxBitmap(typeof(CheckBox))]
    class CheckRomboBox : Control
    {
        private int nCentro;
        private int nSuperior;
        private int nInferior;
        private bool mbMarcado;

        public CheckRomboBox()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Opaque, false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //' llamar a la versión de esté método de la clase base
            base.OnPaint(e);
            //calcular punto central del rombo
            nCentro = this.Height / 2;
            //' calcular punto superior del rombo
            nSuperior = nCentro - 9;
            //' calcular punto inferior del rombo
            nInferior = nCentro + 9;

            //' obtener un objeto para dibujar sobre el control
            Graphics oGraphics = e.Graphics;

            this.DibujarRomboExterior(oGraphics);
            this.DibujarRomboInterior(oGraphics);
            this.DibujarMarca(oGraphics);
            this.DibujarTexto(oGraphics);

            //' liberar los recursos gráficos
            oGraphics.Dispose();
        }
        private void DibujarRomboExterior(Graphics oGraphics)
        {
            //' calcular array de puntos para dibujar el rombo exterior
            Point[] aPuntos = new Point[5];
            aPuntos[0] = new Point(1, nCentro);
            aPuntos[1] = new Point(10, nSuperior);
            aPuntos[2] = new Point(19, nCentro);
            aPuntos[3] = new Point(10, nInferior);
            aPuntos[4] = new Point(1, nCentro);
            //' dibujar el rombo exterior
            oGraphics.DrawPolygon(new Pen(Color.Black, 1), aPuntos);
            //' liberar los recursos gráficos
            //=====>oGraphics.Dispose();
        }

        private void DibujarRomboInterior(Graphics oGraphics)
        {
            //===========================================
            //Dibujando el rombointerior
            Point[] aPuntos = new Point[5];
            aPuntos[0] = new Point(2, nCentro);
            aPuntos[1] = new Point(10, nSuperior + 1);
            aPuntos[2] = new Point(18, nCentro);
            aPuntos[3] = new Point(10, nInferior - 1);
            aPuntos[4] = new Point(2, nCentro);
            //' dibujar-rellenar el rombo interior
            oGraphics.FillPolygon(new SolidBrush(Color.White), aPuntos);
        }
        private void DibujarMarca(Graphics oGraphics)
        {
            if (mbMarcado == true)
            {
                //==============================================================
                //' línea vertical
                oGraphics.DrawLine(new Pen(Color.Black, 1), new Point(10, nSuperior + 3), new Point(10, nInferior - 3));
                //' línea horizontal
                oGraphics.DrawLine(new Pen(Color.Black, 1), new Point(4, nCentro), new Point(16, nCentro));
                //=============================================
                //' dibujar el título del control
                //===>oGraphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), 22, nCentro);
            }
        }
        private void DibujarMarca()
        {
            Graphics oGraphics = this.CreateGraphics();
            if (mbMarcado)
            {
                this.DibujarMarca(oGraphics);
            }
            else
            {
                DibujarRomboInterior(oGraphics);
            }
        }
        private void DibujarTexto(Graphics oGraphics)
        {
            //============================================================================
            //' crear un objeto para formato de cadenas
            //' y configurarlo para centrar la cadena a utilizar
            StringFormat oStrFormat = new StringFormat();
            oStrFormat.LineAlignment = StringAlignment.Center;
            oStrFormat.Alignment = StringAlignment.Center;
            //' instanciar un objeto RectangleF con la zona
            //' del control en la que vamos a dibujar el texto
            RectangleF oRectTexto;
            oRectTexto = new RectangleF(21, 0, this.Width - 21, this.Height);
            //' dibujar el título del control en el rectángulo
            //' que acabamos de crear y centrado
            oGraphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), oRectTexto, oStrFormat);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Invalidate the control to get a repaint.
            this.Invalidate();
        }
        public bool Marcado
        {
            get{
                return mbMarcado;
            }
            set
            {
                mbMarcado = value;
                this.DibujarMarca();
            }
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            mbMarcado = !mbMarcado;
            this.DibujarMarca();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if(e.KeyCode == Keys.Space)
            {
                mbMarcado = !mbMarcado;
                this.DibujarMarca();
            }
        }
    }
}

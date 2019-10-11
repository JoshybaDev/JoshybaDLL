using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Text;

namespace Joshyba
{
    [ToolboxBitmap(typeof(ProgressBar))]
    public class Barra_Progreso_1 : ProgressBar
    {
        public Barra_Progreso_1()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Opaque, false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            LinearGradientBrush brush = null;

            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);

            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            rec.Height -= 4;
            brush = new LinearGradientBrush(rec, this.ForeColor, this.BackColor, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);


            // Clean up.
            brush.Dispose();
        }
    }
}
//Modo de uso
//progressBar.ForeColor = Color.FromArgb(255, 0, 0);
//progressBar.BackColor = Color.FromArgb(150, 0, 0);


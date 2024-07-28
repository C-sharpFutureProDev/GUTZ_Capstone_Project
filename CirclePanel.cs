using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    internal class CirclePanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int diameter = Math.Min(this.Width, this.Height);
                int x = (this.Width - diameter) / 2;
                int y = (this.Height - diameter) / 2;
                path.AddEllipse(x, y, diameter, diameter);

                using (Brush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            this.Width = this.Height;
            base.OnResize(e);
        }
    }
}
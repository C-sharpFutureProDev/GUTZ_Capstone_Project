using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    internal class GradientPanel : Panel
    {
        private Color colorTop;
        private Color colorBottom;

        public Color ColorTop
        {
            get { return colorTop; }
            set
            {
                colorTop = value;
                Invalidate(); // Trigger a redraw of the panel
            }
        }

        public Color ColorBottom
        {
            get { return colorBottom; }
            set
            {
                colorBottom = value;
                Invalidate(); // Trigger a redraw of the panel
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(ClientRectangle, colorTop, colorBottom, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(linearGradientBrush, ClientRectangle);
            }
        }
    }
}

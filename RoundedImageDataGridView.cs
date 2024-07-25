using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    internal class RoundedImageDataGridView : DataGridView
    {
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && this.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                e.Handled = true;

                // Create a rounded rectangle path
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = e.CellBounds.Height / 2; // Circle radius
                    path.AddEllipse(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);

                    e.Graphics.SetClip(path); // Clip to the rounded path
                    e.Graphics.DrawImage((Image)e.Value, e.CellBounds); // Draw the image
                    e.Graphics.ResetClip(); // Reset the clipping

                    // Optionally draw a border
                    e.Graphics.DrawEllipse(Pens.Gray, e.CellBounds); // Border for the circular image
                }
            }
            else
            {
                base.OnCellPainting(e);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ellips_parametr_041
{
    class DrawAxes
    {
        int x_centre, y_centre;
        Graphics graph;
        Pen pen_Axes;
        PictureBox pictureBox1;

        public DrawAxes(PictureBox _picBox, Graphics _graph, Pen _pen_Axes, int _x_centre, int _y_centre)
        {
            pictureBox1 = _picBox;
            graph = _graph;
            pen_Axes = _pen_Axes;
            x_centre = _x_centre;
            y_centre = _y_centre;
        }

        public void DrawAxesLines()
        {
            graph.DrawLine(pen_Axes, new Point(x_centre, 0),
                new Point(x_centre, pictureBox1.Height));
            graph.DrawLine(pen_Axes, new Point(0, y_centre),
                new Point(pictureBox1.Width, y_centre));
        }
    }
}

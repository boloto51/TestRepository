using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Ellips_parametr_041
{
    class DrawEllips
    {
        int x_centre, y_centre, a, b;
        Graphics graph;
        Pen pen_Ellipse;
        double delta_t;

        public DrawEllips(int _x_centre, int _y_centre, Graphics _graph, 
            Pen _pen_Ellipse, double _delta_t, int _a, int _b)
        {
            x_centre = _x_centre;
            y_centre = _y_centre;
            graph = _graph;
            pen_Ellipse = _pen_Ellipse;
            delta_t = _delta_t;
            a = _a;
            b = _b;
        }

        public DrawEllips(int _x_centre, int _y_centre, Graphics _graph,
            Pen _pen_Ellipse, double _delta_t, int _a)
        {
            x_centre = _x_centre;
            y_centre = _y_centre;
            graph = _graph;
            pen_Ellipse = _pen_Ellipse;
            delta_t = _delta_t;
            a = _a;
        }

        public void DrawEllipsByPoints(int degree, int x, int y, int x2, int y2)
        {
            for (double t = 0; t <= 2 * Math.PI; t = t + delta_t)
            {
                double radians = (double)(degree * Math.PI / 180); // из градусов в радианы

                x = (int)(a * Math.Cos(radians) * Math.Cos(t) - b * Math.Sin(radians) * Math.Sin(t));
                y = (int)(a * Math.Sin(radians) * Math.Cos(t) + b * Math.Cos(radians) * Math.Sin(t));
                x2 = (int)(a * Math.Cos(radians) * Math.Cos(t + delta_t) - b * Math.Sin(radians) * Math.Sin(t + delta_t));
                y2 = (int)(a * Math.Sin(radians) * Math.Cos(t + delta_t) + b * Math.Cos(radians) * Math.Sin(t + delta_t));
                graph.DrawLine(pen_Ellipse, new Point(x_centre + x, y_centre - y),
                    new Point(x_centre + x2, y_centre - y2));
            }
        }

        public void DrawEllipsByPointsChangeDegree(NumericUpDown numericUpDown1, int x, int y, int x2, int y2)
        {
            for (double t = 0; t <= 2 * Math.PI; t = t + delta_t)
            {
                double radians = (double)((int)(numericUpDown1.Value) * Math.PI / 180); // из градусов в радианы

                x = (int)(a * Math.Cos(radians) * Math.Cos(t) - b * Math.Sin(radians) * Math.Sin(t));
                y = (int)(a * Math.Sin(radians) * Math.Cos(t) + b * Math.Cos(radians) * Math.Sin(t));
                x2 = (int)(a * Math.Cos(radians) * Math.Cos(t + delta_t) - b * Math.Sin(radians) * Math.Sin(t + delta_t));
                y2 = (int)(a * Math.Sin(radians) * Math.Cos(t + delta_t) + b * Math.Cos(radians) * Math.Sin(t + delta_t));
                graph.DrawLine(pen_Ellipse, new Point(x_centre + x, y_centre - y),
                    new Point(x_centre + x2, y_centre - y2));
            }
        }


        public void DrawEllipsByPointsBparam(int degree, int x, int y, int x2, int y2, int _b)
        {
            b = _b;

            for (double t = 0; t <= 2 * Math.PI; t = t + delta_t)
            {
                double radians = (double)(degree * Math.PI / 180); // из градусов в радианы

                x = (int)(a * Math.Cos(radians) * Math.Cos(t) - b * Math.Sin(radians) * Math.Sin(t));
                y = (int)(a * Math.Sin(radians) * Math.Cos(t) + b * Math.Cos(radians) * Math.Sin(t));
                x2 = (int)(a * Math.Cos(radians) * Math.Cos(t + delta_t) - b * Math.Sin(radians) * Math.Sin(t + delta_t));
                y2 = (int)(a * Math.Sin(radians) * Math.Cos(t + delta_t) + b * Math.Cos(radians) * Math.Sin(t + delta_t));
                graph.DrawLine(pen_Ellipse, new Point(x_centre + x, y_centre - y),
                    new Point(x_centre + x2, y_centre - y2));
            }
        }
    }
}

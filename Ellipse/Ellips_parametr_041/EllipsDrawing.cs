using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Ellips_parametr_041
{
    class EllipsDrawing
    {
        int xCentr, yCentr, a, b;
        Graphics graph;
        Pen pen_Ellipse;
        double delta_t;
        int x, y, x2, y2;

        public EllipsDrawing(PictureBox _picBox, Graphics _graph, Pen _pen_Ellipse, double _delta_t, int _b)
        {
            graph = _graph;
            pen_Ellipse = _pen_Ellipse;
            delta_t = _delta_t;
            a = (int)(_picBox.Width / 4); // большая ширина эллипса
            b = _b; // малая ширина эллипса
            xCentr = (int)(_picBox.Width / 2);
            yCentr = (int)(_picBox.Height / 2);
        }

        // рисование эллипса под заданным углом
        public void DrawEllipsByPoints(int degree)
        {
            for (double t = 0; t <= 2 * Math.PI; t = t + delta_t)
            {
                DrwElps(degree, t, delta_t, a, b);
                //CalcCoords(degree, t, delta_t, a, b, out x, out y, out x2, out y2);
                //graph.DrawLine(pen_Ellipse, new Point(xCentr + x, yCentr - y), new Point(xCentr + x2, yCentr - y2));
            }
        }

        // рисование эллипса под изменяющимся углом
        public void DrawEllipsByPoints1Degree(NumericUpDown numericUpDown1)
        {
            for (double t = 0; t <= 2 * Math.PI; t = t + delta_t)
            {
                DrwElps((int)numericUpDown1.Value, t, delta_t, a, b);
                //CalcCoords((int)numericUpDown1.Value, t, delta_t, a, b, out x, out y, out x2, out y2);
                //graph.DrawLine(pen_Ellipse, new Point(xCentr + x, yCentr - y), new Point(xCentr + x2, yCentr - y2));
            }
        }

        // рисование 10 сужающихся эллипсов
        public void DrawEllipsByPointsChangeWidth(int degree)
        {
            for (int i = 0; i <= 10; i++)
            {
                b = (int)(b * (10 - i) / 10);
                for (double t = 0; t <= 2 * Math.PI; t = t + delta_t)
                {
                    DrwElps(degree, t, delta_t, a, b);
                    //CalcCoords(degree, t, delta_t, a, b, out x, out y, out x2, out y2);
                    //graph.DrawLine(pen_Ellipse, new Point(xCentr + x, yCentr - y), new Point(xCentr + x2, yCentr - y2));
                }
                System.Threading.Thread.Sleep(300);
            }
        }

        public void DrawAnimate(NumericUpDown numericUpDown1, int b)
        {
            for (double t = 0; t <= 2 * Math.PI; t = t + delta_t)
            {
                DrwElps((int)numericUpDown1.Value, t, delta_t, a, b);
                //CalcCoords(degree, t, delta_t, a, b, out x, out y, out x2, out y2);
                //graph.DrawLine(pen_Ellipse, new Point(xCentr + x, yCentr - y), new Point(xCentr + x2, yCentr - y2));
            }
        }

        // рисование эллипса по точкам
        private void DrwElps(int degree, double t, double delta_t, int a, int b)
        {
            double radians = (double)(degree * Math.PI / 180); // из градусов в радианы
            x = (int)(a * Math.Cos(radians) * Math.Cos(t) - b * Math.Sin(radians) * Math.Sin(t));
            y = (int)(a * Math.Sin(radians) * Math.Cos(t) + b * Math.Cos(radians) * Math.Sin(t));
            x2 = (int)(a * Math.Cos(radians) * Math.Cos(t + delta_t) - b * Math.Sin(radians) * Math.Sin(t + delta_t));
            y2 = (int)(a * Math.Sin(radians) * Math.Cos(t + delta_t) + b * Math.Cos(radians) * Math.Sin(t + delta_t));
            graph.DrawLine(pen_Ellipse, new Point(xCentr + x, yCentr - y), new Point(xCentr + x2, yCentr - y2));
        }

        // вычисление координат для отрисовки эллипса по точкам
        /*
        private void CalcCoords(int degree, double t, double delta_t, int a, int b,
            out int x, out int y, out int x2, out int y2)
        {
            double radians = (double)(degree * Math.PI / 180); // из градусов в радианы
            x = (int)(a * Math.Cos(radians) * Math.Cos(t) - b * Math.Sin(radians) * Math.Sin(t));
            y = (int)(a * Math.Sin(radians) * Math.Cos(t) + b * Math.Cos(radians) * Math.Sin(t));
            x2 = (int)(a * Math.Cos(radians) * Math.Cos(t + delta_t) - b * Math.Sin(radians) * Math.Sin(t + delta_t));
            y2 = (int)(a * Math.Sin(radians) * Math.Cos(t + delta_t) + b * Math.Cos(radians) * Math.Sin(t + delta_t));
        }
        */
    }
}

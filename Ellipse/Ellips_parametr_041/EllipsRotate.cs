using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ellips_parametr_041
{
    class EllipsRotate
    {
        Graphics graph;
        DrawAxes axes;
        DrawEllips ellips9;
        PictureBox pictureBox1;
        int x_centre, y_centre, a, b;
        Pen pen_Ellipse;
        double delta_t;


        public EllipsRotate(PictureBox _picBox, Graphics _graph, DrawAxes _axes, 
            int _x_centre, int _y_centre, Pen _pen_Ellipse, double _delta_t, int _a, int _b)
        {
            graph = _graph;
            pictureBox1 = _picBox;
            axes = _axes;
            x_centre = _x_centre;
            y_centre = _y_centre;
            pen_Ellipse = _pen_Ellipse;
            delta_t = _delta_t;
            a = _a;
            b = _b;
        }

        public void Draw9Ellips(int x, int y, int x2, int y2)
        {
            graph.Clear(Color.Black); // очистка поля
            //textBox1.Text += "xMax=" + pictureBox1.Width + "\tyMax=" + pictureBox1.Height + "\r\n";
            axes.DrawAxesLines(); // отрисовка осей
            b = (int)(pictureBox1.Height / 4);
            int i = 5; // параметр для отрисовки numericUpDown1
            b = (int)(b * (10 - i) / 10); // малая ширина эллипса
            DrawEllips ellips9 = new DrawEllips(x_centre, y_centre, graph, pen_Ellipse, delta_t, a, b);

            // Отрисовка 9 эллипсов с поворотом вокруг центра эллипса на 10 градусов
            for (int degree = 0; degree <= 90; degree += 10)
            {
                ellips9.DrawEllipsByPoints(degree, x, y, x2, y2);
            }
        }

        public void DrawEllipsRotateOneDegree(NumericUpDown numericUpDown1, int x, int y, int x2, int y2)
        {
            graph.Clear(Color.Black);
            axes.DrawAxesLines(); // отрисовка осей
            int i = 5; // параметр для отрисовки numericUpDown1
            b = (int)(b * (10 - i) / 10); // малая ширина эллипса
            DrawEllips ellipsRotateAngle = new DrawEllips(x_centre, y_centre, graph, pen_Ellipse, delta_t, a, b);
            ellipsRotateAngle.DrawEllipsByPointsChangeDegree(numericUpDown1, x, y, x2, y2);

        }

    }
}

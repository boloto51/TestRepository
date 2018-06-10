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
        EllipsDrawing ellips9;
        PictureBox picBox;
        int xCentr, yCentr, a, b;
        Pen penEllips, pen_Axes;
        double delta_t;


        public EllipsRotate(PictureBox _picBox, Graphics _graph, DrawAxes _axes, Pen _pen_Ellipse, double _delta_t)
        {
            graph = _graph;
            picBox = _picBox;
            axes = _axes;
            penEllips = _pen_Ellipse;
            delta_t = _delta_t;
            a = (int)(picBox.Width / 4); // большая ширина эллипса
            xCentr = (int)(picBox.Width / 2);
            yCentr = (int)(picBox.Height / 2);
        }

        // Отрисовка 9 фиксированных эллипсов с поворотом каждого вокруг центра на 10 градусов
        public void Draw9Ellips()
        {
            Clr_DrwAxs();
            b = (int)(picBox.Height / 8); // малая ширина эллипса
            EllipsDrawing ellips9 = new EllipsDrawing(picBox, graph, penEllips, delta_t, b);

            for (int degree = 0; degree <= 90; degree += 10)
            {
                ellips9.DrawEllipsByPoints(degree);
            }
        }

        // Отрисовка 1 вращающегося эллипса с поворотом вокруг центра на 1 градус
        public void DrawEllipsRotate1Degree(NumericUpDown numericUpDown1)
        {
            Clr_DrwAxs();
            b = (int)(picBox.Height / 8); // малая ширина эллипса
            EllipsDrawing ellipsRotate1Degree = new EllipsDrawing(picBox, graph, penEllips, delta_t, b);
            ellipsRotate1Degree.DrawEllipsByPoints1Degree(numericUpDown1);
        }

        // Отрисовка 10 сужающихся эллипсов
        public void Draw10Ellips(int fixDegree)
        {
            Clr_DrwAxs();
            b = (int)(picBox.Height / 4); // малая ширина эллипса
            EllipsDrawing ellips10 = new EllipsDrawing(picBox, graph, penEllips, delta_t, b);
            ellips10.DrawEllipsByPointsChangeWidth(fixDegree);
        }

        public void DrawAnimate(NumericUpDown numericUpDown1, int b)
        {
            Clr_DrwAxs();
            EllipsDrawing ellipsAnimate = new EllipsDrawing(picBox, graph, penEllips, delta_t, b);
            ellipsAnimate.DrawAnimate(numericUpDown1, b);
        }

        public void Clr_DrwAxs()
        {
            graph.Clear(Color.Black);
            axes.DrawAxesLines(); // отрисовка осей
        }
    }
}

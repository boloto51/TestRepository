using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Ellips_parametr_042
{
    public partial class Form1 : Form
    {
        int a, b, xCentr, yCentr, i = 0;
        double delta_t = Math.PI / 50; // шаг отрисовки линий, составляющих эллипс
        bool trigger = true; // триггер определяющий сжимается эллипс на анимации или расширяется
        Pen pen_Ellipse, pen_Axes, pen_AxisRotate; // цвет эллипса и осей
        bool finish = false; // триггер выхода из анимации
        Graphics graph;

        public Form1()
        {
            InitializeComponent();
            graph = pictureBox1.CreateGraphics();
            xCentr = (int)(pictureBox1.Width / 2);
            yCentr = (int)(pictureBox1.Height / 2);
            pen_Ellipse = new Pen(Brushes.Lime, 1);
            pen_Axes = new Pen(Brushes.Blue, 1);
            pen_AxisRotate = new Pen(Brushes.Red, 1);
            a = (int)(pictureBox1.Width / 4); // большая ширина эллипса
            b = (int)(pictureBox1.Height / 4);
            numericUpDown1.Maximum = 360;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (finish != true) // пока триггер завершения не активен
            {
                picBoxClear();
                DrawAxes();
                DrawAxisRotate(numericUpDown1);
                b = (int)(pictureBox1.Height / 4 * Math.Abs(Math.Cos(i * Math.PI / 180)));
                DrawEllips(numericUpDown1, b);

                //textBox2.Text += "b=" + Convert.ToString(b) 
                //+ "\tcos=" + Convert.ToString(Math.Cos(i * Math.PI / 180)) + "\r\n";

                //if (finish == true)
                //{
                //    break;
                //}
                System.Threading.Thread.Sleep(100);

                i = trigger ? i += 10 : i -= 10;

                if (i == 90)
                {
                    trigger = false;
                }
                if (i == 0)
                {
                    trigger = true;
                }
            }
        }

        private void picBoxClear()
        {
            graph.Clear(Color.Black);
        }

        private void DrawAxes()
        {
            graph.DrawLine(pen_Axes, new Point(xCentr, 0), new Point(xCentr, pictureBox1.Height));
            graph.DrawLine(pen_Axes, new Point(0, yCentr), new Point(pictureBox1.Width, yCentr));
        }

        private void DrawAxisRotate(NumericUpDown numericUpDown1)
        {
            double radians = (double)((int)(numericUpDown1.Value) * Math.PI / 180); // из градусов в радианы
            int offsetX = (int)(a * Math.Cos(radians));
            int offsetY = (int)(a * Math.Sin(radians));
            graph.DrawLine(pen_AxisRotate, new Point(xCentr + offsetX, yCentr - offsetY), 
                new Point(xCentr - offsetX, yCentr + offsetY));
        }

        private void DrawEllips(NumericUpDown numericUpDown1, int b)
        {
            for (double t = 0; t < 2 * Math.PI; t = t + delta_t)
            {
                double radians = (double)((int)(numericUpDown1.Value) * Math.PI / 180); // из градусов в радианы
                int x = (int)(a * Math.Cos(radians) * Math.Cos(t) - b * Math.Sin(radians) * Math.Sin(t));
                int y = (int)(a * Math.Sin(radians) * Math.Cos(t) + b * Math.Cos(radians) * Math.Sin(t));
                int x2 = (int)(a * Math.Cos(radians) * Math.Cos(t + delta_t) - b * Math.Sin(radians) * Math.Sin(t + delta_t));
                int y2 = (int)(a * Math.Sin(radians) * Math.Cos(t + delta_t) + b * Math.Cos(radians) * Math.Sin(t + delta_t));
                graph.DrawLine(pen_Ellipse, new Point(xCentr + x, yCentr - y),
                    new Point(xCentr + x2, yCentr - y2));

                if (finish == true)
                {
                    break;
                }
            }
        }


    }
}

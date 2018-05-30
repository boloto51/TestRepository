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

//https://dxdy.ru/post483569.html

namespace Ellips_parametr_02
{
    public partial class Form1 : Form
    {
        int x, y, x2, y2, a, b, x_centre, y_centre, i;
        double delta_t = Math.PI / 50;
        bool trigger = true;
        Pen pen_Ellipse, pen_Axes;
        Thread myThread;
        bool finish = false;
        int degree;

        int[,] A = new int[50, 50];
        int[,] RotateMatrix = new int[50, 50];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 5;

            Graphics graph = pictureBox1.CreateGraphics();
            graph.Clear(Color.Black);

            x_centre = (int)(pictureBox1.Width / 2);
            y_centre = (int)(pictureBox1.Height / 2);
            pen_Ellipse = new Pen(Brushes.Lime, 1);
            pen_Axes = new Pen(Brushes.Blue, 1);

            //textBox1.Text += "xMax=" + pictureBox1.Width + "\tyMax=" + pictureBox1.Height + "\r\n";

            a = (int)(pictureBox1.Width / 4);
            b = (int)(pictureBox1.Height / 4);
            b = (int)(b * (10 - i) / 10);

            //textBox1.Text += "a=" + a + "\tb=" + b + "\r\n";
            //textBox1.Text += "\r\n";

            graph.DrawLine(pen_Axes, new Point(x_centre, 0),
                    new Point(x_centre, pictureBox1.Height));
            graph.DrawLine(pen_Axes, new Point(0, y_centre),
                    new Point(pictureBox1.Width, y_centre));

            for (int degree = 0; degree <= 90; degree += 10)
            {
                for (double t = 0; t <= 2 * Math.PI; t = t + delta_t)
                {
                    /*
                    x = (int)(a * Math.Cos(t));
                    y = (int)(b * Math.Sin(t));
                    x2 = (int)(a * Math.Cos(t + delta_t));
                    y2 = (int)(b * Math.Sin(t + delta_t));
                    graph.DrawLine(pen_Ellipse, new Point(x_centre + x, y_centre + y),
                        new Point(x_centre + x2, y_centre + y2));
                    //textBox1.Text += "x=" + (int)(x_centre + x) + "\ty=" + (int)(y_centre - y) + "\tx2=" + (int)(x_centre + x2) + "\ty2=" + (int)(y_centre - y2) + "\r\n";
                    */
                    double radians = (double)(degree * Math.PI / 180);

                    x = (int)(a * Math.Cos(radians) * Math.Cos(t) - b * Math.Sin(radians) * Math.Sin(t));
                    y = (int)(a * Math.Sin(radians) * Math.Cos(t) + b * Math.Cos(radians) * Math.Sin(t));
                    x2 = (int)(a * Math.Cos(radians) * Math.Cos(t + delta_t) - b * Math.Sin(radians) * Math.Sin(t + delta_t));
                    y2 = (int)(a * Math.Sin(radians) * Math.Cos(t + delta_t) + b * Math.Cos(radians) * Math.Sin(t + delta_t));
                    graph.DrawLine(pen_Ellipse, new Point(x_centre + x, y_centre - y),
                        new Point(x_centre + x2, y_centre - y2));
                    //textBox1.Text += "x=" + (int)(x_centre + x) + "\ty=" + (int)(y_centre - y) + "\tx2=" + (int)(x_centre + x2) + "\ty2=" + (int)(y_centre - y2) + "\r\n";
                }
            }
        }
    }
}

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

namespace Ellips_parametr_041
{
    public partial class Form1 : Form
    {
        int x, y, x2, y2, a, b, x_centre, y_centre, i;
        double delta_t = Math.PI / 50; // шаг отрисовки линий, составляющих эллипс
        bool trigger = true; // триггер определяющий сжимается эллипс на анимации или расширяется
        Pen pen_Ellipse, pen_Axes; // цвет эллипса и осей
        Thread myThread;
        bool finish = false; // триггер выхода из анимации
        int degree; // переменная для градусов наклона эллипса
        Graphics graph;
        DrawAxes axes;

        public Form1()
        {
            InitializeComponent();
            graph = pictureBox1.CreateGraphics();
            x_centre = (int)(pictureBox1.Width / 2);
            y_centre = (int)(pictureBox1.Height / 2);
            pen_Ellipse = new Pen(Brushes.Lime, 1);
            pen_Axes = new Pen(Brushes.Blue, 1);
            a = (int)(pictureBox1.Width / 4); // большая ширина эллипса
            b = (int)(pictureBox1.Height / 4);
            //i = 5; // параметр для отрисовки numericUpDown1
            //b = (int)(b * (10 - i) / 10); // малая ширина эллипса
            axes = new DrawAxes(pictureBox1, graph, pen_Axes, x_centre, y_centre);
            numericUpDown1.Maximum = 360;
        }

        // Отрисовка 9 эллипсов с поворотом вокруг центра эллипса на 10 градусов
        private void button1_Click(object sender, EventArgs e)
        {
            EllipsRotate ellips9 = new EllipsRotate(pictureBox1, graph, axes, pen_Ellipse, delta_t);
            ellips9.Draw9Ellips();
        }

        // Поворот эллипса вокруг центра при изменении значения в numericUpDown1
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            EllipsRotate ellips1rot = new EllipsRotate(pictureBox1, graph, axes, pen_Ellipse, delta_t);
            ellips1rot.DrawEllipsRotate1Degree(numericUpDown1);
        }

        // отрисовка 10 эллипсов разной ширины повернутых на заданный угол
        private void button2_Click(object sender, EventArgs e)
        {
            EllipsRotate ellips10 = new EllipsRotate(pictureBox1, graph, axes, pen_Ellipse, delta_t);
            ellips10.Draw10Ellips((int)numericUpDown1.Value);
        }

        // анимация одного эллипса в потоке
        private void button3_Click(object sender, EventArgs e)
        {
            if (myThread == null)
            {
                myThread = new Thread(new ThreadStart(DrawEllipse));
                myThread.IsBackground = true;
                myThread.Start();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            finish = true;
            if (myThread != null) // && myThread.ThreadState == ThreadState.Running
            {
                myThread.Join();
            }
        }

        // анимация одного эллипса
        private void DrawEllipse()
        {
            //EllipsRotate ellipsAnima = new EllipsRotate(pictureBox1, graph, axes, pen_Ellipse, delta_t);
            //b = (int)(pictureBox1.Height / 4);
            //EllipsDrawing ellipsDrw = new EllipsDrawing(pictureBox1, graph, pen_Ellipse, delta_t, b);

            while (finish != true) // пока триггер завершения не активен
            {
                if (trigger == true)
                {
                    // отрисовка 10 раз уменьшающегося эллипса
                    for (i = 0; i <= 10; i++)
                    {
                        //ellipsAnima.Clr_DrwAxs();
                        
                        graph.Clear(Color.Black);
                        graph.DrawLine(pen_Axes, new Point(x_centre, 0),
                            new Point(x_centre, pictureBox1.Height));
                        graph.DrawLine(pen_Axes, new Point(0, y_centre),
                            new Point(pictureBox1.Width, y_centre));
                        
                        a = (int)(pictureBox1.Width / 4);
                        b = (int)(pictureBox1.Height / 4);
                        b = (int)(b * (10 - i) / 10);

                        //ellipsDrw.DrawEllipsByPoints1Degree(numericUpDown1);
                        
                        for (double t = 0; t < 2 * Math.PI; t = t + delta_t)
                        {
                            double radians = (double)((int)(numericUpDown1.Value) * Math.PI / 180); // из градусов в радианы

                            x = (int)(a * Math.Cos(radians) * Math.Cos(t) - b * Math.Sin(radians) * Math.Sin(t));
                            y = (int)(a * Math.Sin(radians) * Math.Cos(t) + b * Math.Cos(radians) * Math.Sin(t));
                            x2 = (int)(a * Math.Cos(radians) * Math.Cos(t + delta_t) - b * Math.Sin(radians) * Math.Sin(t + delta_t));
                            y2 = (int)(a * Math.Sin(radians) * Math.Cos(t + delta_t) + b * Math.Cos(radians) * Math.Sin(t + delta_t));
                            graph.DrawLine(pen_Ellipse, new Point(x_centre + x, y_centre - y),
                                new Point(x_centre + x2, y_centre - y2));

                            if (finish == true)
                            {
                                break;
                            }
                        }
                        
                        if (finish == true)
                        {
                            break;
                        }
                        System.Threading.Thread.Sleep(100);
                    }
                    if (finish == true)
                    {
                        break;
                    }
                    trigger = false;
                }
                if (trigger == false)
                {
                    // отрисовка 10 раз увеличивающегося эллипса
                    for (i = 10; i >= 0; i--)
                    {
                        graph.Clear(Color.Black);
                        graph.DrawLine(pen_Axes, new Point(x_centre, 0),
                            new Point(x_centre, pictureBox1.Height));
                        graph.DrawLine(pen_Axes, new Point(0, y_centre),
                            new Point(pictureBox1.Width, y_centre));

                        a = (int)(pictureBox1.Width / 4);
                        b = (int)(pictureBox1.Height / 4);
                        b = (int)(b * (10 - i) / 10);
                        for (double t = 0; t < 2 * Math.PI; t = t + delta_t)
                        {
                            double radians = (double)((int)(numericUpDown1.Value) * Math.PI / 180); // из градусов в радианы

                            x = (int)(a * Math.Cos(radians) * Math.Cos(t) - b * Math.Sin(radians) * Math.Sin(t));
                            y = (int)(a * Math.Sin(radians) * Math.Cos(t) + b * Math.Cos(radians) * Math.Sin(t));
                            x2 = (int)(a * Math.Cos(radians) * Math.Cos(t + delta_t) - b * Math.Sin(radians) * Math.Sin(t + delta_t));
                            y2 = (int)(a * Math.Sin(radians) * Math.Cos(t + delta_t) + b * Math.Cos(radians) * Math.Sin(t + delta_t));
                            graph.DrawLine(pen_Ellipse, new Point(x_centre + x, y_centre - y),
                                new Point(x_centre + x2, y_centre - y2));

                            if (finish == true)
                            {
                                break;
                            }
                        }
                        if (finish == true)
                        {
                            break;
                        }
                        System.Threading.Thread.Sleep(100);
                    }
                    if (finish == true)
                    {
                        break;
                    }
                    trigger = true;
                }
            }
        }
    }
}

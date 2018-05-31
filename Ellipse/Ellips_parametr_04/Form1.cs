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

namespace Ellips_parametr_04
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
        //int[,] A = new int[50, 50];
        //int[,] RotateMatrix = new int[50, 50];

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
        }

        // Отрисовка 9 эллипсов с поворотом вокруг центра эллипса на 10 градусов
        private void button1_Click(object sender, EventArgs e)
        {
            graph.Clear(Color.Black); // очистка поля
            //textBox1.Text += "xMax=" + pictureBox1.Width + "\tyMax=" + pictureBox1.Height + "\r\n";
            graph.DrawLine(pen_Axes, new Point(x_centre, 0),
                    new Point(x_centre, pictureBox1.Height)); // отрисовка вертикальной оси
            graph.DrawLine(pen_Axes, new Point(0, y_centre),
                    new Point(pictureBox1.Width, y_centre)); // отрисовка горизонтальной оси

            // Отрисовка 9 эллипсов с поворотом вокруг центра эллипса на 10 градусов
            for (int degree = 0; degree <= 90; degree += 10)
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
        }

        // поворот статического эллипса вокруг центра при изменении значения в numericUpDown1
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            graph.Clear(Color.Black);

            graph.DrawLine(pen_Axes, new Point(x_centre, 0),
                new Point(x_centre, pictureBox1.Height));
            graph.DrawLine(pen_Axes, new Point(0, y_centre),
                    new Point(pictureBox1.Width, y_centre));
            i = 5; // параметр для отрисовки numericUpDown1
            b = (int)(b * (10 - i) / 10); // малая ширина эллипса

            for (double t = 0; t <= 2 * Math.PI; t = t + delta_t)
            {
                double radians = (double)((int)(numericUpDown1.Value) * Math.PI / 180); // из градусов в радианы

                x = (int)(a * Math.Cos(radians) * Math.Cos(t) - b * Math.Sin(radians) * Math.Sin(t));
                y = (int)(a * Math.Sin(radians) * Math.Cos(t) + b * Math.Cos(radians) * Math.Sin(t));
                x2 = (int)(a * Math.Cos(radians) * Math.Cos(t + delta_t) - b * Math.Sin(radians) * Math.Sin(t + delta_t));
                y2 = (int)(a * Math.Sin(radians) * Math.Cos(t + delta_t) + b * Math.Cos(radians) * Math.Sin(t + delta_t));
                graph.DrawLine(pen_Ellipse, new Point(x_centre + x, y_centre - y),
                    new Point(x_centre + x2, y_centre - y2));
                //textBox1.Text += "x=" + (int)(x_centre + x) + "\ty=" + (int)(y_centre - y) + "\tx2=" + (int)(x_centre + x2) + "\ty2=" + (int)(y_centre - y2) + "\r\n";
            }
        }

        // отрисовка 10 эллипсов разной ширины повернутых на заданный угол
        private void button2_Click(object sender, EventArgs e)
        {
            graph.Clear(Color.Black);

            // отрисовка осей
            graph.DrawLine(pen_Axes, new Point(x_centre, 0),
                    new Point(x_centre, pictureBox1.Height));
            graph.DrawLine(pen_Axes, new Point(0, y_centre),
                    new Point(pictureBox1.Width, y_centre));

            a = (int)(pictureBox1.Width / 4);
            b = (int)(pictureBox1.Height / 4);

            degree = 60; // угол поворота в градусах

            // отрисовка 10 эллипсов разной ширины повернутых на заданный угол
            for (int j = 0; j <= 10; j++)
            {
                //graph.Clear(Color.Black);

                b = (int)(b * (10 - j) / 10);

                for (double t = 0; t <= 2 * Math.PI; t = t + delta_t)
                {
                    double radians = (double)(degree * Math.PI / 180);

                    x = (int)(a * Math.Cos(radians) * Math.Cos(t) - b * Math.Sin(radians) * Math.Sin(t));
                    y = (int)(a * Math.Sin(radians) * Math.Cos(t) + b * Math.Cos(radians) * Math.Sin(t));
                    x2 = (int)(a * Math.Cos(radians) * Math.Cos(t + delta_t) - b * Math.Sin(radians) * Math.Sin(t + delta_t));
                    y2 = (int)(a * Math.Sin(radians) * Math.Cos(t + delta_t) + b * Math.Cos(radians) * Math.Sin(t + delta_t));
                    graph.DrawLine(pen_Ellipse, new Point(x_centre + x, y_centre - y),
                        new Point(x_centre + x2, y_centre - y2));
                }
                System.Threading.Thread.Sleep(500);
            }
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
            while (finish != true) // пока триггер завершения не активен
            {
                if (trigger == true)
                {
                    // отрисовка 10 раз уменьшающегося эллипса
                    for (i = 0; i <= 10; i++)
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

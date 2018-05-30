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

namespace Ellips_parametr_01
{
    public partial class Form1 : Form
    {
        int x, y, x2, y2, a, b, x_centre, y_centre, i;
        double delta_t = Math.PI / 50;
        bool trigger = true;
        Pen pen_Ellipse;
        Thread myThread;
        bool finish = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
            textBox1.Text = "close";
            if (myThread != null) // && myThread.ThreadState == ThreadState.Running
            {
                textBox1.Text = "close2";
                myThread.Join();
            }
        }

        private void DrawEllipse()
        {
            Graphics graph = pictureBox1.CreateGraphics();
            graph.Clear(Color.Black);

            x_centre = (int)(pictureBox1.Width / 2);
            y_centre = (int)(pictureBox1.Height / 2);
            pen_Ellipse = new Pen(Brushes.Lime, 1);

            while (finish != true)
            {
                if (trigger == true)
                {
                    for (i = 0; i <= 10; i++)
                    {

                        graph.Clear(Color.Black);
                        a = (int)(pictureBox1.Width / 4);
                        b = (int)(pictureBox1.Height / 4);
                        b = (int)(b * (10 - i) / 10);
                        for (double t = 0; t < 2 * Math.PI; t = t + delta_t)
                        {
                            x = (int)(a * Math.Cos(t));
                            y = (int)(b * Math.Sin(t));
                            x2 = (int)(a * Math.Cos(t + delta_t));
                            y2 = (int)(b * Math.Sin(t + delta_t));
                            graph.DrawLine(pen_Ellipse, new Point(x_centre + x, y_centre + y),
                                new Point(x_centre + x2, y_centre + y2));
                            if (finish == true)
                            {
                                break;
                            }
                        }
                        if (finish == true)
                        {
                            break;
                        }
                        System.Threading.Thread.Sleep(1000);
                    }
                    if (finish == true)
                    {
                        break;
                    }
                    trigger = false;
                }
                if (trigger == false)
                {
                    for (i = 10; i >= 0; i--)
                    {
                        graph.Clear(Color.Black);
                        a = (int)(pictureBox1.Width / 4);
                        b = (int)(pictureBox1.Height / 4);
                        b = (int)(b * (10 - i) / 10);
                        for (double t = 0; t < 2 * Math.PI; t = t + delta_t)
                        {
                            x = (int)(a * Math.Cos(t));
                            y = (int)(b * Math.Sin(t));
                            x2 = (int)(a * Math.Cos(t + delta_t));
                            y2 = (int)(b * Math.Sin(t + delta_t));
                            graph.DrawLine(pen_Ellipse, new Point(x_centre + x, y_centre + y),
                                new Point(x_centre + x2, y_centre + y2));
                            if (finish == true)
                            {
                                break;
                            }
                        }
                        if (finish == true)
                        {
                            break;
                        }
                        System.Threading.Thread.Sleep(1000);
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

/*
namespace Ellips_parametr_01
{
    public partial class Form1 : Form
    {
        int x, y, x2, y2, a, b, x_centre, y_centre, i;

        double delta_t = Math.PI / 50;
        bool trigger = true;
        Pen pen_Ellipse;
        Thread myThread;
        bool finish = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (myThread == null)
            {
                myThread = new Thread(new ThreadStart(DrawEllipseExternal));
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

        private void DrawEllipseExternal()
        {
            Graphics graph = pictureBox1.CreateGraphics();
            graph.Clear(Color.Black);

            x_centre = (int)(pictureBox1.Width / 2);
            y_centre = (int)(pictureBox1.Height / 2);
            pen_Ellipse = new Pen(Brushes.Lime, 1);

            while (finish != true)
            {
                if (trigger == true)
                {
                    for (i = 0; i <= 10; i++)
                    {
                        DrawEllipseInternal(graph, x_centre, y_centre, pen_Ellipse, i);
                        if (finish == true)
                        {
                            break;
                        }
                    }
                    if (finish == true)
                    {
                        break;
                    }
                    trigger = false;
                }
                if (trigger == false)
                {
                    for (i = 10; i >= 0; i--)
                    {
                        DrawEllipseInternal(graph, x_centre, y_centre, pen_Ellipse, i);
                        if (finish == true)
                        {
                            break;
                        }
                    }
                    if (finish == true)
                    {
                        break;
                    }
                    trigger = true;
                }
            }
        }

        private void DrawEllipseInternal(Graphics graph, int x_centre, int y_centre, Pen pen_Ellipse, int i)
        {
            graph.Clear(Color.Black);
            a = (int)(pictureBox1.Width / 4);
            a = (int)(a * (10 - i) / 10);
            b = (int)(pictureBox1.Height / 4);
            b = (int)(b * (10 - i) / 10);
            for (double t = 0; t < 2 * Math.PI; t = t + delta_t)
            {
                x = (int)(a * Math.Cos(t));
                y = (int)(b * Math.Sin(t));
                x2 = (int)(a * Math.Cos(t + delta_t));
                y2 = (int)(b * Math.Sin(t + delta_t));
                graph.DrawLine(pen_Ellipse, new Point(x_centre + x, y_centre + y),
                    new Point(x_centre + x2, y_centre + y2));
                if (finish == true)
                {
                    break;
                }
            }
            System.Threading.Thread.Sleep(100);
        }
    }
} 
*/

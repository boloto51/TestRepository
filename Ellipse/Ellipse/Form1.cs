using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ellipse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graph = pictureBox1.CreateGraphics();
            graph.Clear(Color.Black);

            int x_centre = (int)(pictureBox1.Width / 2);
            int y_centre = (int)(pictureBox1.Height / 2);
            Point beginOfCoord = new Point(x_centre, y_centre);

            // Оси
            Pen pen_Axes = new Pen(Brushes.Blue, 1);
            graph.DrawLine(pen_Axes, beginOfCoord, new Point(pictureBox1.Width, y_centre));
            graph.DrawLine(pen_Axes, beginOfCoord, new Point(x_centre, 0));

            
            Pen pen = new Pen(Color.Lime, 2);
            graph.DrawEllipse(pen, (int)(pictureBox1.Width / 4), (int)(pictureBox1.Height / 4), (int)(pictureBox1.Width / 2), (int)(pictureBox1.Height / 2));
            //graph.DrawEllipse(pen, (int)(x[i] - m[i] / 2), (int)(pictureBox1.Height - y[i] - m[i] / 2), m[i], m[i]);

            textBox1.Text += "i=-1" + 
                "\tRa=" + (int)(pictureBox1.Width / 4) + 
                "\tRb=" + (int)(pictureBox1.Height / 4) + "\r\n";


            int Ra = (int)(pictureBox1.Width / 4);
            int Rb = (int)(pictureBox1.Height / 4);

            System.Threading.Thread.Sleep(500);

            /*
            for (int i = 0; i-20 <= Rb;)
            {
                //Graphics graph = pictureBox1.CreateGraphics();
                graph.Clear(Color.Black);

                graph.DrawLine(pen_Axes, beginOfCoord, new Point(pictureBox1.Width, y_centre));
                graph.DrawLine(pen_Axes, beginOfCoord, new Point(x_centre, 0));


                //Pen pen = new Pen(Color.Lime, 2);
                graph.DrawEllipse(pen, Ra, i < Rb ? Rb + i : 2 * Rb, 2*Ra, Rb - i > 0 ? 2 * (Rb - i) : 0);

                textBox1.Text += "i=" + i +
                    "\tRa=" + Ra +
                    "\tRb=" + (Rb - i > 0 ? 2 * (Rb - i) : 0) + "\r\n";

                System.Threading.Thread.Sleep(500);

                i += 20;
            }
            */
            //graph.Clear(Color.Black);
            //graph.DrawEllipse(pen, Ra, 2 * Rb, 2 * Ra, 0);
            int i = 0;
            bool direct = true;

            while(true)
            {
                if (direct == true)
                {
                    //Graphics graph = pictureBox1.CreateGraphics();
                    graph.Clear(Color.Black);

                    graph.DrawLine(pen_Axes, beginOfCoord, new Point(pictureBox1.Width, y_centre));
                    graph.DrawLine(pen_Axes, beginOfCoord, new Point(x_centre, 0));


                    //Pen pen = new Pen(Color.Lime, 2);
                    graph.DrawEllipse(pen, Ra, i < Rb ? Rb + i : 2 * Rb, 2 * Ra, Rb - i > 0 ? 2 * (Rb - i) : 0);

                    textBox1.Text += "i=" + i +
                        "\tRa=" + Ra +
                        "\tRb=" + (Rb - i > 0 ? 2 * (Rb - i) : 0) + "\r\n";

                    System.Threading.Thread.Sleep(500);

                    i += 20;
                    if (i - 20 >= Rb)
                    {
                        direct = false;
                    }
                }
                if (direct == false)
                {
                    //Graphics graph = pictureBox1.CreateGraphics();
                    graph.Clear(Color.Black);

                    graph.DrawLine(pen_Axes, beginOfCoord, new Point(pictureBox1.Width, y_centre));
                    graph.DrawLine(pen_Axes, beginOfCoord, new Point(x_centre, 0));


                    //Pen pen = new Pen(Color.Lime, 2);
                    graph.DrawEllipse(pen, Ra, i < Rb ? Rb + i : 2 * Rb, 2 * Ra, Rb - i > 0 ? 2 * (Rb - i) : 0);

                    textBox1.Text += "i=" + i +
                        "\tRa=" + Ra +
                        "\tRb=" + (Rb - i > 0 ? 2 * (Rb - i) : 0) + "\r\n";

                    System.Threading.Thread.Sleep(500);

                    i -= 20;
                    if (i - 20 < 0)
                    {
                        direct = true;
                    }
                }
            }
        }

    }
}

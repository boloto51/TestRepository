// https://msdn.microsoft.com/ru-ru/library/wt06kxfd(v=vs.110).aspx
// https://stackoverflow.com/questions/8536958/how-to-add-a-line-to-a-multiline-textbox
// http://life-prog.ru/2_7313_metodi-zalivki.html
// https://msdn.microsoft.com/ru-ru/library/2t63kk0t(v=vs.110).aspx

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Center_of_mass_01
{
    public partial class Form1 : Form
    {
        static int numberOfPoints = 10;
        Random rnd = new Random();
        int[] x = new int[numberOfPoints];
        int[] y = new int[numberOfPoints];
        int[] m = new int[numberOfPoints];
        int x_centre, y_centre;
        int m_sum;
        Graphics graph;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            graph = pictureBox1.CreateGraphics();
            //g.DrawLine(new Pen(Brushes.Red, 4), new Point(10, 10), new Point(100, 100));
            for (int i = 0; i < numberOfPoints; i++)
            {
                x[i] = rnd.Next(0, pictureBox1.Width);
                y[i] = rnd.Next(0, pictureBox1.Height);
                m[i] = rnd.Next(21);

                tbListPoints.Text += "x[" + i + "]=" + $"{x[i]}"
                    + "\ty[" + i + "]=" + $"{y[i]}"
                    + "\tm[" + i + "]=" + $"{m[i]}" + "\r\n";

                Pen pen = new Pen(Color.Blue, 2);
                graph.DrawEllipse(pen, (int)(x[i] - m[i] / 2), (int)(pictureBox1.Height - y[i] - m[i] / 2), m[i], m[i]);
                Brush brush = Brushes.Yellow;
                graph.FillEllipse(brush, (int)(x[i] - m[i] / 2), (int)(pictureBox1.Height - y[i] - m[i] / 2), m[i], m[i]);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            tbListPoints.Clear();
        }

        private void btnCentre_Click(object sender, EventArgs e)
        {
            x_centre = 0;
            y_centre = 0;
            m_sum = 0;

            for (int i = 0; i < numberOfPoints; i++)
            {
                x_centre += x[i] * m[i];
                y_centre += y[i] * m[i];
                m_sum += m[i];
            }

            x_centre = (int)(x_centre / m_sum);
            y_centre = (int)(y_centre / m_sum);
            tbListPoints.Text += "x_cntr=" + $"{x_centre}"
                + "\ty_cntr=" + $"{y_centre}"
                + "\tm_sum=" + $"{m_sum}" + "\r\n";

            Pen pen_centre = new Pen(Color.Red, 2);
            Brush brush_centre = Brushes.Red;
            graph.DrawEllipse(pen_centre, x_centre - 5, pictureBox1.Height - y_centre - 5, 10, 10);
            graph.FillEllipse(brush_centre, x_centre - 5, pictureBox1.Height - y_centre - 5, 10, 10);
        }
    }
}

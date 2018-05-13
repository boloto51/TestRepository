using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frontal_Dimetric_Projection
{
    public partial class Form1 : Form
    {
        Graphics graph;
        int length,x_centre, y_centre;
        Point beginOfCoord;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Оси
            Pen pen_Axes = new Pen(Brushes.Black, 1);
            //graph = pictureBox1.CreateGraphics();
            graph.DrawLine(pen_Axes, beginOfCoord, new Point(pictureBox1.Width, y_centre));
            graph.DrawLine(pen_Axes, beginOfCoord, new Point(x_centre, 0));
            graph.DrawLine(pen_Axes, beginOfCoord, new Point(0, pictureBox1.Height));
        }

        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.White;
            x_centre = (int)(pictureBox1.Width / 2);
            y_centre = (int)(pictureBox1.Height / 2);
            beginOfCoord = new Point(x_centre, y_centre);
            graph = pictureBox1.CreateGraphics();
            //graph = pictureBox1.CreateGraphics();
            //graph.DrawLine(new Pen(Brushes.Black, 1),
            //    new Point((int)(pictureBox1.Width / 2), (int)(pictureBox1.Height / 2)),
            //    new Point(pictureBox1.Width, (int)(pictureBox1.Height / 2)));
            //graph.DrawLine(new Pen(Brushes.Black, 1),
            //    new Point((int)(pictureBox1.Width / 2), (int)(pictureBox1.Height / 2)),
            //    new Point((int)(pictureBox1.Width / 2), 0));
            //graph.DrawLine(new Pen(Brushes.Black, 1),
            //    new Point((int)(pictureBox1.Width / 2), (int)(pictureBox1.Height / 2)),
            //    new Point(0, pictureBox1.Height));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            length = Convert.ToInt32(tbLenght.Text);

            //graph = pictureBox1.CreateGraphics();
            graph.Clear(Color.White);
            // Оси
            Pen pen_Axes = new Pen(Brushes.Black, 1);
            graph.DrawLine(pen_Axes, beginOfCoord, new Point(pictureBox1.Width, y_centre));
            graph.DrawLine(pen_Axes, beginOfCoord, new Point(x_centre, 0));
            graph.DrawLine(pen_Axes, beginOfCoord, new Point(0, pictureBox1.Height));

            // Куб
            Pen pen_Cube = new Pen(Brushes.Red, 2);
            // Задняя грань
            graph.DrawLine(pen_Cube, beginOfCoord, new Point(x_centre + length, y_centre));
            graph.DrawLine(pen_Cube, beginOfCoord, new Point(x_centre, y_centre - length));
            graph.DrawLine(pen_Cube, new Point(x_centre, y_centre - length), new Point(x_centre + length, y_centre - length));
            graph.DrawLine(pen_Cube, new Point(x_centre + length, y_centre), new Point(x_centre + length, y_centre - length));

            // Нижняя грань
            graph.DrawLine(pen_Cube, beginOfCoord, new Point((int)(x_centre - 0.5 * length), (int)(y_centre + 0.5 * length)));
            graph.DrawLine(pen_Cube, new Point(x_centre + length, y_centre),
                new Point((int)(x_centre + 0.5 * length), (int)(y_centre + 0.5 * length)));
            graph.DrawLine(pen_Cube, new Point((int)(x_centre - 0.5 * length), (int)(y_centre + 0.5 * length)),
                new Point((int)(x_centre + 0.5 * length), (int)(y_centre + 0.5 * length)));

            // Верхняя грань
            graph.DrawLine(pen_Cube, new Point(x_centre, y_centre - length), 
                new Point((int)(x_centre - 0.5 * length), (int)(y_centre - 0.5 * length)));
            graph.DrawLine(pen_Cube, new Point(x_centre + length, y_centre - length),
                new Point((int)(x_centre + 0.5 * length), (int)(y_centre - 0.5 * length)));
            graph.DrawLine(pen_Cube, new Point((int)(x_centre - 0.5 * length), (int)(y_centre - 0.5 * length)),
                new Point((int)(x_centre + 0.5 * length), (int)(y_centre - 0.5 * length)));

            // Боковые рёбра
            graph.DrawLine(pen_Cube, new Point((int)(x_centre - 0.5 * length), (int)(y_centre - 0.5 * length)),
                new Point((int)(x_centre - 0.5 * length), (int)(y_centre + 0.5 * length)));
            graph.DrawLine(pen_Cube, new Point((int)(x_centre + 0.5 * length), (int)(y_centre - 0.5 * length)),
                new Point((int)(x_centre + 0.5 * length), (int)(y_centre + 0.5 * length)));


        }
    }
}

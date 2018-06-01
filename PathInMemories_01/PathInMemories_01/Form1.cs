using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathInMemories_01
{
    public partial class Form1 : Form
    {
        List<int[,]> Memory = new List<int[,]>();
        Graphics graph;
        Brush brush;
        Pen pen;
        int counter = 0, x = 3, y = 3;
        int [,] Place = new int[4, 4]{{0, 1, 2, 3}, {4, 5, 6, 7}, 
                {8, 9, 10, 11}, {12, 13, 14, 15}};

        public Form1()
        {
            InitializeComponent();
            graph = pictureBox1.CreateGraphics();
            pictureBox1.BackColor = Color.White;
            btnUp.Enabled = false;
            btnDown.Enabled = false;
            btnLeft.Enabled = false;
            btnRight.Enabled = false;
            btnStart.Enabled = false;
            btnReverse.Enabled = false;
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            graph.Clear(Color.White);
            pen = new Pen(Color.Blue, 2);
            //graph.DrawRectangle(pen, 75, 75, 25, 25);
            brush = Brushes.Red;
            //graph.FillRectangle(brush, x * 25, y * 25, 25, 25);
            Memory.Add(new int[2, 1] { { x }, { y } });
            Draw(Memory[counter]);
            btnUp.Enabled = true;
            btnDown.Enabled = true;
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
            btnStart.Enabled = true;
            btnReverse.Enabled = true;
        }

        private void Draw(int[,] Pos)
        {
            graph.Clear(Color.White);
            graph.FillRectangle(brush, Pos[0,0] * 25, Pos[1,0] * 25, 25, 25);
            textBox1.Text = "counter = " + Convert.ToString(counter) + "\r\n";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            for (int n = 0; n <= counter; n++)
            {
                Draw(Memory[n]);
                System.Threading.Thread.Sleep(500);
            }
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            for (int n = counter; n >= 0; n--)
            {
                Draw(Memory[n]);
                System.Threading.Thread.Sleep(500);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (y > 0)
            {
                y = y - 1;
                counter++;
                Memory.Add(new int[2, 1] { { x }, { y } });
                Draw(Memory[counter]);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (y < 3)
            {
                y = y + 1;
                counter++;
                Memory.Add(new int[2, 1] { { x }, { y } });
                Draw(Memory[counter]);
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (x > 0)
            {
                x = x - 1;
                counter++;
                Memory.Add(new int[2, 1] { { x }, { y } });
                Draw(Memory[counter]);
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (x < 3)
            {
                x = x + 1;
                counter++;
                Memory.Add(new int[2, 1] { { x }, { y } });
                Draw(Memory[counter]);
            }
        }
    }
}

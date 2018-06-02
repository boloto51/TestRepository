using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepeatPath_03
{
    public partial class Form1 : Form
    {
        List<int[,]> Memory = new List<int[,]>();
        Graphics graph;
        Brush brush;
        Pen pen;
        int counter = 0, x = 3, y = 3;
        int[,] Place = new int[4, 4]{{0, 1, 2, 3}, {4, 5, 6, 7},
                {8, 9, 10, 11}, {12, 13, 14, 15}};
        bool tbPicBoxWidthTextChanged = false, tbPicBoxHeightTextChanged = false;
        int sizeWidth = 4, sizeHeight = 4;
        int sizeWidthPix = 25, sizeHeightPix = 25;

        public Form1()
        {
            InitializeComponent();
            //graph = pictureBox1.CreateGraphics();
            pictureBox1.BackColor = Color.White;
            btnBegin.Enabled = false;
            btnUp.Enabled = false;
            btnDown.Enabled = false;
            btnLeft.Enabled = false;
            btnRight.Enabled = false;
            btnStart.Enabled = false;
            btnReverse.Enabled = false;
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            //sizeWidthPix = (int)(pictureBox1.Width / sizeWidth);
            //sizeHeightPix = (int)(pictureBox1.Height / sizeHeight);
            x = sizeWidth - 1;
            y = sizeHeight - 1;
            graph = pictureBox1.CreateGraphics();
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
            //graph = pictureBox1.CreateGraphics();
            graph.Clear(Color.White);
            graph.FillRectangle(brush, Pos[0, 0] * sizeWidthPix,
                Pos[1, 0] * sizeHeightPix, sizeWidthPix, sizeHeightPix);
            textBox1.Text = "counter = " + Convert.ToString(counter) + "\r\n";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            for (int n = 0; n <= counter; n++)
            {
                Draw(Memory[n]);
                System.Threading.Thread.Sleep(300);
            }
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            for (int n = counter; n >= 0; n--)
            {
                Draw(Memory[n]);
                System.Threading.Thread.Sleep(300);
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
            if (y < sizeHeight - 1)
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
            if (x < sizeWidth - 1)
            {
                x = x + 1;
                counter++;
                Memory.Add(new int[2, 1] { { x }, { y } });
                Draw(Memory[counter]);
            }
        }

        private void btnMakePlace_Click(object sender, EventArgs e)
        {
            tbPicBoxWidth.ForeColor = Color.Black;
            tbPicBoxHeight.ForeColor = Color.Black;
            if (tbPicBoxWidthTextChanged == false)
            {
                tbPicBoxWidth.Text = "4";
            }
            else
            {
                if (tbPicBoxWidth.Text == "")
                {
                    tbPicBoxWidth.Text = "4";
                }
                sizeWidth = Convert.ToInt32(tbPicBoxWidth.Text);
            }
            if (tbPicBoxHeightTextChanged == false)
            {
                tbPicBoxHeight.Text = "4";
            }
            else
            {
                if (tbPicBoxHeight.Text == "")
                {
                    tbPicBoxHeight.Text = "4";
                }
                sizeHeight = Convert.ToInt32(tbPicBoxHeight.Text);
            }
            btnBegin.Enabled = true;
            Form1.ActiveForm.Width += (sizeWidth - 4) * sizeWidthPix;
            Form1.ActiveForm.Height += (sizeHeight - 4) * sizeHeightPix;
            btnBegin.Location = new Point(btnBegin.Location.X 
                + (sizeWidth - 4) * sizeWidthPix, btnBegin.Location.Y);
            textBox1.Location = new Point(textBox1.Location.X
                + (sizeWidth - 4) * sizeWidthPix, textBox1.Location.Y);
            btnUp.Location = new Point(btnUp.Location.X,
                btnUp.Location.Y + (sizeHeight - 4) * sizeHeightPix);
            btnDown.Location = new Point(btnDown.Location.X,
                btnDown.Location.Y + (sizeHeight - 4) * sizeHeightPix);
            btnLeft.Location = new Point(btnLeft.Location.X,
                btnLeft.Location.Y + (sizeHeight - 4) * sizeHeightPix);
            btnRight.Location = new Point(btnRight.Location.X,
                btnRight.Location.Y + (sizeHeight - 4) * sizeHeightPix);
            btnStart.Location = new Point(btnStart.Location.X,
                btnStart.Location.Y + (sizeHeight - 4) * sizeHeightPix);
            btnReverse.Location = new Point(btnReverse.Location.X,
                btnReverse.Location.Y + (sizeHeight - 4) * sizeHeightPix);
            pictureBox1.Width += (sizeWidth - 4) * sizeWidthPix;
            pictureBox1.Height += (sizeHeight - 4) * sizeHeightPix;
        }

        private void tbPicBoxWidth_TextChanged(object sender, EventArgs e)
        {
            tbPicBoxWidthTextChanged = true;
        }

        private void tbPicBoxHeight_TextChanged(object sender, EventArgs e)
        {
            tbPicBoxHeightTextChanged = true;
        }

        private void tbPicBoxWidth_MouseClick(object sender, MouseEventArgs e)
        {
            tbPicBoxWidth.Text = "";
        }

        private void tbPicBoxHeight_MouseClick(object sender, MouseEventArgs e)
        {
            tbPicBoxHeight.Text = "";
        }

    }
}

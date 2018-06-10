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

// аналогия с самолётом, где нос самолёта смотрит вверх, а крылья вправо и влево
// в данном случае используются 2 угла: угол рыскания и угол тангажа
// угол рыскания - это поворот самолёта в плоскости XY (плоскости экрана), задаётся элементом numberUpDown1
// угол тангажа - это поворот самолёта в плоскости перпендикулярной плоскости XY (перпендикулярно экрану) - 
// - вычисляется на каждом шаге

namespace Ellips_05
{
    public partial class Form1 : Form
    {
        int xCentr, yCentr, iStepDegree = 0, stepAnglDegree;
        double a, b, delta_t = Math.PI / 60; // шаг отрисовки линий, составляющих эллипс
        bool trigger = true; // триггер определяющий сжимается эллипс на анимации или расширяется
        Pen pen_Ellipse, pen_Axes, pen_AxisRotate; // цвет эллипса и осей
        bool finish = false; // триггер выхода из анимации
        Graphics graph;
        Thread myThread;

        public Form1()
        {
            InitializeComponent();
            graph = pictureBox1.CreateGraphics();
            xCentr = (int)(pictureBox1.Width / 2);
            yCentr = (int)(pictureBox1.Height / 2);
            pen_Ellipse = new Pen(Brushes.Lime, 1); // цвет эллипса
            pen_Axes = new Pen(Brushes.Blue, 1); // цвет координатных осей
            pen_AxisRotate = new Pen(Brushes.Red, 1); // цвет большой оси эллипса
            a = pictureBox1.Width / 4; // большая ширина эллипса
            b = pictureBox1.Height / 4; // малая ширина эллипса
            numericUpDown1.Maximum = 360; // максимальный угол поворота эллипса в градусах
            stepAnglDegree = 1; // шаг угла тангажа
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            finish = true;
            if (myThread != null) // && myThread.ThreadState == ThreadState.Running
            {
                myThread.Join();
            }
        }

        // анимация вращения эллипсов
        private void button1_Click(object sender, EventArgs e)
        {
            if (myThread == null)
            {
                myThread = new Thread(new ThreadStart(Animate));
                myThread.IsBackground = true;
                myThread.Start();
            }
        }

        private void Animate()
        {
            while (finish != true) // пока триггер завершения не активен
            {
                picBoxClear(); // очистка рисунка
                DrawAxes(); // отрисовка координатных осей
                DrawAxisRotate(numericUpDown1); // отрисовка оси эллипса
                DrawAllEllips((int)numericUpDown2.Value, iStepDegree); // отрисовка всех эллипсов в конкретной позиции

                System.Threading.Thread.Sleep(100); // задержка анимации

                // если триггер истина, то увеличиваем угол тангажа на шаг
                // если триггер ложь, то уменьшаем угол тангажа на шаг
                stepAnglDegree = (int)numericUpDown3.Value; // скорость вращения кругов (градусов на шаг)
                iStepDegree = trigger == true ? iStepDegree += stepAnglDegree : iStepDegree -= stepAnglDegree;

                // если главный эллипс повернулся на 180 градусов 
                // то меняем направление поворота на противоположное
                if (iStepDegree == 180)
                {
                    trigger = false;
                }
                if (iStepDegree == 0)
                {
                    trigger = true;
                }
            }
        }

        // метод отрисовки всех эллипсов
        // в него передаём число эллипсов и текущий шаг/угол тангажа главного эллипса
        private void DrawAllEllips(int numbOfEllipses, int iStepDegree)
        {
            // смещение угла тангажа между эллипсами в радианах
            // т.е. на сколько они друг относительно друга повёрнуты
            double PITCH_phase = Math.PI / numbOfEllipses;
            // отрисовываем каждый эллипс (все эллипсы) в конкретной позиции
            for (int i = 0; i < numbOfEllipses; i++)
            {
                // общий угол тангажа для каждого из эллипсов как сумма угла смещения относительно
                // главного эллипса и текущего шага общего для всех эллипсов
                double angl = PITCH_phase * i + iStepDegree * Math.PI / 180;
                // b - малая ширина эллипса, которая изменяется в процессе анимации
                b = (int)(pictureBox1.Height / 4 * Math.Cos(angl));
                DrawEllips(numericUpDown1, angl);
            }
        }

        // отрисовать один конкретный эллипс, в метод передаётся угол рыскания
        // (угол поворота в плоскости XY (плоскости экрана)), и общий угол тангажа каждого 
        // конкретного эллипса (угол поворота в плоскости перпендикулярной XY (перпендикулярно
        // плоскости экрана))
        private void DrawEllips(NumericUpDown numericUpDown1, double PITCH_angl)
        {
            // угол рыскания
            double YAW_angl = (double)numericUpDown1.Value * Math.PI / 180; // из градусов в радианы

            // отрисовка эллипса по точкам
            for (double t = 0; t < 2 * Math.PI; t += delta_t)
            {
                int x = (int)(a * Math.Cos(YAW_angl) * Math.Cos(t) - b * Math.Sin(YAW_angl) * Math.Sin(t));
                int y = (int)(a * Math.Sin(YAW_angl) * Math.Cos(t) + b * Math.Cos(YAW_angl) * Math.Sin(t));
                int x2 = (int)(a * Math.Cos(YAW_angl) * Math.Cos(t + delta_t) - b * Math.Sin(YAW_angl) * Math.Sin(t + delta_t));
                int y2 = (int)(a * Math.Sin(YAW_angl) * Math.Cos(t + delta_t) + b * Math.Cos(YAW_angl) * Math.Sin(t + delta_t));
                graph.DrawLine(pen_Ellipse, new Point(xCentr + x, yCentr - y),
                    new Point(xCentr + x2, yCentr - y2));

                if (finish == true)
                {
                    break;
                }
            }
        }

        // очистка рисунка
        private void picBoxClear()
        {
            graph.Clear(Color.Black);
        }

        // отрисовка осей
        private void DrawAxes()
        {
            graph.DrawLine(pen_Axes, new Point(xCentr, 0), new Point(xCentr, pictureBox1.Height));
            graph.DrawLine(pen_Axes, new Point(0, yCentr), new Point(pictureBox1.Width, yCentr));
        }

        // отрисовка главной оси эллипса, вокруг которой он поворачивается
        // используется уравнение y = k * x,  где  k = тангенс угла поворота относительно горизонтальной оси X
        // тогда по оси X надо отложить a * cos(angle) в обе стороны
        // а по оси Y надо отложить a * cos(angle) * k = a * cos(angle) * tan(angle) = a * sin(angle) в обе стороны
        private void DrawAxisRotate(NumericUpDown numericUpDown1)
        {
            double radians = (double)(numericUpDown1.Value) * Math.PI / 180; // из градусов в радианы
            int offsetX = (int)(a * Math.Cos(radians)); // смещение от центра по оси X
            int offsetY = (int)(a * Math.Sin(radians)); // смещение от центра по оси Y
            graph.DrawLine(pen_AxisRotate, new Point(xCentr + offsetX, yCentr - offsetY),
                new Point(xCentr - offsetX, yCentr + offsetY));
        }
    }
}

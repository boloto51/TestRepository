using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

//https://dxdy.ru/post483569.html

namespace Ellips_parametr_04
{
    public partial class Form1 : Form
    {
        private const double DeltaT = Math.PI / 50; // шаг отрисовки линий, составляющих эллипс
        private readonly Graphics _graph;
        private readonly Pen _penAxes; // цвет эллипса и осей
        private readonly Pen _penEllipse; // цвет эллипса и осей
        private readonly int _xCentre;
        private readonly int _yCentre;
        private bool _finish; // триггер выхода из анимации
        private Thread _myThread;
        private bool _trigger = true; // триггер определяющий сжимается эллипс на анимации или расширяется
        private int b;
        private int degree; // переменная для градусов наклона эллипса

        public Form1()
        {
            InitializeComponent();
            _graph = pictureBox1.CreateGraphics();
            _xCentre = pictureBox1.Width / 2;
            _yCentre = pictureBox1.Height / 2;
            _penEllipse = new Pen(Brushes.Lime, 1);
            _penAxes = new Pen(Brushes.Blue, 1);
            b = pictureBox1.Height / 4;
        }

        // Отрисовка 9 эллипсов с поворотом вокруг центра эллипса на 10 градусов
        private void button1_Click(object sender, EventArgs e)
        {
            ClearGraph();
            // Отрисовка 9 эллипсов с поворотом вокруг центра эллипса на 10 градусов
            for (var degreeTemp = 0; degreeTemp <= 90; degreeTemp += 10)
                DrawLineInCycle(degreeTemp);
        }

        // отрисовка 10 эллипсов разной ширины повернутых на заданный угол
        private void button2_Click(object sender, EventArgs e)
        {
            ClearGraph();
            b = pictureBox1.Height / 4;
            degree = 60; // угол поворота в градусах
            // отрисовка 10 эллипсов разной ширины повернутых на заданный угол
            for (var j = 0; j <= 10; j++)
            {
                b = b * (10 - j) / 10;
                DrawLineInCycle(degree);
                Thread.Sleep(500);
            }
        }

        // анимация одного эллипса в потоке
        private void button3_Click(object sender, EventArgs e)
        {
            if (_myThread != null) return;
            _myThread = new Thread(DrawEllipse) {IsBackground = true};
            _myThread.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _finish = true;
            _myThread?.Join();
        }

        // анимация одного эллипса
        private void DrawEllipse()
        {
            while (!_finish) // пока триггер завершения не активен
            {
                DrawEllipseFor();
                if (_finish) break;
                _trigger = true;
            }
        }

        private void DrawEllipseFor()
        {
            var list = Enumerable.Range(0, 10).ToList();
            if (!_trigger) list.Reverse();
            foreach (var i in list)
            {
                ClearGraph();
                b = pictureBox1.Height / 4 * (10 - i) / 10;
                DrawLineInCycle((int) numericUpDown1.Value);
                if (_finish) break;
                Thread.Sleep(100);
            }
        }

        private void ClearGraph()
        {
            _graph.Clear(Color.Black);
            _graph.DrawLine(_penAxes, new Point(_xCentre, 0),
                new Point(_xCentre, pictureBox1.Height));
            _graph.DrawLine(_penAxes, new Point(0, _yCentre),
                new Point(pictureBox1.Width, _yCentre));
        }

        private int GetMinus(double radians, double t, int b)
        {
            var a = pictureBox1.Width / 4;
            return (int) (a * Math.Cos(radians) * Math.Cos(t) - b * Math.Sin(radians) * Math.Sin(t));
        }

        private int GetPlus(double radians, double t, int b)
        {
            var a = pictureBox1.Width / 4;
            return (int) (a * Math.Sin(radians) * Math.Cos(t) + b * Math.Cos(radians) * Math.Sin(t));
        }

        private Point GetLinePoint(double radians, double t, int b)
        {
            var x = GetMinus(radians, t, b);
            var y = GetPlus(radians, t, b);
            return new Point(_xCentre + x, _yCentre - y);
        }

        private void DrawLineInCycle(int degreeVal)
        {
            for (double t = 0; t <= 2 * Math.PI; t = t + DeltaT)
            {
                var radians = degreeVal * Math.PI / 180; // из градусов в радианы
                var firstPoint = GetLinePoint(radians, t, b);
                var secondPoint = GetLinePoint(radians, t + DeltaT, b);
                _graph.DrawLine(_penEllipse, firstPoint, secondPoint);
                if (_finish) break;
            }
        }
    }
}
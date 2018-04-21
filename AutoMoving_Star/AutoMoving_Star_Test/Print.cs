using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMoving_Star_NoFlicker
{
    class Print
    {
        // инициализация переменных
        private int xmin, xmax, ymin, ymax;

        // инициализация объекта печати
        public Print(int _xmin, int _xmax, int _ymin, int _ymax)
        {
            xmin = _xmin;
            xmax = _xmax;
            ymin = _ymin;
            ymax = _ymax;
        }

        // оотрисовка неизменной части легенды
        public void Print_Legend_StaticPart()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Console.BufferWidth = " + Console.BufferWidth + ",");
            Console.WriteLine("Console.BufferHeight = " + Console.BufferHeight);
            Console.Write("(xmin = " + xmin + "," + "ymin = " + ymin + ")    ");
            Console.Write("(xmax = " + xmax + "," + "ymax = " + ymax + ")");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     q - exit");
        }

        // отрисовка меняющейся части легенды
        public void Print_Legend_DynamicPart(int x, int y)
        {
            Console.SetCursorPosition(0, 2);
            Console.Write("                       ");
            Console.SetCursorPosition(0, 2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("x = " + x + "," + "y = " + y);
        }

        // отрисовка стены
        public void Print_Wall()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int j = ymin; j <= ymax; j++)
            {
                for (int i = xmin; i <= xmax; i++)
                {
                    if (j == ymin || j == ymax)
                    {
                        if (i < xmax)
                        {
                            Console.SetCursorPosition(i, j);
                            Console.Write("-");
                        }
                        else
                        {
                            Console.SetCursorPosition(i, j);
                            Console.WriteLine("-");
                        }
                    }
                    else
                    {
                        if (i == xmin || i == xmax)
                        {
                            Console.SetCursorPosition(i, j);
                            Console.Write("|");
                        }
                    }
                }
            }
        }

        // отрисовка звезды
        public void Print_Star(string[] screenBufferArray)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int iy = ymin + 1; iy <= ymax - 1; iy++)
            {
                Console.SetCursorPosition(xmin + 1, iy);
                Console.Write(screenBufferArray[iy]);
            }
        }
    }
}

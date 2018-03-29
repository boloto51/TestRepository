using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMoving_Star
{
    class Print
    {
        private int _xmin, _xmax, _ymin, _ymax;

        public Print(int xmin, int xmax, int ymin, int ymax)
        {
            _xmin = xmin;
            _xmax = xmax;
            _ymin = ymin;
            _ymax = ymax;
        }

        public void PrintWall()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int j = _ymin; j <= _ymax; j++)
            {
                for (int i = _xmin; i <= _xmax; i++)
                {
                    if (j == _ymin || j == _ymax)
                    {
                        if (i < _xmax)
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
                        if (i == _xmin || i == _xmax)
                        {
                            Console.SetCursorPosition(i, j);
                            Console.Write("|");
                        }
                    }
                }
            }
        }

        public void PrintLegend(int _x, int _y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Console.BufferWidth = " + Console.BufferWidth + ",");
            Console.WriteLine("Console.BufferHeight = " + Console.BufferHeight);
            Console.Write("(_xmin = " + _xmin + "," + "_ymin = " + _ymin + ")    ");
            Console.Write("(_xmax = " + _xmax + "," + "_ymax = " + _ymax + ")");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     q - exit");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("_x = " + _x + "," + "_y = " + _y);
        }
    }
}

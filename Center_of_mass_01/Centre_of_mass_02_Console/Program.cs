using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centre_of_mass_02_Console
{
    class Program
    {
        static int numberOfPoints = 10;
        static Random rnd = new Random();
        static int[] x, y, m;

        static int x_centre, y_centre, m_sum;

        static private int xmin = 0;
        static private int ymin = 2;
        static private int xmax = Console.BufferWidth <= 20 ? Console.BufferWidth : 20;
        static private int ymax = Console.BufferHeight < 20 ? Console.BufferHeight : 21;


        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Количество точек 10: Да - Enter; Нет - введите число");

            string readline = Console.ReadLine();
            if (readline != "")
            {
                numberOfPoints = Convert.ToInt32(readline);
            }

            Console.Clear();

            PrintWall();

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Количество точек {0}", numberOfPoints);
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Масса каждой точки 1", numberOfPoints);

            x = new int[numberOfPoints];
            y = new int[numberOfPoints];
            m = new int[numberOfPoints];

            

            for (int i = 0; i < numberOfPoints; i++)
            {
                x[i] = rnd.Next(xmin + 1, xmax);
                y[i] = rnd.Next(ymin + 1, ymax);
                m[i] = 1; // rnd.Next(21);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x[i], y[i]);
                Console.Write("*");

            }

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

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x_centre, y_centre);
            Console.Write("*");

            Console.ReadLine();

        }

        static void PrintWall()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
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

    }
}

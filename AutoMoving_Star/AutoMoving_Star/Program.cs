using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//https://toster.ru/q/254821

namespace AutoMoving_Star
{
    class Program
    {
        static void Main(string[] args)
        {
            var Star = new Star();
            Star.Print();
            do
            {
                do
                {
                    //функция 
                    Star.Move();
                    Star.Print();
                    Thread.Sleep(100);
                } while (!Console.KeyAvailable);
                //обработка события нажатия на клавишу
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                    break;
                }
                else continue;
            } while (Console.ReadKey().Key != ConsoleKey.Q);

            //while (true)
            //{
            //    var key = Console.ReadKey().Key;
            //    switch (key)
            //    {
            //        case ConsoleKey.UpArrow:
            //            Star.Direction = 0;
            //            break;
            //        case ConsoleKey.DownArrow:
            //            Star.Direction = 1;
            //            break;
            //        case ConsoleKey.LeftArrow:
            //            Star.Direction = 3;
            //            break;
            //        case ConsoleKey.RightArrow:
            //            Star.Direction = 4;
            //            break;
            //        case ConsoleKey.Q:
            //            Environment.Exit(0);
            //            break;
            //    }
            //    Star.Move();
            //    Star.Print();
            //    //Console.ReadKey();
            //    Thread.Sleep(100);
        }
    }
    //}
}

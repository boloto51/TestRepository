using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

// https://toster.ru/q/254821
// http://cgp.wikidot.com/consle-screen-buffer

namespace AutoMoving_Star_NoFlicker
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
                    Thread.Sleep(1);
                } while (!Console.KeyAvailable);
                //обработка события нажатия на клавишу
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                    break;
                }
                else continue;
            } while (Console.ReadKey().Key != ConsoleKey.Q);
        }
    }
}

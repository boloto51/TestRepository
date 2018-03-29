using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_Star
{
    class Program
    {
        static void Main(string[] args)
        {
            var Star = new Star();
            Star.Print();
            while (true)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        Star.Direction = 0;
                        break;
                    case ConsoleKey.DownArrow:
                        Star.Direction = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        Star.Direction = 3;
                        break;
                    case ConsoleKey.RightArrow:
                        Star.Direction = 4;
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Star.Move();
                Star.Print();
                Console.ReadKey();
            }
        }
    }
}

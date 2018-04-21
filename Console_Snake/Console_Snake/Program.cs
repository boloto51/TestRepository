using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// http://www.cyberforum.ru/csharp-beginners/thread156433.html
// http://www.cyberforum.ru/csharp-beginners/thread665111.html
// http://www.cyberforum.ru/csharp-beginners/thread665111.html

namespace Console_Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Snake snake = new Snake();
            snake.Draw();
            while (true)
            {
                //0-up(вверх),1-down(вниз),3-left(налево),4-right(направо)
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        snake.Direction = 0;
                        break;
                    case ConsoleKey.DownArrow:
                        snake.Direction = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Direction = 3;
                        break;
                    case ConsoleKey.RightArrow:
                        snake.Direction = 4;
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                snake.Move();
                snake.Draw();
            }
        }
    }
}

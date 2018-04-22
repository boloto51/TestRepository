using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.cyberforum.ru/csharp-beginners/thread665111.html

namespace Console_Snake_from_Internet
{
    class Program
    {
        static void Main(string[] args)
        {
            var snake = new Snake(x: 5, y: 5, size: 7);
            Print(snake);
            while (true)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        snake.Direction = Direction.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        snake.Direction = Direction.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Direction = Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        snake.Direction = Direction.Right;
                        break;
                }
                snake.Move(1);
                Print(snake);
            }
        }

        private static void Print(Snake snake)
        {
            Console.Clear();
            for (var i = 0; i < snake.Size; i++)
            {
                Console.SetCursorPosition(snake[i].X, snake[i].Y);
                Console.Write(i == 0 ? "*" : "0");
            }
        }
    }

    internal class Snake
    {
        private readonly List<Segment> segments;

        public Snake(int x, int y, uint size)
        {
            if (size == 0)
                throw new ArgumentException("Размер змеи не может быть равным 0", "size");
            segments = new List<Segment>();
            for (var i = 0; i < size; i++)
                segments.Add(new Segment(x, y + i));
            Direction = Direction.Up;
        }

        public Direction Direction { get; set; }

        public int Size
        {
            get { return segments.Count; }
        }

        public Segment this[int index]
        {
            get { return segments[index]; }
        }

        public void Move(int speed)
        {
            int x = 0, y = 0;
            switch (Direction)
            {
                case Direction.Up:
                    y = -speed;
                    break;
                case Direction.Down:
                    y = speed;
                    break;
                case Direction.Left:
                    x = -speed;
                    break;
                case Direction.Right:
                    x = speed;
                    break;
            }
            for (var i = Size - 1; i >= 1; i--)
            {
                segments[i].X = segments[i - 1].X;
                segments[i].Y = segments[i - 1].Y;
            }
            segments[0].X += x;
            segments[0].Y += y;
        }
    }

    internal class Segment
    {
        public Segment(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    internal enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}

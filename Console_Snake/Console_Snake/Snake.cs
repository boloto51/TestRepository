using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Snake
{
    class Snake
    {
        public List<string> Body { get; set; }
        Random rnd = new Random();
        int x, y;
        int addX, addY, move_addX, move_addY;

        public Snake()
        {
            int course = rnd.Next(1,4);
            switch (course)
            {
                // up
                case 1 :
                    addX = 0;
                    addY = -1;
                    break;
                // down
                case 2 :
                    addX = 0;
                    addY = 1;
                    break;
                // left
                case 3 :
                    addX = -1;
                    addY = 0;
                    break;
                // right
                case 4 :
                    addX = 1;
                    addY = 0;
                    break;
            }
            Body = new List<string> { "*", "+", "+" };
            x = rnd.Next(5, 30);
            y = rnd.Next(5, 15);
        }

        public int Direction { get; set; }

        public void Move()
        {
            move_addX = Direction < 2 ? 0 : (Direction == 3 ? -1 : 1);
            move_addY = Direction > 2 ? 0 : (Direction == 0 ? -1 : 1);
        }

        public void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(x + move_addX, y + move_addY);
            Console.WriteLine(Body[0]);
            Console.SetCursorPosition(x + addX + move_addX, y + addY + move_addY);
            Console.WriteLine(Body[1]);
            Console.SetCursorPosition(x + 2 * addX + move_addX, y + 2 * addY + move_addY);
            Console.WriteLine(Body[2]);
            //Console.ReadKey();

        }
    }
}

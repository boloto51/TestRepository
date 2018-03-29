using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMoving_Star
{
    class Star
    {
        //0-up(вверх),1-down(вниз),3-left(налево),4-right(направо)
        private int _x, _y;
        private int _xmin = 0;
        private int _ymin = 4;
        private int _xmax = Console.BufferWidth <= 78 ? Console.BufferWidth : 78;
        private int _ymax = Console.BufferHeight < 23 ? Console.BufferHeight : 23;
        private Random _rnd;
        private Print _prnt;



        public int Direction { get; set; }

        public Star()
        {
            _rnd = new Random(DateTime.Now.Millisecond);
            _x = _rnd.Next(_xmin + 1, _xmax - 1);
            _y = _rnd.Next(_ymin + 1, _ymax - 1);
            _prnt = new Print(_xmin, _xmax, _ymin, _ymax);
        }

        public void Print()
        {
            Console.Clear();
            _prnt.PrintLegend(_x, _y);
            //_prnt.PrintWall();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(_x, _y);
            Console.Write("*");
        }

        public void Move()
        {
            int addX = _rnd.Next(-1, 1);
            int addY = _rnd.Next(-1, 1);
            _x = _x + addX < _xmax ? (_x + addX > _xmin ? _x + addX : _xmin + 1) : _xmax - 1;
            _y = _y + addY < _ymax ? (_y + addY > _ymin ? _y + addY : _ymin + 1) : _ymax - 1;
        }
    }
}

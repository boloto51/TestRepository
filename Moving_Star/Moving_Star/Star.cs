using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_Star
{
    class Star
    {
        //0-up(вверх),1-down(вниз),3-left(налево),4-right(направо)
        private Random _rnd = new Random();
        private int _x, _y;
        private int _xmin = 0;
        private int _ymin = 4;
        private int _xmax = Console.BufferWidth <= 78 ? Console.BufferWidth : 78;
        private int _ymax = Console.BufferHeight < 23 ? Console.BufferHeight : 23;
        Print _prnt;

        public int Direction { get; set; }

        public Star()
        {
            _x = _rnd.Next(_xmin, _xmax);
            _y = _rnd.Next(_ymin, _ymax);
            _prnt = new Print(_xmin, _xmax, _ymin, _ymax);
        }

        public void Print()
        {
            Console.Clear();
            _prnt.PrintLegend(_x, _y);
            _prnt.PrintWall();
            Console.SetCursorPosition(_x, _y);
            Console.Write("*");
        }

        public void Move()
        {
            int addX = Direction < 2 ? 0 : (Direction == 3 ? -1 : 1);
            int addY = Direction < 2 ? (Direction == 0 ? -1 : 1) : 0;
            _x = _x + addX < _xmax ? (_x + addX > _xmin ? _x + addX : _xmin + 1) : _xmax - 1;
            _y = _y + addY < _ymax ? (_y + addY > _ymin ? _y + addY : _ymin + 1) : _ymax - 1;
        }
    }
}

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
        int tmp;



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
            _prnt.PrintWall();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(_x, _y);
            Console.Write("*");
        }

        public void Move()
        {
            //tmp = _rnd.Next(0, 10);
            //int addX = tmp != 0 ? Convert.ToInt32(Math.Pow(-1, Math.Abs(tmp)) * tmp / Math.Abs(tmp)) : 0;
            //tmp = _rnd.Next(0, 10);
            //int addY = tmp != 0 ? Convert.ToInt32(Math.Pow(-1, Math.Abs(tmp)) * tmp / Math.Abs(tmp)) : 0;
            //tmp = _rnd.Next(0, 10);
            int addX = Convert.ToInt32(Math.Pow(-1, Math.Abs(_rnd.Next(0, 11))));
            //tmp = _rnd.Next(0, 10);
            int addY = Convert.ToInt32(Math.Pow(-1, Math.Abs(_rnd.Next(0, 11))));
            _x = _x + addX < _xmax ? (_x + addX > _xmin ? _x + addX : _xmin + 1) : _xmax - 1;
            _y = _y + addY < _ymax ? (_y + addY > _ymin ? _y + addY : _ymin + 1) : _ymax - 1;
        }
    }
}

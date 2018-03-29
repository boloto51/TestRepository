﻿using System;
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
        private int _ymin = 3;
        private int _xmax = Console.BufferWidth <= 78 ? Console.BufferWidth : 78;
        private int _ymax = Console.BufferHeight < 23 ? Console.BufferHeight : 23;

        public Star()
        {
            _x = _rnd.Next(_xmin, _xmax);
            _y = _rnd.Next(_ymin, _ymax);
        }

        public void Print()
        {
            Console.Clear();
            Console.Write("Console.BufferWidth = " + Console.BufferWidth + ",");
            Console.WriteLine("Console.BufferHeight = " + Console.BufferHeight);
            Console.Write("(_xmin = " + _xmin + "," + "_ymin = " + _ymin + ")    ");
            Console.WriteLine("(_xmax = " + _xmax + "," + "_ymax = " + _ymax + ")");
            Console.WriteLine("_x = " + _x + "," + "_y = " + _y);
            Console.SetCursorPosition(_x, _y);
            Console.Write("*");
        }

        public void Move()
        {
            int addX = Direction < 2 ? 0 : (Direction == 3 ? -1 : 1);
            int addY = Direction < 2 ? (Direction == 0 ? -1 : 1) : 0;
            _x = _x + addX <= _xmax ? (_x + addX >= _xmin ? _x + addX : _xmin) : _xmax;
            _y = _y + addY <= _ymax ? (_y + addY >= _ymin ? _y + addY : _ymin) : _ymax;
        }

        public int Direction { get; set; }
    }
}

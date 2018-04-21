using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMoving_Star_NoFlicker
{
    class Star
    {
        // осталось от змейки 0-up(вверх),1-down(вниз),3-left(налево),4-right(направо)
        private int x, y;
        private int xmin = 0;
        private int ymin = 4;
        private int xmax = Console.BufferWidth <= 78 ? Console.BufferWidth : 78; //78
        private int ymax = Console.BufferHeight < 23 ? Console.BufferHeight : 23; //23
        private Random rnd;
        private Print printer;
        private char[,] scrBufArr;
        private string[] screenBufferArray;

        public int Direction { get; set; }

        public Star()
        {
            // инициализация генератора случайных чисел
            rnd = new Random(DateTime.Now.Millisecond);
            // инициализация начальной позиции звезды
            x = rnd.Next(xmin + 1, xmax - 1);
            y = rnd.Next(ymin + 1, ymax - 1);

            // инициализация массивов для символов и строк внутри стены Wall
            scrBufArr = new char[xmax, ymax];
            screenBufferArray = new string[ymax];

            // инициализация объекта для отрисовки звезды
            printer = new Print(xmin, xmax, ymin, ymax);
            // один раз нарисовать неизменную часть легенды и стену Wall
            printer.Print_Legend_StaticPart();
            printer.Print_Wall();
        }

        public void Print()
        {
            // отрисовка изменяющейся части легенды
            printer.Print_Legend_DynamicPart(x, y);
            // отрисовка звезды
            printer.Print_Star(screenBufferArray);
        }

        public void Move()
        {
            // определение шага по x или y. Шагаем только по одной из координат
            int addX = rnd.Next(-1, 2);
            int addY = addX == 0 ? rnd.Next(-1, 2) : 0;
            // изменяем положение звезды
            x = x + addX < xmax ? (x + addX > xmin ? x + addX : xmin + 1) : xmax - 1;
            y = y + addY < ymax ? (y + addY > ymin ? y + addY : ymin + 1) : ymax - 1;

            // очищаем строки внутри стены
            for (int iy = 0; iy <= ymax - 1; iy++)
            {
                screenBufferArray[iy] = "";
            }

            // заполняем массив символов новым положением звезды 
            // (остальные позиции курсора консоли пустые внутри стены)
            for (int iy = ymin + 1; iy <= ymax - 1; iy++)
            {
                for (int ix = xmin + 1; ix <= xmax - 1; ix++)
                {
                    scrBufArr[ix, iy] = ((ix == x) && (iy == y)) ? Convert.ToChar("*") : Convert.ToChar(" ");
                }
            }

            // преобразуем массивы символов внутри стены в массивы строк
            for (int iy = ymin + 1; iy <= ymax - 1; iy++)
            {
                for (int ix = xmin + 1; ix <= xmax - 1; ix++)
                {
                    screenBufferArray[iy] += scrBufArr[ix, iy];
                }
            }
        }
    }
}

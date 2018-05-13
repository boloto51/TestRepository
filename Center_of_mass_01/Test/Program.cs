using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("10 или Введите число");
            string enterStr = Convert.ToString(Console.ReadLine());
            if (enterStr == "\n")
            {
                Console.WriteLine("10");
            }
            else
            {
                //Console.WriteLine(enterStr);
                Convert.ToString(Console.ReadKey().Key);
            }
            Console.ReadKey();
            /*
            if (Console.ReadKey().Key == ConsoleKey.Q)
            {
                Environment.Exit(0);
                break;
            }
            else continue;
            */
        }
    }
}

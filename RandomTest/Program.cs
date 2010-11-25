using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Random.org;
using System.Diagnostics;

namespace RandomTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int nums = 10000;
            IntegerGenerator ig = new IntegerGenerator(nums, 0, 100);
            Console.CursorVisible = false;
            while (true)
            {
                ushort i = (ushort)(ig.Get() % 16);
                Console.ForegroundColor = (ConsoleColor)(i);
                Console.CursorLeft = ig.Get() % Console.WindowWidth;
                Console.CursorTop = ig.Get() % Console.WindowHeight;
                Console.Write(i.ToString("X1"));
                System.Threading.Thread.Sleep(10);
            }*/
            Console.WriteLine(Random.org.QuotaChecker.Check());
            Console.ReadLine();
        }
    }
}
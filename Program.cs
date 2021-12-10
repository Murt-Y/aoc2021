using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace aoc2021
{
    class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            
            var c1= new D8();
            int i =c1.Part1();
            Console.WriteLine("The Result for Part 1 is " + i);
            i =c1.Part2();
            Console.WriteLine("The Result for Part 2 is " + i);
            
            sw.Stop();

            Console.WriteLine("Elapsed={0}",sw.Elapsed.TotalMilliseconds);
        }


    }
}
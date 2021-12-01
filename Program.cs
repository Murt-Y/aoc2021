using System;
using System.IO;
using System.Collections.Generic;


namespace aoc2021
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            var c1= new D1();
            int i =c1.Part1();
            Console.WriteLine("The Result for Part 1 is " + i);
            i =c1.Part2();
            Console.WriteLine("The Result for Part 2 is " + i);
        }


    }
}
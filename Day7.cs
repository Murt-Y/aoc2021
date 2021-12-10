using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2021
{
    class D7
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/7.txt");
        string[] code = text.Split("\n");
        code = code.Take(code.Count() - 1).ToArray();
        return code;
        }



        public int Part1()
        {

        string[] input =ReadMyInput();
        string[] crabi= input[0].Split(",");
        
        int[] crabs = Array.ConvertAll(crabi, s => int.Parse(s));

        int max=0;
        foreach (int c in crabs)
        {
            if (c>max){
                max=c;
            }
        }

        int i=0;
        int minf=int.MaxValue;

        while(i<max)
        {   

            int maxf=0;
            foreach(int c in crabs)
            {
                maxf=maxf+Math.Abs(i-c);
            }
            if (maxf<minf)
            {
                minf=maxf;
            }
            i++;
        }


        return minf;

    }
            public int Part2()
        {

        string[] input =ReadMyInput();
        string[] crabi= input[0].Split(",");
        
        int[] crabs = Array.ConvertAll(crabi, s => int.Parse(s));

        int max=0;
        foreach (int c in crabs)
        {
            if (c>max){
                max=c;
            }
        }

        int i=0;
        int minf=int.MaxValue;

        while(i<max)
        {   

            int maxf=0;
            foreach(int c in crabs)
            {
                int n= Math.Abs(i-c);
                maxf=maxf+((n*n)+n)/2;
            }
            if (maxf<minf)
            {
                minf=maxf;
                
            }
            //Console.WriteLine("the pos " + i + "the cost " + maxf);
            i++;
        }


        return minf;

    }
}
}

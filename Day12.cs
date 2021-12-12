using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2021
{
    class D12
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/ii.txt");
        string[] code = text.Split("\n");
        code = code.Take(code.Count() - 1).ToArray();
        return code;
        }





        public int Part1()
        {
        string[] input =ReadMyInput();
        string[,]path = new string[input.Count(),2];
        int i=0;
        foreach(string s in input)
        {
            string[] temp=input[i].Split("-");
            path[i,0]=temp[0];
            path[i,1]=temp[1];
            i++;
        }

        List <string[]> paths = new List<string[]>();
        paths.Add(path[0,0]);

        

        return 0;
    
    }
}
}

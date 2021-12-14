using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2021
{
    class D13
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/ii.txt");
        string[] code = text.Split("\n");
        code = code.Take(code.Count() - 1).ToArray();
        return code;
        }

public class coor
{ 
    public int x { get; set; }
    public int y { get; set; }
    public bool val { get; set; }
}



        public int Part1()
        {
        string[] input =ReadMyInput();
        List<coor> coordinates = new List<coor>();
        int width=0;
        int height=0;
        int i=0;
        while(i<input.Length)
        {
            string[] temp=input[i].Split(",");
            int x =Convert.ToInt32(temp[0]);
            int y =Convert.ToInt32(temp[1]);
            if(x+1>width)
            {
                width=x+1;
            }
            if(y+1>height)
            {
                height=y+1;
            }

            i++;    
        }
        int j=0;
        int k=0;
        while(j<height)
        {
            while(k<width)
            {
                coordinates.Add(new coor() {x=k, y=j, val=false});
                k++;
            }
            k=0;
            j++;
        }
        i=0;
        while(i<input.Length)
        {
            string[] temp=input[i].Split(",");
            int x =Convert.ToInt32(temp[0]);
            int y =Convert.ToInt32(temp[1]);
            coordinates[y*width+x].val=true;
            i++;    
        }
        void FoldX(int x)
        {
            List<coor> tempc = coordinates.GetRange(0, coordinates.Count);
            coordinates.Clear();

        int j=0;
        int k=0;
        while(j<height)
        {
            while(k<x)
            {
                bool value=tempc[j*width+k].val;
                if(x-k+x<width)
                {
                    value=(value || tempc[(j*width)+x+x-k].val);
                }
                coordinates.Add(new coor() {x=k, y=j, val=value});
                k++;
            }
            k=0;
            j++;
        }
        int t=coordinates.Count();
        height=coordinates[t-1].y+1;
        width=coordinates[t-1].x+1;
        }

        void FoldY(int x)
        {
            List<coor> tempc = coordinates.GetRange(0, coordinates.Count);
            coordinates.Clear();

        int j=0;
        int k=0;
        while(j<x)
        {
            while(k<width)
            {
                bool value=tempc[j*width+k].val;
                if(x-j+x<height)
                {
                    value=(value || tempc[((x+x-j)*width)+k].val);
                }
                coordinates.Add(new coor() {x=k, y=j, val=value});
                k++;
            }
            k=0;
            j++;
        }
        int t=coordinates.Count();
        height=coordinates[t-1].y+1;
        width=coordinates[t-1].x+1;
        }

        FoldX(655);
        FoldY(447);
        FoldX(327);
        FoldY(223);
        FoldX(163);
        FoldY(111);
        FoldX(81);
        FoldY(55);
        FoldX(40);
        FoldY(27);
        FoldY(13);
        FoldY(6);
        int count=0;
        void Print(){
        foreach(coor c in coordinates)
        {
            if(c.val==true)
            {
                Console.Write("#");
                count++;
            }
            else
            {
                Console.Write(".");
            }
            if(c.x%(width-1)==0 && c.x!=0)
            {
                Console.WriteLine("");
            }
        }
        }

        Print();

        return count;
        }

        public int Part2()
        {
        return 0;
    }
}
}

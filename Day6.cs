using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2021
{
    class D6
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/6.txt");
        string[] code = text.Split("\n");
        code = code.Take(code.Count() - 1).ToArray();
        return code;
        }



        public int Part1()
        {
        string[] input =ReadMyInput();
        string[] fishin= input[0].Split(",");
        List<UInt64> fish = new List<UInt64>();

        foreach(string s in fishin)
        {
            fish.Add(Convert.ToUInt64(s));
        }

        void Day(){
            int i=0;
            int k=fish.Count;
            while (i<k)
            {
                if(fish[i]>0)
                {
                    fish[i]--;
                }
                else if(fish[i]==0)
                {
                    fish[i]=6;
                    fish.Add(8);
                }

                i++;
            }
        }

        int daycount=80;
        int i=0;
        while (i<daycount)
        {
        Day();
        i++;
        }               
        return fish.Count;
        }




        public int Part2()
        {
        string[] input =ReadMyInput();
        string[] fishin= input[0].Split(",");
        List<UInt64> fish = new List<UInt64>();
        List<UInt64> fishcount = new List<UInt64>();
        int k=0;
        while (k<9)
        {
            fishcount.Add(0);
            k++;
        }

        foreach(string s in fishin)
        {
            int m=Convert.ToInt32(s);
            fishcount[m]++;
        }
        void Day()
        {
            int m=0;
            UInt64 l=fishcount[0];
            while(m<8){
                fishcount[m]=fishcount[m+1];
                m++;
            }
            fishcount[8]=l;
            fishcount[6]=fishcount[6]+l;
        }
        int daycount=256;
        int i=0;
        while (i<daycount)
        {
        Day();
        i++;
        }        

        UInt64 totalcount=0;
        foreach(UInt64 r in fishcount)
        {
            totalcount=totalcount+r;
        }       
        Console.WriteLine(totalcount);
        return 0;

    }
}
}

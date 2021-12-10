using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2021
{
    class D5
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/5.txt");
        string[] code = text.Split("\n");
        code = code.Take(code.Count() - 1).ToArray();
        return code;
        }

public class coor
{ 
    public int x { get; set; }
    public int y { get; set; }
    public int score { get; set; }

}

        public int Part1()
        {
        string[] input =ReadMyInput();

        List<coor> coordinates = new List<coor>();
        int i=0;
        int j=0;
        while (i<1000)
        {
            while(j<1000)
            {
                coordinates.Add(new coor() {x=j, y=i, score=0});
                j++;
            }
            j=0;
            i++;
        }

        foreach(string s in input)
        {
            string[] separatingStrings = { "->", "," };
            string[] wordss = s.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
            int[] words = Array.ConvertAll(wordss, int.Parse);
            int index=0;
            if(words[0]==words[2])
            {
                if (words[1]>words[3])
                {
                    index= coordinates.FindIndex(r => r.x== words[0] && r.y==words[3]);
                    int m=0;
                    while (m<=words[1]-words[3])
                    {
                        coordinates[index].score++;
                        index=index+1000;
                        m++;
                    }
                }
                else
                {
                    index= coordinates.FindIndex(r => r.x==words[0] && r.y==words[1]);
                    int m=0;
                    while (m<=words[3]-words[1])
                    {
                        coordinates[index].score++;
                        index=index+1000;
                        m++;
                    }
                }
            }
                else if(words[1]==words[3])
            {
                if (words[0]>words[2])
                {
                    index= coordinates.FindIndex(r => r.x==words[2] && r.y==words[1]);
                    int m=0;
                    while (m<=words[0]-words[2])
                    {
                        coordinates[index].score++;
                        index=index+1;
                        m++;
                    }
                }
                else
                {
                    index= coordinates.FindIndex(r => r.x==words[0] && r.y==words[1]);
                    int m=0;
                    while (m<=words[2]-words[0])
                    {
                        coordinates[index].score++;
                        index=index+1;
                        m++;
                    }
                }
            }
                
            
        }

        int finalscore=0;
        foreach(coor c in coordinates)
        {
            if(c.score>=2)
            {
                finalscore++;
            }
        }


        return finalscore;
        }
        public int Part2()
        {

        string[] input =ReadMyInput();

        List<coor> coordinates = new List<coor>();
        int i=0;
        int j=0;
        while (i<1000)
        {
            while(j<1000)
            {
                coordinates.Add(new coor() {x=j, y=i, score=0});
                j++;
            }
            j=0;
            i++;
        }

        foreach(string s in input)
        {
            string[] separatingStrings = { "->", "," };
            string[] wordss = s.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
            int[] words = Array.ConvertAll(wordss, int.Parse);
            int index=0;
            if(words[0]==words[2])
            {
                if (words[1]>words[3])
                {
                    index= coordinates.FindIndex(r => r.x== words[0] && r.y==words[3]);
                    int m=0;
                    while (m<=words[1]-words[3])
                    {
                        coordinates[index].score++;
                        index=index+1000;
                        m++;
                    }
                }
                else
                {
                    index= coordinates.FindIndex(r => r.x==words[0] && r.y==words[1]);
                    int m=0;
                    while (m<=words[3]-words[1])
                    {
                        coordinates[index].score++;
                        index=index+1000;
                        m++;
                    }
                }
            }
                else if(words[1]==words[3])
            {
                if (words[0]>words[2])
                {
                    index= coordinates.FindIndex(r => r.x==words[2] && r.y==words[1]);
                    int m=0;
                    while (m<=words[0]-words[2])
                    {
                        coordinates[index].score++;
                        index=index+1;
                        m++;
                    }
                }
                else
                {
                    index= coordinates.FindIndex(r => r.x==words[0] && r.y==words[1]);
                    int m=0;
                    while (m<=words[2]-words[0])
                    {
                        coordinates[index].score++;
                        index=index+1;
                        m++;
                    }
                }
            }
            else
            {
                int indexxs=0;
                int indexxf=0;
                int indexys=0;
                int indexyf=0;
                if (words[0]>words[2])
                {
                    indexxs=words[2];
                    indexxf=words[0];
                    indexys=words[3];
                    indexyf=words[1];
                }
                else
                {
                    indexxs=words[0];
                    indexxf=words[2];
                    indexys=words[1];
                    indexyf=words[3];
                }

                index= coordinates.FindIndex(r => r.x==indexxs && r.y==indexys);
                int m=0;
                    while (m<=indexxf-indexxs)
                    {
                        int yfactor=1;
                        if(indexys>indexyf)
                        {
                            yfactor=-1;
                        }
                        coordinates[index].score++;
                        index=index+1+(yfactor*1000);
                        m++;
                    }


            }
                
            
        }

        int finalscore=0;
        foreach(coor c in coordinates)
        {
            if(c.score>=2)
            {
                finalscore++;
            }
        }


        return finalscore;
    }
}
}

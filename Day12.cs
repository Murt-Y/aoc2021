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
        string text = File.ReadAllText(@"C:\Users\yilma\Documents\aoc2021\ii.txt");
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
        int pathcount=i;
        List<string> ways = new List<string>();
        void AddWay(string s, int j, int k)
        {
            if(k==0)
            {
            ways.Add(s+"-"+path[j,0]+"-"+path[j,1]);
            }
            if(k==1)
            {
            ways.Add(s+"-"+path[j,1]+"-"+path[j,0]);
            }
        }
        //ilk start path
        AddWay("",0,0);
        path[0,0]="*";
        path[0,1]="*";
        AddWay("",1,0);
        path[1,0]="*";
        path[1,1]="*";
        AddWay("",2,0); //3 tane start varsa
        path[2,0]="*";
        path[2,1]="*";

        i=0;
        while(i<ways.Count())
        {
            string s=ways[i];
            string[] nodes = s.Split("-");
            int c = nodes.Count();
            string finalnode=nodes[c-1];    //son kaldigi yer
            
            int m=0;
            bool change=false;
            while(finalnode!="end" && m<pathcount)
            {
                if(path[m,0]==finalnode)
                {
                    if(path[m,1].All(char.IsUpper) || !nodes.Contains(path[m,1]))
                    {
                    AddWay(s,m,0);
                    change=true;
                    }
                }
                else if(path[m,1]==finalnode)
                {
                    if(path[m,0].All(char.IsUpper) || !nodes.Contains(path[m,0]))
                    {
                    AddWay(s,m,1);
                    change=true;
                    }
                }
                m++;
            }
            if(change==true)
            {
                int t=i;
                ways.RemoveAt(t);
            }
            else{
                i++;
            }

        }

        int validpaths=0;
        foreach (string s in ways)
        {
            string[] nodes = s.Split("-");
            int c = nodes.Count();
            string finalnode=nodes[c-1];    //son kaldigi yer

            if(finalnode=="end")
            {
                validpaths++;
            }
        }

        

        return validpaths;

    }
        public int Part2()
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
        int pathcount=i;
        List<string> ways = new List<string>();
        List<bool> dcount = new List<bool>();
        void AddWay(string s, int j, int k)
        {
            if(k==0)
            {
            ways.Add(s+"-"+path[j,0]+"-"+path[j,1]);
            }
            if(k==1)
            {
            ways.Add(s+"-"+path[j,1]+"-"+path[j,0]);
            }
        }
        //ilk start path
        AddWay("",0,0);
        dcount.Add(false);
        path[0,0]="*";
        path[0,1]="*";
        AddWay("",1,0);
        dcount.Add(false);
        path[1,0]="*";
        path[1,1]="*";
        AddWay("",2,0); //3 tane start varsa
        dcount.Add(false);
        path[2,0]="*";
        path[2,1]="*";

        i=0;
        while(i<ways.Count())
        {
            string s=ways[i];
            string[] nodes = s.Split("-");
            int c = nodes.Count();
            string finalnode=nodes[c-1];    //son kaldigi yer
            
            int m=0;
            bool change=false;
            int t=i;
            while(finalnode!="end" && m<pathcount)
            {
                if(path[m,0]==finalnode)
                {
                    if(path[m,1].All(char.IsUpper) || !nodes.Contains(path[m,1]))
                    {
                    AddWay(s,m,0);
                    change=true;
                    if(dcount[t]==true)
                    {
                    dcount.Add(true);
                    }
                    else{
                    dcount.Add(false);    
                    }
                    }
                    else if(dcount[t]==false)
                    {
                    AddWay(s,m,0);
                    change=true;
                    dcount.Add(true);
                    }
                }
                else if(path[m,1]==finalnode)
                {
                    if(path[m,0].All(char.IsUpper) || !nodes.Contains(path[m,0]))
                    {
                    AddWay(s,m,1);
                    change=true;
                    if(dcount[t]==true)
                    {
                    dcount.Add(true);
                    }
                    else{
                    dcount.Add(false);    
                    }
                    }
                    else if(dcount[t]==false)
                    {
                    AddWay(s,m,1);
                    change=true;
                    dcount.Add(true);    
                    }
                }
                m++;
            }
            if(change==true)
            {
                ways.RemoveAt(t);
                dcount.RemoveAt(t);
            }
            else{
                i++;
            }

        }

        int validpaths=0;
        foreach (string s in ways)
        {
            string[] nodes = s.Split("-");
            int c = nodes.Count();
            string finalnode=nodes[c-1];    //son kaldigi yer

            if(finalnode=="end")
            {
                validpaths++;
            }
        }

        

        return validpaths;
    
    }
}
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2021
{
    class D10
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/9.txt");
        string[] code = text.Split("\n");
        code = code.Take(code.Count() - 1).ToArray();
        return code;
        }

public class coor
{ 
    public int x { get; set; }
    public int y { get; set; }
    public int val { get; set; }
    public bool low { get; set; }
    public int basin { get; set; }
}



        public int Part1()
        {
        string[] input =ReadMyInput();
        List<coor> coordinates = new List<coor>();
        int width=100;
        int height=100;

        bool CheckUp(int x)
        {
            coor t =coordinates[x];
            if(t.y==0){
            return true;
            }
            else if (coordinates[x-width].val>coordinates[x].val)
            {
                return true;
            }
            return false;
        }
        bool CheckDown(int x)
        {
            coor t =coordinates[x];
            if(t.y==height-1){
            return true;
            }
            else if (coordinates[x+width].val>coordinates[x].val)
            {
                return true;
            }
            return false;
        }
        bool CheckRight(int x)
        {
            coor t =coordinates[x];
            if(t.x==width-1){
            return true;
            }
            else if (coordinates[x+1].val>coordinates[x].val)
            {
                return true;
            }
            return false;
        }
        bool CheckLeft(int x)
        {
            coor t =coordinates[x];
            if(t.x==0){
            return true;
            }
            else if (coordinates[x-1].val>coordinates[x].val)
            {
                return true;
            }
            return false;
        }


        int i=0;
        while(i<input.Length)
        {
            string temp=input[i];
                int k=0;
                    foreach(char c in temp)
                    {
                        coordinates.Add(new coor() {x=k, y=i, val=c-'0', low=false});
                        k++;
                    }
            i++;    
        }
        i=0;
        int totalrisk=0;
        foreach(coor c in coordinates)
        {
            if(CheckDown(i)&&CheckLeft(i)&&CheckRight(i)&&CheckUp(i))
            {
                totalrisk=totalrisk+c.val+1;
            }
            i++;
        }

        return totalrisk;
        }
        public int Part2()
        {
        string[] input =ReadMyInput();
        List<coor> coordinates = new List<coor>();

        int width=100;
        int height=100;
        int lastbasin=-1;

        void CheckUp(int x, int bas)
        {
            coor t =coordinates[x];
            if (t.y==0 || coordinates[x-width].val==9){
            return;
            }
            else 
            {
                Flood(x-width,bas);
            }

        }
        void CheckDown(int x, int bas)
        {
            coor t =coordinates[x];
            if (t.y==height-1 || coordinates[x+width].val==9){
            return;
            }
            else 
            {
                Flood(x+width,bas);
            }
        }
        void CheckRight(int x, int bas)
        {
            coor t =coordinates[x];
            if (t.x==width-1 || coordinates[x+1].val==9){
            return;
            }
            else 
            {
                Flood(x+1,bas);
            }
        }
        void CheckLeft(int x, int bas)
        {
            coor t =coordinates[x];
            if (t.x==0 || coordinates[x-1].val==9){
            return;
            }
            else 
            {
                Flood(x-1,bas);
            }
        }

        void Flood(int x, int bas)
        {
            coordinates[x].basin=bas;
            if(coordinates[x].x!=0 && coordinates[x-1].basin==-1)
            {
            CheckLeft(x,bas);
            }
            if(coordinates[x].x!=width-1 && coordinates[x+1].basin==-1)
            {
            CheckRight(x,bas);
            }
            if(coordinates[x].y!=0 && coordinates[x-width].basin==-1)
            {
            CheckUp(x,bas);
            }
            if(coordinates[x].y!=height-1 && coordinates[x+width].basin==-1)
            {
            CheckDown(x,bas);
            }
        }
        int i=0;
        while(i<input.Length)
        {
            string temp=input[i];
                int k=0;
                    foreach(char c in temp)
                    {
                        coordinates.Add(new coor() {x=k, y=i, val=c-'0', basin=-1, low=false});
                        k++;
                    }
            i++;    
        }
        i=0;
        while(i<coordinates.Count())
        {
            if(coordinates[i].basin==-1 && coordinates[i].val!=9)
            {
                lastbasin++;
                Flood(i,lastbasin);
            }
            i++;
        }
        int[] basinsize = new int [lastbasin+1];
        foreach(coor c in coordinates)
        {
            if (c.basin!=-1)
            {
            basinsize[c.basin]=basinsize[c.basin]+1;
            }
        }

        Array.Sort(basinsize);
        Array.Reverse(basinsize);

        return basinsize[0]*basinsize[1]*basinsize[2];
    }
}
}

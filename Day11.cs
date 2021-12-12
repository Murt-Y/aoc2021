using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2021
{
    class D11
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/11.txt");
        string[] code = text.Split("\n");
        code = code.Take(code.Count() - 1).ToArray();
        return code;
        }

public class coor
{ 
    public int x { get; set; }
    public int y { get; set; }
    public int val { get; set; }

    public bool il { get; set; }
}



        public int Part1()
        {
        string[] input =ReadMyInput();
        List<coor> coordinates = new List<coor>();
        int width=10;
        int height=10;
        int score=0;

        void CheckUp(int x)
        {
            coor t =coordinates[x];
            coordinates[x-width].val++;
            if(coordinates[x-width].val>9 && coordinates[x-width].il==false)
                {
                    Illuminate(x-width);
                }
                return;
        }
        void CheckUpLeft(int x)
        {
            coor t =coordinates[x];
                coordinates[x-width-1].val++;
                if(coordinates[x-width-1].val>9 && coordinates[x-width-1].il==false)
                {
                    Illuminate(x-width-1);
                }
                return;
        }
                void CheckUpRight(int x)
        {
            coor t =coordinates[x];

                coordinates[x-width+1].val++;
                if(coordinates[x-width+1].val>9 && coordinates[x-width+1].il==false)
                {
                    Illuminate(x-width+1);
                }
                return;
        }
        void CheckDown(int x)
        {
            coor t =coordinates[x];
                coordinates[x+width].val++;
                if(coordinates[x+width].val>9 && coordinates[x+width].il==false)
                {
                    Illuminate(x+width);
                }
                return;
        }
        void CheckDownLeft(int x)
        {
            coor t =coordinates[x];
                coordinates[x+width-1].val++;
                if(coordinates[x+width-1].val>9 && coordinates[x+width-1].il==false)
                {
                    Illuminate(x+width-1);
                }
                return;
        }
        void CheckDownRight(int x)
        {
            coor t =coordinates[x];
                coordinates[x+width+1].val++;
                if(coordinates[x+width+1].val>9 && coordinates[x+width+1].il==false)
                {
                    Illuminate(x+width+1);
                }
                return;
        }
        void CheckRight(int x)
        {
            coor t =coordinates[x];
                coordinates[x+1].val++;
                if(coordinates[x+1].val>9 && coordinates[x+1].il==false)
                {
                    Illuminate(x+1);
                }
                return;
        }
        void CheckLeft(int x)
        {
            coor t =coordinates[x];
                coordinates[x-1].val++;
                if(coordinates[x-1].val>9 && coordinates[x-1].il==false)
                {
                    Illuminate(x-1);
                }
                return;
        }
        int i=0;
        while(i<input.Length)
        {
            string temp=input[i];
                int k=0;
                    foreach(char c in temp)
                    {
                        coordinates.Add(new coor() {x=k, y=i, val=Convert.ToInt32(c)-48, il=false});
                        k++;
                    }
            i++;    
        }
     
        void Increase(){
        foreach(coor c in coordinates)
        {
            c.val++;
        }
        }


        void Illuminate(int index)
        {
            coor t=coordinates[index];
            t.il=true;
                        if(t.y!=0 && coordinates[index-width].il==false){
            CheckUp(index);
            }
                        if(t.y!=0 && t.x!=0 && coordinates[index-width-1].il==false){
            CheckUpLeft(index);
                        }
                        if(t.y!=0 && t.x!=width-1 && coordinates[index-width+1].il==false){
            CheckUpRight(index);
                        }
                        if(t.y!=height-1 && coordinates[index+width].il==false){
            CheckDown(index);
                        }
                        if(t.y!=height-1 && t.x!=0 && coordinates[index+width-1].il==false){
            CheckDownLeft(index);
                        }
                        if(t.y!=height-1 && t.x!= width-1 && coordinates[index+width+1].il==false){
            CheckDownRight(index);
                        }
                        if(t.x!=0 && coordinates[index-1].il==false){
            CheckLeft(index);
                        }
                        if(t.x!=width-1 && coordinates[index+1].il==false){
            CheckRight(index);
        }
        }

        void Step(){
        Increase();

        foreach(coor c in coordinates)
        {
            if(c.val>9 && c.il==false)
            {
                int x = coordinates.IndexOf(c);
                Illuminate(x);
            }
        }
                foreach(coor c in coordinates)
        {
            if(c.val>9)
            {
                score++;
                c.val=0;
                c.il=false;
            }
        }


        }

        int steps =100;
        i=0;
        while (i<steps)
        {
        Step();
        i++;
        }   




        return score;
        }
        public int Part2()
        {

        string[] input =ReadMyInput();
        List<coor> coordinates = new List<coor>();
        int width=10;
        int height=10;
        int score=0;
        int sync=0;

        void CheckUp(int x)
        {
            coor t =coordinates[x];
            coordinates[x-width].val++;
            if(coordinates[x-width].val>9 && coordinates[x-width].il==false)
                {
                    Illuminate(x-width);
                }
                return;
        }
        void CheckUpLeft(int x)
        {
            coor t =coordinates[x];
                coordinates[x-width-1].val++;
                if(coordinates[x-width-1].val>9 && coordinates[x-width-1].il==false)
                {
                    Illuminate(x-width-1);
                }
                return;
        }
                void CheckUpRight(int x)
        {
            coor t =coordinates[x];

                coordinates[x-width+1].val++;
                if(coordinates[x-width+1].val>9 && coordinates[x-width+1].il==false)
                {
                    Illuminate(x-width+1);
                }
                return;
        }
        void CheckDown(int x)
        {
            coor t =coordinates[x];
                coordinates[x+width].val++;
                if(coordinates[x+width].val>9 && coordinates[x+width].il==false)
                {
                    Illuminate(x+width);
                }
                return;
        }
        void CheckDownLeft(int x)
        {
            coor t =coordinates[x];
                coordinates[x+width-1].val++;
                if(coordinates[x+width-1].val>9 && coordinates[x+width-1].il==false)
                {
                    Illuminate(x+width-1);
                }
                return;
        }
        void CheckDownRight(int x)
        {
            coor t =coordinates[x];
                coordinates[x+width+1].val++;
                if(coordinates[x+width+1].val>9 && coordinates[x+width+1].il==false)
                {
                    Illuminate(x+width+1);
                }
                return;
        }
        void CheckRight(int x)
        {
            coor t =coordinates[x];
                coordinates[x+1].val++;
                if(coordinates[x+1].val>9 && coordinates[x+1].il==false)
                {
                    Illuminate(x+1);
                }
                return;
        }
        void CheckLeft(int x)
        {
            coor t =coordinates[x];
                coordinates[x-1].val++;
                if(coordinates[x-1].val>9 && coordinates[x-1].il==false)
                {
                    Illuminate(x-1);
                }
                return;
        }
        int i=0;
        while(i<input.Length)
        {
            string temp=input[i];
                int k=0;
                    foreach(char c in temp)
                    {
                        coordinates.Add(new coor() {x=k, y=i, val=Convert.ToInt32(c)-48, il=false});
                        k++;
                    }
            i++;    
        }
     
        void Increase(){
        foreach(coor c in coordinates)
        {
            c.val++;
        }
        }


        void Illuminate(int index)
        {
            coor t=coordinates[index];
            t.il=true;
                        if(t.y!=0 && coordinates[index-width].il==false){
            CheckUp(index);
            }
                        if(t.y!=0 && t.x!=0 && coordinates[index-width-1].il==false){
            CheckUpLeft(index);
                        }
                        if(t.y!=0 && t.x!=width-1 && coordinates[index-width+1].il==false){
            CheckUpRight(index);
                        }
                        if(t.y!=height-1 && coordinates[index+width].il==false){
            CheckDown(index);
                        }
                        if(t.y!=height-1 && t.x!=0 && coordinates[index+width-1].il==false){
            CheckDownLeft(index);
                        }
                        if(t.y!=height-1 && t.x!= width-1 && coordinates[index+width+1].il==false){
            CheckDownRight(index);
                        }
                        if(t.x!=0 && coordinates[index-1].il==false){
            CheckLeft(index);
                        }
                        if(t.x!=width-1 && coordinates[index+1].il==false){
            CheckRight(index);
        }
        }

        void Step(){
        Increase();

        foreach(coor c in coordinates)
        {
            if(c.val>9 && c.il==false)
            {
                int x = coordinates.IndexOf(c);
                Illuminate(x);
            }
        }
                foreach(coor c in coordinates)
        {
            if(c.val>9)
            {
                score++;
                c.val=0;
                c.il=false;
            }
        }


        }

        int steps =100000;
        i=0;
        while (i<steps)
        {
        Step();
        bool alleq=true;
        foreach(coor c in coordinates)
        {

            if (c.val!=0)
            {
               alleq=false;
            }

        }
            if(alleq==true)
            {
                return i+1;
            }
        
        i++;



        }   




        return sync;
    }
}
}

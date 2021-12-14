using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2021
{
    class D14
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/14.txt");
        string[] code = text.Split("\n");
        code = code.Take(code.Count() - 1).ToArray();
        return code;
        }


        public int Part1()
        {
        string[] input =ReadMyInput();
        int i=2;
        string polymer =input[0];
        List<string[]> formula = new List<string[]>();
        while(i<input.Length)
        {
            string[]temp = input[i].Split(" -> ");
            formula.Add(temp);
            i++;
        }
        string Loop(string poly){
        string polytemp=poly;
        int k =poly.Length;
        int l=0;
                while(l<k-1)
                {
                    string s=poly.Substring(l,2);
                    int z=0;
                    while(z<formula.Count)
                    {
                        if(formula[z][0]==s)
                        {
                            int cutpoint=k-(l+2);
                            string t =s[0]+formula[z][1]+s[1];
                            string poly1=polytemp.Substring(0,polytemp.Length-cutpoint-2);
                            string poly2=poly.Substring(l+2);
                            polytemp=poly1+t+poly2;
                            break;
                        }
                    z++;
                    }
                    l++;
                }
        return polytemp;
        }
        i=0;
        while(i<1){
        polymer=Loop(polymer);
        i++;
        }
        List<char> elements = new List<char>();
        List<int> count = new List<int>();
        foreach(char c in polymer)
        {
            if(!elements.Exists(x => x==c)){
                elements.Add(c);
            }
        }
        i=0;
        foreach(char c in elements)
        {
            count.Add(0);
            foreach(char d in polymer)
            {
                if (d==elements[i])
                {
                    count[i]++;
                }
            }
            i++;
        }

        int max=count.Max();
        int min=count.Min();

        return max-min;
        }

        public ulong Part2()
        {
        string[] input =ReadMyInput();
        int i=2;
        string polymer =input[0];
        List<string[]> formula = new List<string[]>();
        string[] findex = new string[100];
        while(i<input.Length)
        {
            string[]temp = input[i].Split(" -> ");
            string inf = temp[0];
            string out1 =inf[0]+temp[1];
            string out2 =temp[1]+inf[1];
            string[]tempi= {inf, out1 , out2};
            formula.Add(tempi);
            findex[i-2]=inf;
            i++;
        }

        ulong [] count = new ulong [100];

        i=0;
        while(i<polymer.Length-1)
        {
            string jj =polymer.Substring(i,2);
            int indexinput=Array.FindIndex(findex,t=> t==jj);
            count[indexinput]++;
            i++;
        }



        void Insert(string ine, ulong times)
        {
            int indexinput=Array.FindIndex(findex,t=> t==ine);
            count[indexinput]=count[indexinput]-Convert.ToUInt64(times);
            int indexout1=Array.FindIndex(findex,t=> t==formula[indexinput][1]);
            count[indexout1]=count[indexout1]+Convert.ToUInt64(times);
            int indexout2=Array.FindIndex(findex,t=> t==formula[indexinput][2]);
            count[indexout2]=count[indexout2]+Convert.ToUInt64(times);
        }

        void Loop(){
            int z=0;
            ulong[] counttemp = new ulong[100];
            while (z<100)
            {
                counttemp[z]=count[z];
                z++;
            }
            int k=0;
            while(k<100)
            {
                ulong tt=counttemp[k];
                string instring=findex[k];
                Insert(instring, tt);
                k++;
            }
            
        
        }
        i=0;

        while(i<40){
        Loop();
        i++;
        }


        ulong[]elementscount=new ulong[26];
        i=0;
                foreach(string s in findex)
        {
            char c1=s[0];
            char c2=s[1];
            int indexc1=c1-'A';
            int indexc2=c2-'A';
            ulong t=Convert.ToUInt64(count[i]);
            elementscount[indexc1]=elementscount[indexc1]+t;
            elementscount[indexc2]=elementscount[indexc2]+t;

            i++;
        }
        i=0;
            char c1p=polymer[0];
            char c2p=polymer[polymer.Length-1];
            int indexc1p=c1p-'A';
            int indexc2p=c2p-'A';
            elementscount[indexc1p]=elementscount[indexc1p]+1;
            elementscount[indexc2p]=elementscount[indexc2p]+1;


        ulong max=elementscount.Max();
        ulong min=ulong.MaxValue;

        foreach(ulong x in elementscount)
        {
            if(x!=0 && x<min)
            {
                min=x;
            }
        }
        return (max-min)/2;
    }
}
}

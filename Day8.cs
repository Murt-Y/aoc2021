using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2021
{
    class D8
    {
        public class num
{ 
    public string code { get; set; }
    public int len { get; set; }
    public int no { get; set; }
}
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/8.txt");
        string[] code = text.Split("\n");
        code = code.Take(code.Count() - 1).ToArray();
        return code;
        }

        string CheckCommon(string[] codes)
        {
            string cc = codes[0];
            foreach (string s in codes )
            {
                foreach(char d in cc)
                {
                if(!s.Contains(d))
                {
                    cc= cc.Replace(d.ToString(),"");
                    }
                }
            }
        return cc;
        }
        string CheckMissing(string code)
        {
            string mis=string.Empty;
            char[] allchars = new char[] {'a','b','c','d','e','f','g'};
            foreach (char c in allchars)
            {
                if(!code.Contains(c))
                {
                    mis=mis+c;
                }
            }
        return mis;
        }

        public int Part1()
        {

        string[] input =ReadMyInput();
        int n=input.Length;
        string[,]code = new string[n,2];
        int uniq=0;
        int i=0;
        while(i<n)
        {
            string [] temp= input[i].Split("|");
            string [] incode = temp[0].Split(" ");
            incode = incode.Take(incode.Count() - 1).ToArray();
            temp[1]=temp[1].TrimStart();
            string [] outcode = temp[1].Split(" ");
            List<num> numlist = new List<num>();
            foreach(string s in incode){
                numlist.Add(new num() {code=s, len=s.Length});
            }
            int[] index = new int[10]; //index of numbers
            foreach(num t in numlist) //3 unique numbers identified
            {
                if (t.len==2)
                {
                    t.no=1;
                    index[1]=numlist.IndexOf(t);
                }
                if (t.len==4)
                {
                    t.no=4;
                    index[4]=numlist.IndexOf(t);
                }
                if (t.len==3)
                {
                    t.no=7;
                    index[7]=numlist.IndexOf(t);
                }
                if (t.len==7)
                {
                    t.no=8;
                    index[8]=numlist.IndexOf(t);
                }
            }
            foreach(string s in outcode)
            {
                if(s.Length==2 || s.Length==4 || s.Length==7 ||s.Length==3){
                    uniq++;
                }
            }
        i++;
        }
        return uniq;
        }
            public int Part2()
        {
        string[] input =ReadMyInput();
        int n=input.Length;
        string[,]code = new string[n,2];
        int finalscore=0;
        int i=0;
        while(i<n)
        {
            string [] temp= input[i].Split("|");
            string [] incode = temp[0].Split(" ");
            incode = incode.Take(incode.Count() - 1).ToArray();
            temp[1]=temp[1].TrimStart();
            string [] outcode = temp[1].Split(" ");
            List<num> numlist = new List<num>();
            foreach(string s in incode){
                numlist.Add(new num() {code=s, len=s.Length});
            }
            int[] index = new int[10]; //index of numbers
            char[] charmap =new char[7];
            char[] allchars = new char[] {'a','b','c','d','e','f','g'};
            List<int> fivers = new List<int>();
            List<int> sixers = new List<int>();
            foreach(num t in numlist) //3 unique numbers identified, index of fivers
            {
                if (t.len==2)
                {
                    t.no=1;
                    index[1]=numlist.IndexOf(t);
                }
                if (t.len==4)
                {
                    t.no=4;
                    index[4]=numlist.IndexOf(t);
                }
                if (t.len==3)
                {
                    t.no=7;
                    index[7]=numlist.IndexOf(t);
                }
                if (t.len==7)
                {
                    t.no=8;
                    index[8]=numlist.IndexOf(t);
                }
                if (t.len==5)
                {
                    fivers.Add(numlist.IndexOf(t));
                }
                if (t.len==6)
                {
                    sixers.Add(numlist.IndexOf(t));
                }
            }
            // a karakteri belli oluyor
            foreach (char c in numlist[index[7]].code)
            {
                if(!numlist[index[1]].code.Contains(c))
                {
                    charmap[0]=c;
                    break;
                }
            }

            string fcom= CheckCommon(new string[]{numlist[fivers[0]].code,numlist[fivers[1]].code,numlist[fivers[2]].code});
            string scom= CheckCommon(new string[]{numlist[sixers[0]].code,numlist[sixers[1]].code,numlist[sixers[2]].code});
            string smis=CheckMissing(scom);
            foreach (char c in smis)        //e karakteri geliyor
            {
                if(!numlist[index[4]].code.Contains(c))
                {
                    charmap[4]=c;
                    break;
                }
            }
            foreach (char c in smis)        //d karakteri geliyor
            {
                if(c!=charmap[4] && !numlist[index[7]].code.Contains(c))
                {
                    charmap[3]=c;
                    break;
                }
            }
            foreach (char c in smis)        //c karakteri geliyor
            {
                if(c!=charmap[3] && c!=charmap[4])
                {
                    charmap[2]=c;
                    break;
                }
            }

            foreach (char c in numlist[index[1]].code)        //f karakteri geliyor
            {
                if(c!=charmap[2])
                {
                    charmap[5]=c;
                    break;
                }
            }
            foreach (char c in numlist[index[4]].code)        //b karakteri geliyor
            {
                if(c!=charmap[2] && c!=charmap[3] && c!=charmap[5])
                {
                    charmap[1]=c;
                    break;
                }
            }
            foreach (char c in scom)        //g karakteri geliyor
            {
                if(c!=charmap[2] && c!=charmap[3] && c!=charmap[5] && c!=charmap[1] && c!=charmap[4] && c!=charmap[0])
                {
                    charmap[6]=c;
                    break;
                }
            }
        string signal=string.Empty;
        foreach (string si in outcode)
        {
            if(si.Length==2)
            {
                signal=signal+"1";
            }
            else if(si.Length==4)
            {
                signal=signal+"4";
            }
            else if(si.Length==7)
            {
                signal=signal+"8";
            }
            else if(si.Length==3)
            {
                signal=signal+"7";
            }
            else if(si.Length==6 && si.Contains(charmap[0]) && si.Contains(charmap[1]) && si.Contains(charmap[2]) && si.Contains(charmap[4]) && si.Contains(charmap[5]) && si.Contains(charmap[6]))
            {
                signal=signal+"0";
            }
            else if(si.Length==5 && si.Contains(charmap[0]) && si.Contains(charmap[2]) && si.Contains(charmap[3]) && si.Contains(charmap[4]) && si.Contains(charmap[6]))
            {
                signal=signal+"2";
            }
            else if(si.Length==5 && si.Contains(charmap[0]) && si.Contains(charmap[2]) && si.Contains(charmap[3]) && si.Contains(charmap[5]) && si.Contains(charmap[6]))
            {
                signal=signal+"3";
            }
            else if(si.Length==5 && si.Contains(charmap[0]) && si.Contains(charmap[1]) && si.Contains(charmap[3]) && si.Contains(charmap[5]) && si.Contains(charmap[6]))
            {
                signal=signal+"5";
            }
            else if(si.Length==6 && si.Contains(charmap[0]) && si.Contains(charmap[1]) && si.Contains(charmap[3]) && si.Contains(charmap[4]) && si.Contains(charmap[5]) && si.Contains(charmap[6]))
            {
                signal=signal+"6";
            }
            else if(si.Length==6 && si.Contains(charmap[0]) && si.Contains(charmap[1]) && si.Contains(charmap[2]) && si.Contains(charmap[3]) && si.Contains(charmap[5]) && si.Contains(charmap[6]))
            {
                signal=signal+"9";
            }
        }
        finalscore=finalscore+Convert.ToInt32(signal);


        i++;
        }
        




        return finalscore;

    }
}
}

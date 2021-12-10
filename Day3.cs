using System;
using System.IO;
using System.Collections.Generic;

namespace aoc2021
{
    class D3
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/3.txt");
        string[] code = text.Split("\n");
        code = code.Take(code.Count() - 1).ToArray();
        return code;
        }

        int Bin2Dec(int[]number)
        {
            int n=number.Length;
            int result=0;
            int i=0;
            while (i<n)
            {
                result=result+number[n-1-i]*Convert.ToInt32(Math.Pow(2,i));
                i++;
            }
            return result;
        }

        public int Part1()
        {
        string[] code =ReadMyInput();
        int codelen = code[0].Length;
        int codeno = code.Count();

        int [] gamma = new int [codelen];
        int [] epsilon = new int [codelen];

        int k=0;
        int i=0;
        int temp=0;

        while (i<codelen)
        {
            while((k<codeno))
            {   
                if(code[k][i]=='0')
                {
                    temp++;
                }
                k++;
            }
            if(temp<codeno/2)
            {
                gamma[i]=1;
            }
            temp=0;
            k=0;
            i++;
        }

        i=0;
        while (i<codelen)
        {
            if(gamma[i]==0)
            {
                epsilon[i]=1;
            }
            else
            {
                epsilon[i]=0;
            }
            i++;
        }
        int gammadec= Bin2Dec(gamma);
        int epsilondec= Bin2Dec(epsilon);        



        return gammadec*epsilondec;
        }
        public int Part2()
        {
        string[] code =ReadMyInput();
        List<string> codelisto = new List<string>();
        List<string> codelistc = new List<string>();
        
        int codelen = code[0].Length;
        int codeno = code.Count();
        
        int k=0;
        int i=0;
        int temp=0;

        while(i<codeno)
        {
            codelisto.Add(code[i]);
            codelistc.Add(code[i]);
            i++;
        }
        i=0;

        int [] gamma = new int [codelen];
        int [] epsilon = new int [codelen];


        while (i<codelen)
        {
            if(codelisto.Count==1){break;}
            while((k<codelisto.Count))
            {   
                if(codelisto.Count==1){break;}
                if(codelisto[k][i]=='0')
                {
                    temp++;
                }
                k++;
            }
            if(temp<=codelisto.Count/2)
            {
                int r=codelisto.Count;
                int z=0;
                while(z<r)
                {
                    if(codelisto[z][i]=='0')
                    {
                        codelisto.RemoveAt(z);
                        r--;
                    }
                    else
                    {
                        z++;
                    }
                }
            }
            else{
                int r=codelisto.Count;
                int z=0;
                while(z<r)
                {
                    if(codelisto[z][i]=='1')
                    {
                        codelisto.RemoveAt(z);
                        r--;
                    }
                    else
                    {
                        z++;
                    }
                }
            }

            temp=0;
            k=0;
            i++;
        }
        i=0;
        k=0;
        temp=0;
        while (i<codelen)
        {
            if(codelistc.Count==1){break;}
            while((k<codelistc.Count))
            {   
                if(codelistc.Count==1){break;}
                if(codelistc[k][i]=='0')
                {
                    temp++;
                }
                k++;
            }
            if(temp<=codelistc.Count/2)
            {
                int r=codelistc.Count;
                int z=0;
                while(z<r)
                {
                    if(codelistc[z][i]=='1')
                    {
                        codelistc.RemoveAt(z);
                        r--;
                    }
                    else
                    {
                        z++;
                    }
                }
            }
            else{
                int r=codelistc.Count;
                int z=0;
                while(z<r)
                {
                    if(codelistc[z][i]=='0')
                    {
                        codelistc.RemoveAt(z);
                        r--;
                    }
                    else
                    {
                        z++;
                    }
                }
            }



            temp=0;
            k=0;
            i++;
        }
            i=0;
            int[]codeo=new int[codelen];
            int[]codec=new int[codelen];
            string scodeo=codelisto[0];
            string scodec=codelistc[0];
            while(i<codelen)
            {
                codeo[i]=Convert.ToInt32(scodeo[i]-48);
                codec[i]=Convert.ToInt32(scodec[i]-48);
                i++;
            }
            int Orating=Bin2Dec(codeo);
            int Crating=Bin2Dec(codec);

        return Orating*Crating;



    }
}
}

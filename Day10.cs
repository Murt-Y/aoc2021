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
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/10.txt");
        string[] code = text.Split("\n");
        code = code.Take(code.Count() - 1).ToArray();
        return code;
        }

        public int Part1()
        {
            int score = 0;
            UInt64 iscore = 0;
            List<string> incomplete = new List<string>();
            List<UInt64> scoretable = new List<UInt64>();
            string OpenT(string s)
            {
                while (true){
                if(s=="")
                {
                    incomplete.Add(">");
                    return "";
                }    
                else if(s.Contains("x")){
                    return "x";
                }
                else if(s.Contains("i")){
                    return "i";
                }  
                else if (s[0]=='}')
                {
                    score=score+1197;
                    return "x";
                }
                else if (s[0]==']')
                {
                    score=score+57;
                    return "x";
                }
                else if (s[0]==')')
                {
                    score=score+3;
                    return "x";
                }

                else if (s[0]=='>')
                {
                    return s.Substring(1);
                }
                else if (s[0]=='{'){
                    s=OpenC(s.Substring(1));    
                }
                else if (s[0]=='('){
                    s=OpenP(s.Substring(1));    
                }
                else if (s[0]=='<'){
                    s=OpenT(s.Substring(1));    
                }
                else if (s[0]=='['){
                    s=OpenS(s.Substring(1));    
                }
                else{
                    return "i";  
                }

                            }
            }
            string OpenS(string s)
            {
                while (true){
                if(s=="")
                {
                    incomplete.Add("]");
                    return "";
                }    
                else if(s.Contains("x")){
                    return "x";
                }
                else if(s.Contains("i")){
                    return "i";
                }  
                else if (s[0]=='}')
                {
                    score=score+1197;
                    return "x";
                }
                else if (s[0]==')')
                {
                    score=score+3;
                    return "x";
                }
                else if (s[0]=='>')
                {
                    score=score+25137;
                    return "x";
                }

                else if (s[0]==']')
                {
                    return s.Substring(1);
                }
                else if (s[0]=='{'){
                    s=OpenC(s.Substring(1));    
                }
                else if (s[0]=='('){
                    s=OpenP(s.Substring(1));    
                }
                else if (s[0]=='<'){
                    s=OpenT(s.Substring(1));    
                }
                else if (s[0]=='['){
                    s=OpenS(s.Substring(1));    
                }
                else{
                    return "i";  
                }

                            }
            }
            string OpenC(string s)
            {
                while (true){
                if(s=="")
                {
                    incomplete.Add("}");
                    return "";
                }    
                else if(s.Contains("x")){
                    return "x";
                }
                else if(s.Contains("i")){
                    return "i";
                }  
                else if (s[0]==')')
                {
                    score=score+3;
                    return "x";
                }
                else if (s[0]==']')
                {
                    score=score+57;
                    return "x";
                }
                else if (s[0]=='>')
                {
                    score=score+25137;
                    return "x";
                }

                else if (s[0]=='}')
                {
                    return s.Substring(1);
                }
                else if (s[0]=='{'){
                    s=OpenC(s.Substring(1));    
                }
                else if (s[0]=='('){
                    s=OpenP(s.Substring(1));    
                }
                else if (s[0]=='<'){
                    s=OpenT(s.Substring(1));    
                }
                else if (s[0]=='['){
                    s=OpenS(s.Substring(1));    
                }
                else{
                    return "i";  
                }

                            }
            }
            string OpenP(string s)
            {
                while (true){
                if(s=="")
                {
                    incomplete.Add(")");
                    return "";
                }    
                else if(s.Contains("x")){
                    return "x";
                }
                else if(s.Contains("i")){
                    return "i";
                }    
                else if (s[0]=='}')
                {
                    score=score+1197;
                    return "x";
                }
                else if (s[0]==']')
                {
                    score=score+57;
                    return "x";
                }
                else if (s[0]=='>')
                {
                    score=score+25137;
                    return "x";
                }

                else if (s[0]==')')
                {
                    return s.Substring(1);
                }
                else if (s[0]=='{'){
                    s=OpenC(s.Substring(1));    
                }
                else if (s[0]=='('){
                    s=OpenP(s.Substring(1));    
                }
                else if (s[0]=='<'){
                    s=OpenT(s.Substring(1));    
                }
                else if (s[0]=='['){
                    s=OpenS(s.Substring(1));    
                }
                else{
                    return "i";  
                }

                            }
            }
        string[] input =ReadMyInput();
int count=0; 
    while(count<input.Length){

        string t = input[count];
        //bunlarla başlamazsa ne olacağını da yaz
        while(t!="" && !t.Contains("x") && !t.Contains("i")){
        if(t[0]=='('){
        t=OpenP(t.Substring(1));
        }
        else if(t[0]=='{'){
        t=OpenC(t.Substring(1));
        }
        else if(t[0]=='['){
        t=OpenS(t.Substring(1));
        }
        else if(t[0]=='<'){
        t=OpenT(t.Substring(1));
        }
    }
        foreach(string s in incomplete)
        {
            UInt64 sf=0;
            if (s==")")
            {
                sf=1;
            }
            else if (s=="]")
            {
                sf=2;
            }
            else if (s=="}")
            {
                sf=3;
            }
            else if (s==">")
            {
                sf=4;
            }

            iscore=iscore*5+sf;
        }
        if(iscore!=0){
        scoretable.Add(iscore);
        }
        iscore=0;
        incomplete.Clear();
        count++;
    }
        scoretable.Sort();
        int k=(scoretable.Count+1)/2;
        Console.WriteLine("Incomplete Score is " + scoretable[k-1]);
        return score;
        }
        public int Part2()
        {
   
        return 0;
    }
}
}

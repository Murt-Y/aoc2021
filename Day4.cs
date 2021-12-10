using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2021
{
    class D4
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/4.txt");
        string[] code = text.Split("\n");
        code = code.Take(code.Count() - 1).ToArray();
        return code;
        }

public class bingo
{ 
    public int x { get; set; }
    public int y { get; set; }
    public int no { get; set; }
    public bool mark { get; set; }
    public int cardno {get; set;}

}

        public int Part1()
        {
        string[] input =ReadMyInput();
        string[] winningnos=input[0].Split(",");



        List<bingo> bingocards = new List<bingo>();
        int i=2;
        int lastx=0;
        int lasty=0;
        int cardcount=0;

        while (i<input.Length)
        {
            string[]nos=input[i].Split(" ");
            foreach(string s in nos)
            {
                if(s!=" " && s!="")
                {
                bingocards.Add(new bingo() {x=lastx%5, y=lasty%5, no=Convert.ToInt32(s), mark=false, cardno=cardcount/25});
                lastx++;
                cardcount++;
                }
            }
            if (nos.Length!=1) //if only empty line is present skip increasing y
            {
                lasty++;
            }
            i++;
        }

        void DrawNo(int x)
        {
            foreach (bingo t in bingocards)
            {
                if (t.no==x)
                {
                    t.mark=true;
                }
            }
        }

        int numberofcards=bingocards.Count;
        int CheckWin()
        {
            List<bingo> winners = bingocards.FindAll(h => h.mark==true);
            int t=winners.Count;
            int k=0;
            while (k<numberofcards)
            {
                List<bingo> singlecard = winners.FindAll(h => h.mark==true && h.cardno==k); 
                if(singlecard.Count>=5)
                {
                    if(singlecard.Count(m=> m.x==0) == 5 || singlecard.Count(m=> m.x==1) == 5 || singlecard.Count(m=> m.x==2) == 5 || singlecard.Count(m=> m.x==3) == 5 || singlecard.Count(m=> m.x==4) == 5 || singlecard.Count(m=> m.y==0) == 5 || singlecard.Count(m=> m.y==1) == 5 || singlecard.Count(m=> m.y==2) == 5 || singlecard.Count(m=> m.y==3) == 5 ||  singlecard.Count(m=> m.y==4) == 5){
                        
                        List<bingo> winningcardunmarked = bingocards.FindAll(h => h.mark==false && h.cardno==k); 
                        int score=0;
                        foreach(bingo b in winningcardunmarked)
                        {
                            score=score+b.no;
                        }
                        return score;
                    }
                }
                k++;
            }
            return 0;
        }
        foreach (string s in winningnos)
            {
                DrawNo(Convert.ToInt32(s));
                int score = CheckWin();
                if (score!=0)
                {
                    score=score*Convert.ToInt32(s);
                    return score;
                }
                
            }


        return 0;
        }
        public int Part2()
        {
        string[] input =ReadMyInput();
        string[] winningnos=input[0].Split(",");
        List <int> markedcards = new List<int>();



        List<bingo> bingocards = new List<bingo>();
        int i=2;
        int lastx=0;
        int lasty=0;
        int cardcount=0;

        while (i<input.Length)
        {
            string[]nos=input[i].Split(" ");
            foreach(string s in nos)
            {
                if(s!=" " && s!="")
                {
                bingocards.Add(new bingo() {x=lastx%5, y=lasty%5, no=Convert.ToInt32(s), mark=false, cardno=cardcount/25});
                lastx++;
                cardcount++;
                }
            }
            if (nos.Length!=1) //if only empty line is present skip increasing y
            {
                lasty++;
            }
            i++;
        }

        void DrawNo(int x)
        {
            foreach (bingo t in bingocards)
            {
                if (t.no==x)
                {
                    t.mark=true;
                }
            }
        }

        int numberofcards=bingocards.Count;
        int CheckWin()
        {
            List<bingo> winners = bingocards.FindAll(h => h.mark==true);
            int k=0;
            int score=0;
            while (k<numberofcards)
            {
                if(!markedcards.Contains(k))
                {
                List<bingo> singlecard = winners.FindAll(h => h.mark==true && h.cardno==k); 
                if(singlecard.Count>=5)
                {
                    if(singlecard.Count(m=> m.x==0) == 5 || singlecard.Count(m=> m.x==1) == 5 || singlecard.Count(m=> m.x==2) == 5 || singlecard.Count(m=> m.x==3) == 5 || singlecard.Count(m=> m.x==4) == 5 || singlecard.Count(m=> m.y==0) == 5 || singlecard.Count(m=> m.y==1) == 5 || singlecard.Count(m=> m.y==2) == 5 || singlecard.Count(m=> m.y==3) == 5 ||  singlecard.Count(m=> m.y==4) == 5){
                        markedcards.Add(k);
                        List<bingo> winningcardunmarked = bingocards.FindAll(h => h.mark==false && h.cardno==k); 
                        score=0;
                        foreach(bingo b in winningcardunmarked)
                        {
                            score=score+b.no;
                        }
                    }
                }
                }
                k++;
            }
            return score;
        }
        int finalscore=0;
        foreach (string s in winningnos)
            {
                
                DrawNo(Convert.ToInt32(s));
                int score = CheckWin();
                if (score!=0)
                {
                    score=score*Convert.ToInt32(s);
                    finalscore=score;
                }
            }
        return finalscore;



    }
}
}

using System;
using System.IO;
using System.Collections.Generic;

namespace aoc2021
{
    class D2
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/2.txt");
        string[] depth = text.Split("\n");
        depth = depth.Take(depth.Count() - 1).ToArray();
        return depth;

        }
        public int Part1()
        {
        string[] depth =ReadMyInput();
        int posx=0;
        int posy=0;

        int no = depth.Count();
        int i=0;

        while (i<no)
        {
            string [] command = depth[i].Split(" ");
            if (command[0]=="forward")
            {
                posx=posx+Convert.ToInt32(command[1]);
            }
            else if (command[0]=="down")
            {
                posy=posy+Convert.ToInt32(command[1]);
            }
            else if (command[0]=="up")
            {
                posy=posy-Convert.ToInt32(command[1]);
            }
            i++;
        }

        return posx*posy;
        }
        public int Part2()
        {
        string[] depth =ReadMyInput();
        int aim=0;
        int posx=0;
        int posy=0;

        int no = depth.Count();
        int i=0;

        while (i<no)
        {
            string [] command = depth[i].Split(" ");
            if (command[0]=="forward")
            {
                posx=posx+Convert.ToInt32(command[1]);
                posy=posy+(aim*Convert.ToInt32(command[1]));
            }
            else if (command[0]=="down")
            {
                aim=aim+Convert.ToInt32(command[1]);
            }
            else if (command[0]=="up")
            {
                aim=aim-Convert.ToInt32(command[1]);
            }
            i++;
        }

        return posx*posy;
        }



    }
}

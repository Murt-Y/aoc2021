using System;
using System.IO;
using System.Collections.Generic;

namespace aoc2021
{
    class D1
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/home/murat/Documents/aoc2021/1.txt");
        string[] depth = text.Split("\n");
        depth = depth.Take(depth.Count() - 1).ToArray();
        return depth;

        }
        public int Part1()
        {
        string[] depth =ReadMyInput();
        int nomeas = depth.Count();
        int i=1;
        int countincrease=0;

        
        while (i<nomeas)
        {
            if (Convert.ToInt32(depth[i])>Convert.ToInt32(depth[i-1]))
            {
                countincrease++;
            }
            i++;
        }

        return countincrease;
        }
        public int Part2()
        {
        string[] depth =ReadMyInput();
        int nomeas = depth.Count();
        int[]depthi = new int[nomeas];
        
        int i=0;
        while(i<nomeas)
        {
            depthi[i]=Convert.ToInt32(depth[i]);
            i++;
        }

        int countincrease=0;

        i=3;
        while (i<nomeas)
        {
            if (depthi[i]>depthi[i-3])
            {
                countincrease++;
            }
            i++;
        }

        return countincrease;
        }



    }
}

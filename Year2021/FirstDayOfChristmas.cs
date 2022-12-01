using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021
{
    public class FirstDayOfChristmas
    {

        public static int Sonar(List<int> depths)
        {
            var deeperCount = 0;
            for (int i = 1; i < depths.Count; i++)
            {
                if (depths[i] > depths[i - 1])
                {
                    deeperCount++;
                }
            }
            return deeperCount;
        }

        public static int BetterSonar(List<int> depths)
        {
            int deeperCount = 0;
            var prevWindow = int.MaxValue;
            var currentWindow = 0 ;
            for (int i = 1; i < depths.Count-1; i++)
            {
                currentWindow = depths[i - 1] + depths[i]+depths[i+1];
                if (currentWindow > prevWindow)
                {
                    deeperCount++;
                }
                prevWindow = currentWindow;
            }
            return deeperCount;
        }
    }
}

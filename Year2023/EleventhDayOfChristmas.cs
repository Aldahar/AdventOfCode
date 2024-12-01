using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2023
{
    internal class EleventhDayOfChristmas
    {
        public static int FindGalaxies(List<string> lines)
        {
            lines = SpaceOutTheView(lines);

            List<(int,int)> galaxies = new();

            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    if (lines[i][j] == '#')
                    {
                        galaxies.Add((i, j));
                    }
                }

            }
            var totalDistance = 0;
            for (int i = 0; i < galaxies.Count-1; i++)
            {
                for(int j = i+1; j<galaxies.Count; j++)
                {
                    var diffX = Math.Abs(galaxies[i].Item1 - galaxies[j].Item1);
                    var diffY = Math.Abs(galaxies[i].Item2 - galaxies[j].Item2);
                    totalDistance += diffX+diffY;
                }
            }



            return totalDistance;
        }

        private static List<string> SpaceOutTheView(List<string> lines) 
            {
            for (int i = 0; i < lines.Count; i++)
            {
                if (!lines[i].Contains('#'))
                {
                    lines.Insert(i, lines[i]);
                    i++;
                }

            }

            for (int i = 0; i < lines[0].Length - 1; i++)
            {
                bool containsOnlyZeros = true;
                for (int j = 0; j < lines.Count; j++)
                {
                    if (lines[j][i] != '.')
                    {
                        containsOnlyZeros = false;
                        break;
                    }

                }
                if (containsOnlyZeros)
                {
                    for (int k = 0; k < lines.Count; k++)
                    {
                        lines[k] = lines[k].Insert(i, ".");

                    }
                    i++;
                }

            }
            return lines;
        } 
    }
}

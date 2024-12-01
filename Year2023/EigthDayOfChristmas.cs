using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2023
{
    public class EigthDayOfChristmas
    {
        public static int ReadTheMap(List<string> lines)
        {
            var directions = lines[0];

            lines.RemoveRange(0, 2);
            var mapNodes = new List<MapNode>();
            
            foreach (string line in lines) {
                mapNodes.Add(new MapNode(line));
            
            }
            var current = mapNodes.First(row=>row.currentLocation=="AAA");
            var count = 0;
            while(current.currentLocation != "ZZZ")
            {
                current = mapNodes.First(row => row.currentLocation == current.GetDirection(directions[count%directions.Length]));
                count++;

            }


            return count;



        }

        public static int ReadTheMapForGhosts(string directions,List<MapNode> mapNodes, string start)
        {

            var current = mapNodes.First(row => row.currentLocation == start);
            var count = 0;
            while (current.currentLocation.Last() != 'Z')
            {
                current = mapNodes.First(row => row.currentLocation == current.GetDirection(directions[count % directions.Length]));
                count++;

            }


            return count;



        }

        public static long GhostSteps(List<string> lines)
        {
            var directions = lines[0];

            lines.RemoveRange(0, 2);
            var mapNodes = new List<MapNode>();

            foreach (string line in lines)
            {
                mapNodes.Add(new MapNode(line));

            }
            var current = mapNodes.Where(row => row.currentLocation.Last() == 'A').ToList();
            var count = 0;

            List<long> stepsToFinish = new();

            foreach (var cylce in current)
            {
                stepsToFinish.Add(ReadTheMapForGhosts(directions, mapNodes, cylce.currentLocation));
                
            }
            return stepsToFinish.Aggregate(LeastCommonMultiple);

        }

        private static long GreatestCommonDenominator(long a, long b)
        {
            long remainder;

            while (b != 0)
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
        }

        private static long LeastCommonMultiple(long a, long b)
        {
            return (a * b) / GreatestCommonDenominator(a, b);
        }

    }


    public class MapNode
    {
        public string currentLocation { get; set; }
        public string LeftLocation { get; set; }

        public string RightLocation { get; set; }

        public MapNode()
        {
             
        }
        public MapNode(string mapLine)
        {
            currentLocation = mapLine.Split('=')[0].Trim();
            LeftLocation = mapLine.Split("=")[1].Trim().Split(',')[0].Replace("(","").Trim();
            RightLocation = mapLine.Split("=")[1].Trim().Split(',')[1].Replace(")", "").Trim();

        }

       public string GetDirection(char direction)
        {
            switch (direction)
            {
                case 'R':
                    return RightLocation;
                case 'L':
                    return LeftLocation;
                default:
                    return LeftLocation;
            }
        }

    }
}

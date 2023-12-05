using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2023
{
    public class FifthDayOfChristmas
    {
        public static long CalculateSeedPosition(List<string> lines)
        {
            var seeds = lines[0].Split(' ').ToList();
            seeds.RemoveAt(0);
            lines.RemoveRange(0, 2);

            long min = long.MaxValue;

            var blockList = splitInputInBlocks(lines);

            List<Dictionary<long,long>> allDictionaries = new List<Dictionary<long,long>>();


            foreach (var block in blockList)
            {
                allDictionaries.Add(populateDictionary(block));
            }

            foreach (var seed in seeds)
            {
                var currentLocation = long.Parse( seed);

                foreach (var dict in allDictionaries)
                {
                    currentLocation = dict.ContainsKey(currentLocation) ? dict[currentLocation] : currentLocation;



                }
                if (currentLocation < min)
                {
                    min = currentLocation;
                }


            }




            return min;
        }



        public static Dictionary<long,long> populateDictionary(List<string> lines)
        {
            Dictionary<long,long> seedMap = new Dictionary<long,long>();
            foreach (string line in lines)
            {
                var numbers = line.Split(' ');
                var destination = long.Parse(numbers[0]);
                var origin = long.Parse(numbers[1]);
                var length = long.Parse(numbers[2]);

                for (int i = 0; i < length; i++)
                {
                    seedMap.Add(origin+i, destination+i);

                }

            }
            return seedMap;

        }

        public static Dictionary<long, long> populateDictionary(Dictionary<long,long> dict, long destination, long origin, long length)
        {
                for (int i = 0; i < length; i++)
                {
                    dict.Add(origin + i, destination + i);

                }
            return dict;

        }

        public static List<List<string>> splitInputInBlocks(List<string> lines)
        {
            int blockNumber = -1;
            var blockList = new List<List<string>>();
            var currentBlockList = new List<string>();

            foreach (var line in lines)
            {
                
                if (line.Contains('-'))
                {
                    currentBlockList = new();
                    blockNumber++;

                }
                else if (line.Any(char.IsDigit))
                {
                    currentBlockList.Add(line);
                }
                else
                {
                    var newList = new List<string>(currentBlockList);
                    blockList.Add(newList);
                    currentBlockList.Clear();
                }
                    
            }

            return blockList;


        }

    }
}

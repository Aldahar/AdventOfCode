using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public class ThirdDayOfChristmas
    {
        public static long MermoryCorruptor(List<string> input)
        {
            long counter = 0;
            Regex rule = new(@"mul\(\d+,\d+\)");
            StringBuilder sb = new StringBuilder();
            input.ForEach(row => sb.Append(row));
            
            var results = rule.Matches(sb.ToString());
            foreach (Match match in results)
            {
                var result = match.Value.Substring(4,(match.Value.Length-5)).Split(',').ToList().ConvertAll(row=>Int32.Parse(row));
                counter += result[0] * result[1];
            }

            return counter;
        }
        
        public static long MemoryCorruptorDo(List<string> input)
        {
            long counter = 0;
            Regex rule = new(@"mul\(\d+,\d+\)|do\(\)|don't\(\)");
            StringBuilder sb = new StringBuilder();
            input.ForEach(row => sb.Append(row));

            string allCommands = "".PadLeft(sb.ToString().Length, '-');
            string onlyValidMuls = "".PadLeft(sb.ToString().Length, '-');

            var results = rule.Matches(sb.ToString());
            bool doAct = true;
            foreach (Match match in results)
            {
                
                switch (match.Value)
                {
                    case "do()":
                        doAct = true;
                        allCommands = allCommands.Remove(match.Index, 4).Insert(match.Index, "do()");
                        break;
                    case "don't()":
                        doAct = false;
                        allCommands = allCommands.Remove(match.Index, 6).Insert(match.Index, "don't()");
                        break;
                    default:
                        if (doAct)
                        {
                            var result = match.Value.Substring(4, (match.Value.Length - 5)).Split(',').ToList().ConvertAll(row => Int32.Parse(row));
                            counter += result[0] * result[1];
                            allCommands = allCommands.Remove(match.Index, match.Length).Insert(match.Index, match.Value);
                            onlyValidMuls= onlyValidMuls.Remove(match.Index, match.Length).Insert(match.Index, match.Value);


                        }
                        break;
                }
            }
            Console.WriteLine(allCommands);
            Console.WriteLine(onlyValidMuls);
            return counter;
        }
    }
}

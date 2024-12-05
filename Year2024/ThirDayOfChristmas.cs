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

            var results = rule.Matches(sb.ToString());
            bool doAct = true;
            foreach (Match match in results)
            {
                
                switch (match.Value)
                {
                    case "do()":
                        doAct = true;
                        break;
                    case "don't()":
                        doAct = false;
                        break;
                    default:
                        if (doAct)
                        {
                            var result = match.Value.Substring(4, (match.Value.Length - 5)).Split(',').ToList().ConvertAll(row => Int32.Parse(row));
                            counter += result[0] * result[1];
                        }
                        break;
                }
            }
            return counter;
        }
    }
}

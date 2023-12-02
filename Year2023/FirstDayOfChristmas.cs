using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class FirstDayOfChristmas
    {
        public static int CalculateCalibration(List<string> lines)
        {
            int counter = 0;
            foreach (string line in lines)
            {
                var numbersOnly = Regex.Replace(line, "[^0-9.]", "");

                var firstNumber = numbersOnly.First();
                var secondNumber = numbersOnly.Last();
                var addedNumber = int.Parse("" + firstNumber + secondNumber);
                counter += addedNumber;
            }
            return counter;
        }

        public static int CalculateCalibrationWords(List<string> lines)
        {
            int counter = 0;

            string[] numbers = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string pattern = @"(one|two|three|four|five|six|seven|eight|nine)";

            foreach (var line in lines)
            {
                if (line.Contains("oneight"))
                {
                    Console.WriteLine("utterbullshit");
                }

                Regex regex = new Regex(pattern);

                string output = regex.Replace(line, match => match.Value.First() + (Array.IndexOf(numbers, match.Value) + 1).ToString() + match.Value.Last());
                string output2 = regex.Replace(output, match => match.Value.First() + (Array.IndexOf(numbers, match.Value) + 1).ToString() + match.Value.Last());

                var numbersOnly = Regex.Replace(output2, "[^0-9.]", "");

                var firstNumber = numbersOnly.First();
                var secondNumber = numbersOnly.Last();
                var addedNumber = int.Parse("" + firstNumber + secondNumber);
                counter += addedNumber;

            }

            return counter;
        }

    }
}
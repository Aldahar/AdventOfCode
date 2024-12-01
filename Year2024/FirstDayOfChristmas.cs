using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public class FirstDayOfChristmas
    {
        public static int SimilarityScore(List<string> input)
        {
            int simScore = 0;
            List<int> numbersRight = new();
            List<int> numbersLeft = new();
            foreach (var line in input)
            {
                var numbers = line.Split("   ");
                numbersRight.Add(Int32.Parse(numbers[1]));
                numbersLeft.Add(Int32.Parse(numbers[0]));

            }
            numbersRight = numbersRight.OrderBy(row => row).ToList();
            numbersLeft = numbersLeft.OrderBy(row => row).ToList();

            foreach (var item in numbersLeft)
            {
                simScore += item * numbersRight.Count(row => row == item);
            }

            return simScore;
        }


        public static int ListCompare(List<string> input)
        {
            int totalDiff = 0;
            List<int> numbersRight = new();
            List<int> numbersLeft = new();
            foreach (var line in input)
            {
                var numbers = line.Split("   ");
                numbersRight.Add(Int32.Parse(numbers[0]));
                numbersLeft.Add(Int32.Parse(numbers[1]));

            }
            numbersRight = numbersRight.OrderBy(row => row).ToList();
            numbersLeft= numbersLeft.OrderBy(row => row).ToList();

            for (int i = 0; i < numbersRight.Count; i++)
            {
                totalDiff += Math.Abs(numbersRight[i] - numbersLeft[i]);
            }

            return totalDiff;

        }

       

    }
}

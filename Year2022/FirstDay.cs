using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public class FirstDay
    {
        public static List<int> Calories(List<string> caloriesList)
        {
            var runningSum = 0;
            List<int> caloriesPerElf = new List<int>();
            foreach (var calorie in caloriesList)
            {
                if(calorie == "")
                {
                    caloriesPerElf.Add(runningSum);
                    runningSum = 0;
                }
                else
                {
                    int cal = int.Parse(calorie);
                    runningSum += cal;
                }
            }
            return caloriesPerElf;
        }

        public static int TopThreeCalories(List<string> caloriesList)
        {
            var list = Calories(caloriesList);
            var sortedCalories = list.OrderByDescending(row => row).ToList();

            return sortedCalories[0] + sortedCalories[1] + sortedCalories[2];
        }
    }
}

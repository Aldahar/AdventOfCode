using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2022
{
    public class Puzzles
    {
        #region Day One

        /// <summary>
        /// Calculates the sum
        /// </summary>
        /// <param name="caloriesList"></param>
        /// <returns></returns>
        public static List<int> Calories(List<string> caloriesList)
        {
            var runningSum = 0;
            List<int> caloriesPerElf = new List<int>();
            foreach (var calorie in caloriesList)
            {
                if (calorie == "")
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
            return caloriesPerElf.OrderByDescending(row => row).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caloriesList"></param>
        /// <returns></returns>
        public static int TopThreeCalories(List<string> caloriesList)
        {
            var sortedCalories = Calories(caloriesList);


            return sortedCalories[0] + sortedCalories[1] + sortedCalories[2];
        }
        #endregion

        #region Day Two

        public static int RockPaperScissors(List<string> stragetyGuide)
        {
            // A = X =Rock = 1
            // B = Y = Paper = 2
            // C = Z = Scissors =3
            // lose = 0
            // draw = 3
            // win = 6
            int totalPoints = 0;
            foreach (var round in stragetyGuide)
            {
                if(round == "")
                {
                    return totalPoints;
                }
                var roundPoints = 0;
                if (round[2] == 'X')
                {
                    roundPoints += 1;

                    if (round[0]=='A')
                        roundPoints += 3;
                    else if (round[0] == 'C')
                        roundPoints += 6;
                }
                else if (round[2] == 'Y')
                {
                    roundPoints += 2;
                    if (round[0] == 'B')
                        roundPoints += 3;
                    else if (round[0] == 'A')
                        roundPoints += 6;
                }
                else if (round[2] == 'Z')
                {
                    roundPoints += 3;
                    if (round[0] == 'C')
                        roundPoints += 3;
                    else if (round[0] == 'B')
                        roundPoints += 6;
                }
                totalPoints += roundPoints;
            }


            return totalPoints;
        }

        public static int RockPaperScissorsAfterTheElfStoppedTrolling(List<string> stragetyGuide)
        {
            // x = lose, y = draw, z = win
            int totalPoints = 0;
            foreach (var round in stragetyGuide)
            {
                if (round == "")
                {
                    return totalPoints;
                }

                var roundPoints = 0;

                if (round[2] == 'X')
                {
                    roundPoints += 0;

                    if (round[0] == 'A')
                        roundPoints += 3;
                    else if (round[0] == 'B')
                        roundPoints += 1;
                    else if (round[0] == 'C')
                        roundPoints += 2;
                }

                else if (round[2] == 'Y')
                {
                    roundPoints += 3;
                    if (round[0] == 'A')
                        roundPoints += 1;
                    else if (round[0] == 'B')
                        roundPoints += 2;
                    else if (round[0] == 'C')
                        roundPoints += 3;
                }

                else if (round[2] == 'Z')
                {
                    roundPoints += 6;
                    if (round[0] == 'A')
                        roundPoints += 2;
                    else if (round[0] == 'B')
                        roundPoints += 3;
                    else if (round[0] == 'C')
                        roundPoints += 1;
                }
                totalPoints += roundPoints;
            }
            return totalPoints;
        }

        public static (int,int) RockPaperScissorsBestSolution(List<string> strategyGuide)
        {
            (int, int) totalPoints = new();
            foreach (var round in strategyGuide)
            {
                switch (round)
                {
                    case "A X":
                        totalPoints.Item1 = totalPoints.Item1 + 4;
                        totalPoints.Item2 = totalPoints.Item2 + 3;
                        continue;
                    case "A Y":
                        totalPoints.Item1 = totalPoints.Item1 + 8;
                        totalPoints.Item2 = totalPoints.Item2 + 4;
                        continue;
                    case "A Z":
                        totalPoints.Item1 = totalPoints.Item1 + 3;
                        totalPoints.Item2 = totalPoints.Item2 + 8;
                        continue;
                    case "B X":
                        totalPoints.Item1 = totalPoints.Item1 + 1;
                        totalPoints.Item2 = totalPoints.Item2 + 1;
                        continue;
                    case "B Y":
                        totalPoints.Item1 = totalPoints.Item1 + 5;
                        totalPoints.Item2 = totalPoints.Item2 + 5;
                        continue;
                    case "B Z":
                        totalPoints.Item1 = totalPoints.Item1 + 9;
                        totalPoints.Item2 = totalPoints.Item2 + 9;
                        continue;
                    case "C X":
                        totalPoints.Item1 = totalPoints.Item1 + 7;
                        totalPoints.Item2 = totalPoints.Item2 + 2;
                        continue;
                    case "C Y":
                        totalPoints.Item1 = totalPoints.Item1 + 2;
                        totalPoints.Item2 = totalPoints.Item2 + 6;
                        continue;
                    case "C Z":
                        totalPoints.Item1 = totalPoints.Item1 + 6;
                        totalPoints.Item2 = totalPoints.Item2 + 7;
                        continue;

                    default:
                        return totalPoints;
                }
            }
            return totalPoints;
        }

        #endregion

    }
}

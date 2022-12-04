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

        #region Day Three
        public static int BackpackProblem(List<string> backpacks)
        {
            var priorityPoints = 0;
            foreach (var backpack in backpacks)
            {
                if(backpack != "")
                {
                    var segment1 = backpack.Substring(0, backpack.Length / 2);
                    var segment2 = backpack.Substring(backpack.Length / 2);
                    foreach (var item in segment1)
                    {
                        if (segment2.Contains(item))
                        {
                            if (item >= 'a' && item <= 'z')
                            {
                                priorityPoints += item - 96;
                            }
                            else
                            {
                                priorityPoints += item - 38;
                            }
                            break;
                        }

                    }
                }


            }


            return priorityPoints;
        }

        public static int BackpackOrganization(List<string> backpacks)
        {
            var priorityPoints = 0;
            for (int i = 0; i < backpacks.Count; i+=3)
            {
                foreach (var item in backpacks[i])
                {
                    if (backpacks[i+1].Contains(item) && backpacks[i + 2].Contains(item))
                    {
                        if (item >= 'a' && item <= 'z')
                        {
                            priorityPoints += item - 96;
                        }
                        else
                        {
                            priorityPoints += item - 38;
                        }
                        break;
                    }
                }
            }

            return priorityPoints;
        }
        #endregion

        #region Day Four
        public static int CleanUp(List<string> assignemnts)
        {
            var completlyUseless = 0;
            foreach (var pair in assignemnts)
            {
                if (pair == "")
                    break;
                var pairSplit = pair.Split(',');
                var firstElf = pairSplit[0].Split('-').ToList();
                var secondElf = pairSplit[1].Split('-').ToList();
                var lowerBoundElf1 = int.Parse(firstElf[0]);
                var upperBoundElf1 = int.Parse(firstElf[1]);
                var lowerBoundElf2 = int.Parse(secondElf[0]);
                var upperBoundElf2 = int.Parse(secondElf[1]);


                if ((lowerBoundElf1 <= lowerBoundElf2 && upperBoundElf1 >= upperBoundElf2) ||(lowerBoundElf2 <= lowerBoundElf1 && upperBoundElf2 >= upperBoundElf1))
                {
                    completlyUseless++;
                }
            }

            return completlyUseless;
        }

        public static int InefficiencyIsTheDeathOfElves(List<string> assignemnts)
        {
            var completlyUseless = 0;
            foreach (var pair in assignemnts)
            {
                if (pair == "")
                    break;
                var pairSplit = pair.Split(',');
                var firstElf = pairSplit[0].Split('-').ToList();
                var secondElf = pairSplit[1].Split('-').ToList();
                var lowerBoundElf1 = int.Parse(firstElf[0]);
                var upperBoundElf1 = int.Parse(firstElf[1]);
                var lowerBoundElf2 = int.Parse(secondElf[0]);
                var upperBoundElf2 = int.Parse(secondElf[1]);


                if(!(lowerBoundElf1>upperBoundElf2 || upperBoundElf1 < lowerBoundElf2))
                {
                    completlyUseless++;
                }


            }

            return completlyUseless;
        }
        #endregion
    }
}

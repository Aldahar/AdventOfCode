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
            var priorityPoints2 = 0;
            foreach (var backpack in backpacks)
            {
                if(backpack != "")
                {
                    var segment1 = backpack.Substring(0, backpack.Length / 2 - 1);
                    var segment2 = backpack.Substring(backpack.Length / 2);

                    foreach (var item in segment1)
                    {
                        if (segment2.Contains(item))
                        {
                            if (item >= 'a' && item <= 'z')
                            {
                                var calculatedValue = item - 96;
                                priorityPoints2 += item - 96;

                                switch (item)
                                {
                                    case 'a':
                                        priorityPoints += 1;
                                        continue;
                                    case 'b':
                                        priorityPoints += 2;
                                        continue;
                                    case 'c':
                                        priorityPoints += 3;
                                        continue;
                                    case 'd':
                                        priorityPoints += 4;
                                        continue;
                                    case 'e':
                                        priorityPoints += 5;
                                        continue;
                                    case 'f':
                                        priorityPoints += 6;
                                        continue;
                                    case 'g':
                                        priorityPoints += 7;
                                        continue;
                                    case 'h':
                                        priorityPoints += 8;
                                        continue;
                                    case 'i':
                                        priorityPoints += 9;
                                        continue;
                                    case 'j':
                                        priorityPoints += 10;
                                        continue;
                                    case 'k':
                                        priorityPoints += 11;
                                        continue;
                                    case 'l':
                                        priorityPoints += 12;
                                        continue;
                                    case 'm':
                                        priorityPoints += 13;
                                        continue;
                                    case 'n':
                                        priorityPoints += 14;
                                        continue;
                                    case 'o':
                                        priorityPoints += 15;
                                        continue;
                                    case 'p':
                                        priorityPoints += 16;
                                        continue;
                                    case 'q':
                                        priorityPoints += 17;
                                        continue;
                                    case 'r':
                                        priorityPoints += 18;
                                        continue;
                                    case 's':
                                        priorityPoints += 19;
                                        continue;
                                    case 't':
                                        priorityPoints += 20;
                                        continue;
                                    case 'u':
                                        priorityPoints += 21;
                                        continue;
                                    case 'v':
                                        priorityPoints += 22;
                                        continue;
                                    case 'w':
                                        priorityPoints += 23;
                                        continue;
                                    case 'x':
                                        priorityPoints += 24;
                                        continue;
                                    case 'y':
                                        priorityPoints += 25;
                                        continue;
                                    case 'z':
                                        priorityPoints += 26;
                                        continue;

                                    default:
                                        break;
                                }
                                //var addedValue = item - 96;
                                //Console.WriteLine("Duplicate is:"+ item + ". The Value is: " + addedValue);
                            }
                            else if(item >= 'A' && item <='Z')
                            {
                                priorityPoints2 += item - 38;
                                var calculatedValue = item - 38;
                                switch (item)
                                {
                                    case 'A':
                                        priorityPoints += 1 + 26;
                                        continue;
                                    case 'B':
                                        priorityPoints += 2 + 26;
                                        continue;
                                    case 'C':
                                        priorityPoints += 3 + 26;
                                        continue;
                                    case 'D':
                                        priorityPoints += 4 + 26;
                                        continue;
                                    case 'E':
                                        priorityPoints += 5 + 26;
                                        continue;
                                    case 'F':
                                        priorityPoints += 6 + 26;
                                        continue;
                                    case 'G':
                                        priorityPoints += 7 + 26;
                                        continue;
                                    case 'H':
                                        priorityPoints += 8 + 26;
                                        continue;
                                    case 'I':
                                        priorityPoints += 9 + 26;
                                        continue;
                                    case 'J':
                                        priorityPoints += 10 + 26;
                                        continue;
                                    case 'K':
                                        priorityPoints += 11 + 26;
                                        continue;
                                    case 'L':
                                        priorityPoints += 12 + 26;
                                        continue;
                                    case 'M':
                                        priorityPoints += 13 + 26;
                                        continue;
                                    case 'N':
                                        priorityPoints += 14 + 26;
                                        continue;
                                    case 'O':
                                        priorityPoints += 15 + 26;
                                        continue;
                                    case 'P':
                                        priorityPoints += 16 + 26;
                                        continue;
                                    case 'Q':
                                        priorityPoints += 17 + 26;
                                        continue;
                                    case 'R':
                                        priorityPoints += 18 + 26;
                                        continue;
                                    case 'S':
                                        priorityPoints += 19 + 26;
                                        continue;
                                    case 'T':
                                        priorityPoints += 20 + 26;
                                        continue;
                                    case 'U':
                                        priorityPoints += 21 + 26;
                                        continue;
                                    case 'V':
                                        priorityPoints += 22 + 26;
                                        continue;
                                    case 'W':
                                        priorityPoints += 23 + 26;
                                        continue;
                                    case 'X':
                                        priorityPoints += 24 + 26;
                                        continue;
                                    case 'Y':
                                        priorityPoints += 25 + 26;
                                        continue;
                                    case 'Z':
                                        priorityPoints += 26 + 26;
                                        continue;

                                    default:
                                        break;
                                }
                                //var addedValue = item - 38;
                                //Console.WriteLine("Duplicate is:" + item + ". The Value is: " + addedValue);
                            }
                            else
                            {
                                Console.WriteLine("How did we get here?");
                            }
                            break;
                        }
                    }
                }


            }


            return priorityPoints;
        }
        #endregion

    }
}

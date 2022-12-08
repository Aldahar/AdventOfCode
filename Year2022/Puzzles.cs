using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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

        #region Day Five

        public static string SupplyStacks(List<string> allInfos, bool crateMaster9001 = false)
        {
            var stacks = new List<string>();
            List<List<string>> movements = new();

            List<List<string>> crates = new();

            foreach (var row in allInfos) //Find all the Lines that create the containers
            {
                if (row[1] == '1')
                {
                    break;
                }
                stacks.Add(row);
            }
            for (int j = 1; j < stacks[0].Count() - 1; j += 4)
            {
                var currentColumn = new List<string>();
                for (int i = stacks.Count -1; i >= 0; i--)  //Create the Containersetup
                {
                    if (stacks[i][j] + "" == " ")
                    {
                        break;
                    }
                    var sign = stacks[i][j] + "";
                    currentColumn.Add(sign);




                }
                crates.Add(currentColumn);
            }   


            foreach (var move in allInfos)  //Find all the lines that show the movements
            {
                if(move == "")
                {
                    continue;
                }
                if (move[0] == 'm')
                {
                    var workString = Regex.Replace(move, "[a-z]", "");
                    var list = workString.Split(" ").ToList();
                    list.RemoveAll(row => row == "");
                    movements.Add(list);

                }
            }

            foreach (var move in movements)
            {
                if (crateMaster9001)
                {
                    CrateMover9001(crates, int.Parse(move[0]), int.Parse(move[1]), int.Parse(move[2]));
                }
                else
                {
                    Move(crates, int.Parse(move[0]), int.Parse(move[1]), int.Parse(move[2]));
                }
                


            }

            var result = "";
            foreach (var stack in crates)
            {

                result += stack[stack.Count - 1];
            }
            return result;
        }

 

        private static List<List<string>> Move(List<List<string>> container, int count, int from, int to)
        {
            for (int i = 0; i < count; i++)
            {
                
                container[to-1].Add(container[from-1][container[from-1].Count() - 1]);
                container[from-1].RemoveAt(container[from-1].Count() - 1);
                
            }
            return container;
        }

        private static List<List<string>> CrateMover9001(List<List<string>> container, int count, int from, int to)
        {
            var movedContainers = container[from - 1].GetRange(container[from - 1].Count() - count, count);
            container[from - 1].RemoveRange(container[from - 1].Count() - count, count);
            container[to - 1].AddRange(movedContainers);

            return container;
        }
        #endregion

        #region Day Six
        public static int BrokenCommDevice(List<string> recieved, int keyLength = 4)
        {
            var noise = recieved[0];
            string currentValue = "";

            for (int i = 0; i < noise.Length-1; i++)
            {
                if (currentValue.Length == keyLength)
                    return i;

                if (currentValue.Contains(noise[i]))
                {
                    var lastOccurence = currentValue.IndexOf(noise[i]);
                    currentValue = currentValue.Substring(lastOccurence + 1);
                    currentValue += noise[i];
                }
                else
                {
                    currentValue += noise[i];
                }
            }
            return 0;
        }

        #endregion

        #region Day Seven

        private static List<TreeNode> BuildTree(List<string> cmdInput)
        {
            TreeNode FirstNode = new()
            {
                Name = "Top",

            };
            FirstNode.Childs.Add(new()
            {
                Name = "/"
            });
            List<TreeNode> totalList = new();
            TreeNode currentNode = new();
            currentNode = FirstNode;
            totalList.Add(currentNode.Childs[0]); //add Root to Return list

            foreach (var command in cmdInput)
            {
                var parts = command.Split(' ');
                if (parts[0] == "a")
                {
                    break;
                }
                if (parts[0] == "$") // if the input is a command. Possible commands are cd and ls
                {
                    if (parts[1] == "cd") //wenn dir dann set current directory
                    {
                        if (parts[2] == "..") //Backstep
                        {
                            currentNode = currentNode.Parent;
                        }
                        else
                        {
                            currentNode = currentNode.Childs.First(row => row.Name == parts[2]);
                        }
                    }
                    if (parts[1] == "ls") // wenn ls dann wird bis zum nächsten $ alles angezeigt was in dem ordner drin ist
                    {
                        //dont even need this
                    }


                }
                else
                {
                    int value = 0;
                    if (int.TryParse(parts[0], out value))
                    {
                        currentNode.Value += value;
                    }
                    else
                    {
                        TreeNode newNode = new() { Name = parts[1], Parent = currentNode };
                        totalList.Add(newNode);
                        currentNode.Childs.Add(newNode);
                    }
                }
            }
            return totalList;
        }
        public static int FindSpace(List<string> cmdInput)
        {
            var totalList = BuildTree(cmdInput);
            
            var totalVal = 0;
            foreach (var node in totalList)
            {
                if (node.TotalValue <= 100000)
                {
                    totalVal += node.TotalValue;
                }
            }

            return totalVal;
        }
        public static int DeleteBestFit(List<string> cmdInput)
        {
            var totalList = BuildTree(cmdInput);
            var neededFit = 30000000 - (70000000 - totalList[0].TotalValue);
            var currentBestFit = totalList[0];
            foreach (var node in totalList)
            {
                if ((currentBestFit.TotalValue >= node.TotalValue) && (node.TotalValue >= neededFit))
                {
                    currentBestFit = node;
                }
            }
            return currentBestFit.TotalValue;

        }


        #endregion
    }

    public class TreeNode
    {
        public string Name { get; set; } = "";
        public int Value { get; set; } = 0; // Value of Datafiles

        public TreeNode? Parent { get; set; }

        public List<TreeNode> Childs { get; set; }
        public int TotalValue //Total value, all datafiles + subdirectorys
        {
            get
            {
                int addedValue = 0;
                foreach (var node in Childs)
                {
                    addedValue += node.TotalValue;
                }
                return addedValue + Value;
            }
        }

        public TreeNode()
    {
            Childs = new();
    }
        public TreeNode(TreeNode parent)
        {
            this.Parent = parent;
            Childs = new();
        }

    }
}

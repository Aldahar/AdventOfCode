using AdventOfCode.Year2022;
var input = "a";
List<string> inputList = new();


do
{
    input = Console.ReadLine();
    inputList.Add(input);
} while (input != "");




    var output = Puzzles.RockPaperScissors(inputList);
var output1 = Puzzles.RockPaperScissorsAfterTheElfStoppedTrolling(inputList);
var output2 = Puzzles.RockPaperScissorsBestSolution(inputList);
Console.WriteLine("Es sind  "+output + " Punkte");
Console.WriteLine();

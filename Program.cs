using AdventOfCode.Year2022;
var input = "a";
List<string> inputList = new();


do
{
    input = Console.ReadLine();
    inputList.Add(input);
} while (input != "");




    var output = Puzzles.InefficiencyIsTheDeathOfElves(inputList);

Console.WriteLine("Es sind  "+output + " Punkte");
Console.WriteLine();

using AdventOfCode.Year2022;
var input = "";
List<string> inputList = new();


while (input != "8805")
{
    input = Console.ReadLine();
    inputList.Add(input);
}


var output = FirstDay.TopThreeCalories(inputList);
Console.WriteLine("Der Elf mit den meisten Kalorien hat "+output);

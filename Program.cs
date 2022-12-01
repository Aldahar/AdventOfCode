using AdventOfCode.Year2021;
var input = "";
List<int> depths = new List<int>();

while (input != "9548")
{
    input = Console.ReadLine();
    depths.Add(Int32.Parse(input));
} 

var  depthCounter = FirstDayOfChristmas.BetterSonar(depths);
Console.WriteLine(depthCounter);
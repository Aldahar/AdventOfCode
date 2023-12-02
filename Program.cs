using AdventOfCode.Year2022;
using AdventOfCode.Year2023;
using AdventOfCode2023;


#region 2022
//var input = "a";
//List<string> inputList = new();


//do
//{
//    input = Console.ReadLine();
//    inputList.Add(input);
//} while (input != "a");

//#region Day1
//var calories = Puzzles.Calories(inputList);

//#endregion

#endregion


#region 2023

var lines = File.ReadAllLines("..\\..\\..\\InputFiles\\test.txt").ToList();

#region FirstDay

var d1p2 = FirstDayOfChristmas.CalculateCalibration(lines);
var d1p1 = FirstDayOfChristmas.CalculateCalibrationWords(lines);
#endregion

#region SecondDay
var d2p1 = SecondDayOfChristmas.CubeGame(lines, 12, 13, 14);
var d2p2 = SecondDayOfChristmas.ThePowerOfTheCubes(lines);
#endregion


#endregion




Console.WriteLine(d2p2);



//var output = Puzzles.DeleteBestFit(inputList);

//Console.WriteLine("Es sind  "+output + " Punkte");
//Console.WriteLine();

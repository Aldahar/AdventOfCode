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

var lines = File.ReadAllLines("..\\..\\..\\InputFiles\\FifthDay2023.txt").ToList();

#region FirstDay

//var d1p2 = FirstDayOfChristmas.CalculateCalibration(lines);
//var d1p1 = FirstDayOfChristmas.CalculateCalibrationWords(lines);
#endregion

#region SecondDay
//var d2p1 = SecondDayOfChristmas.CubeGame(lines, 12, 13, 14);
//var d2p2 = SecondDayOfChristmas.ThePowerOfTheCubes(lines);
#endregion

#region ThirdDay
//var d3p1= ThirdDayOfChristmas.CheckEngine(lines);
//var d3p2 = ThirdDayOfChristmas.FindGearRatios(lines);
#endregion

#region FourthDay
//var d4p1 = FourthDayOfChristmas.CheckWinnings(lines);
//var d4p2 = FourthDayOfChristmas.TotalScratchCards(lines);

#endregion

#region FifthDay

var d5p1 = FifthDayOfChristmas.CalculateSeedPosition(lines);

#endregion


#endregion




Console.WriteLine(d5p1);



//var output = Puzzles.DeleteBestFit(inputList);

//Console.WriteLine("Es sind  "+output + " Punkte");
//Console.WriteLine();

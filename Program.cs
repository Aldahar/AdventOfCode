using AdventOfCode.Year2022;
using AdventOfCode.Year2023;
using AdventOfCode.Year2024;
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

//var lines = File.ReadAllLines("..\\..\\..\\InputFiles\\NinthDay.txt").ToList();

var lines = File.ReadAllLines("..\\..\\..\\InputFiles\\test.txt").ToList();

//#region FirstDay

////var d1p2 = FirstDayOfChristmas.CalculateCalibration(lines);
////var d1p1 = FirstDayOfChristmas.CalculateCalibrationWords(lines);
//#endregion

//#region SecondDay
////var d2p1 = SecondDayOfChristmas.CubeGame(lines, 12, 13, 14);
////var d2p2 = SecondDayOfChristmas.ThePowerOfTheCubes(lines);
//#endregion

//#region ThirdDay
////var d3p1= ThirdDayOfChristmas.CheckEngine(lines);
////var d3p2 = ThirdDayOfChristmas.FindGearRatios(lines);
//#endregion

//#region FourthDay
////var d4p1 = FourthDayOfChristmas.CheckWinnings(lines);
////var d4p2 = FourthDayOfChristmas.TotalScratchCards(lines);

//#endregion

//#region FifthDay

////var d5p1 = FifthDayOfChristmas.CalculateSeedPosition(lines);
////var line = File.ReadAllText("..\\..\\..\\InputFiles\\FifthDay2023.txt");
////var d5p2 = FifthDayOfChristmas.SeedRanges(line);
////var day = new Day05(line);
////var result = day.Part2();

//#endregion

//#region SixthDay

////var d6p1 = SixthDayOfChrismas.BoatRace(lines);
////var d6p2 = SixthDayOfChrismas.LongBoatRace(lines);

//#endregion

//#region SeventhDay

////var d7p1 = SeventhDayOfChristmas.CamelCardWinnings(lines);
//#endregion

//#region EightDay
////var d8p1 = EigthDayOfChristmas.ReadTheMap(lines);
////var d8p2 = EigthDayOfChristmas.GhostSteps(lines);
//#endregion

//#region NinthDay

////var d9p1 = NinthDayOfChristmas.ExtrapolateTheEnvironment(lines);
////var d9p2 = NinthDayOfChristmas.ExtrapolateThePast(lines);

//#endregion

//#region TenthDay

////var ten = new TenthDayOfChristmas(lines);


////var d10p1 = ten.FindEndpoint();


//#endregion

//#region EleventhDay
//var eleven = EleventhDayOfChristmas.FindGalaxies(lines);

//#endregion


#endregion

#region 2024

var testLines = File.ReadAllLines("..\\..\\..\\InputFiles\\test.txt").ToList();
var lines2024 = File.ReadAllLines("..\\..\\..\\InputFiles\\FourthDay2024.txt").ToList();

#region Day1
//var output = AdventOfCode.Year2024.FirstDayOfChristmas.ListCompare(lines2024);
//var simScore = AdventOfCode.Year2024.FirstDayOfChristmas.SimilarityScore(lines2024);
#endregion

#region Day2
//var saftyRecord = AdventOfCode.Year2024.SecondDayOfChristmas.SafetyishCheck(lines2024);

#endregion

#region Day3
//var result = AdventOfCode.Year2024.ThirdDayOfChristmas.MemoryCorruptorDo(lines2024);

#endregion

#region Day4
var result = AdventOfCode.Year2024.FourthDayOfChristmas.XCrossMAS(lines2024);

#endregion

#endregion



Console.WriteLine(result);



//var output = Puzzles.DeleteBestFit(inputList);

//Console.WriteLine("Es sind  "+output + " Punkte");
//Console.WriteLine();

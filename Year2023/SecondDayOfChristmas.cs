using System;
using System.Linq;
using System.Text.RegularExpressions;
namespace AdventOfCode.Year2023
{

	public class SecondDayOfChristmas
	{
		public static int CubeGame(List<string> lines, int red, int green, int blue)
		{
			var totalInvalid = 0;
			var totalValid = 0;
			foreach (var line in lines)
			{
				var game = line.Split(':').First();


                var show = line.Split(':').Last();
				var showings = show.Split(";").ToList();
				var valid = true;

				foreach (var showing in showings)
				{
					var cubesShown = showing.Split(",").ToList();
					foreach (var cube in cubesShown)
					{
						var redShown = 0;
                        var blueShown = 0;
                        var greenShown = 0;
                        if (cube.Contains("red"))
						{
                            redShown = int.Parse(Regex.Replace(cube, "[^0-9.]", ""));
							if (redShown > red)
							{
								valid = false;
								break;
							}
                        }
						else if (cube.Contains("green"))
						{
                            greenShown = int.Parse(Regex.Replace(cube, "[^0-9.]", ""));
                            if (greenShown > green)
                            {
                                valid = false;
                                break;
                            }
                        }
						else if (cube.Contains("blue"))
						{
                            blueShown = int.Parse(Regex.Replace(cube, "[^0-9.]", ""));
                            if (blueShown > blue)
                            {
                                valid = false;
                                break;
                            }
                        }





					}
					
				}
                if (!valid)
                {
                    totalInvalid += int.Parse(Regex.Replace(game, "[^0-9.]", ""));
                    

                }
                else
                {
                    totalValid += int.Parse(Regex.Replace(game, "[^0-9.]", ""));
                    
                }


            }


			return totalValid;

		}


		public static int ThePowerOfTheCubes(List<string> lines)
		{
			var power = 0;
            foreach (var line in lines)
            {
                var redMax = 0;
                var greenMax = 0;
                var blueMax = 0;
                var game = line.Split(':').First();


                var show = line.Split(':').Last();
                var showings = show.Split(";").ToList();
                var valid = true;

                foreach (var showing in showings)
                {


                    var cubesShown = showing.Split(",").ToList();
                    foreach (var cube in cubesShown)
                    {
                        var redShown = 0;
                        var blueShown = 0;
                        var greenShown = 0;
                        if (cube.Contains("red"))
                        {
                            redShown = int.Parse(Regex.Replace(cube, "[^0-9.]", ""));
                            if (redShown > redMax)
                            {
                                redMax = redShown;
                            }
                        }
                        else if (cube.Contains("green"))
                        {
                            greenShown = int.Parse(Regex.Replace(cube, "[^0-9.]", ""));
                            if (greenShown > greenMax)
                            {
                                greenMax = greenShown;
                            }
                        }
                        else if (cube.Contains("blue"))
                        {
                            blueShown = int.Parse(Regex.Replace(cube, "[^0-9.]", ""));
                            if (blueShown > blueMax)
                            {
                                blueMax = blueShown;
                                
                            }
                        }





                    }

                }
                power += redMax * greenMax * blueMax;


            }

            return power;
		}
	}
}

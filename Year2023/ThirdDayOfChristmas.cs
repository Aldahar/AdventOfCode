using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2023
{
    public class ThirdDayOfChristmas
    {
        public static int CheckEngine(List<string> lines)
        {
            int sum = 0;


            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (!char.IsDigit(lines[i][j]) && lines[i][j] != '.')
                    {

                       sum += CheckSurroundings(lines, j, i);




                    }
                }


            }






            return sum;
        }

        public static int FindGearRatios(List<string> lines)
        {
            int sum = 0;


            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '*')
                    {

                        sum += CheckSurroundings(lines, j, i,true);




                    }
                }


            }
            return sum;
        }



        private static int CheckSurroundings(List<string> lines, int locationX, int locationY, bool part2 = false)
        {
            var sum = 0;
            List<int> numberSurroundingSign = new();
            for (int i = locationY - 1; i <= locationY + 1; i++)
            {

                for (int j = locationX - 1 <= 0 ? 0 : locationX - 1; j <= (locationX + 1 >=lines[0].Length ? lines[0].Length : locationX + 1); j++)
                {
                    if (char.IsDigit(lines[i][j]))
                    {


                       numberSurroundingSign.Add(FindFullNumber(lines, j, i));



                    }


                }

            }
            if (part2)
            {
                if (numberSurroundingSign.Count == 2)
                    return numberSurroundingSign[0] * numberSurroundingSign[1];
                
                return 0;
            }
            return numberSurroundingSign.Sum();

        }

        private static int FindFullNumber(List<string> lines, int X, int Y)
        {
            var initialX = X;
            var initialY = Y;
            string number = "";

            while (X != 0 && char.IsDigit(lines[Y][X - 1]))
            {
                X = X - 1;

            }

            while (X != lines[0].Length && char.IsDigit(lines[Y][X]))
            {
                
                number+= lines[Y][X];
                var line = lines[Y].ToCharArray();
                line[X] = '.';
                lines[Y] = new (line);
                X++;
            }

            return int.Parse(number);

        }

    }






}

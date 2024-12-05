using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public class SecondDayOfChristmas
    {
        public static int SafetyCheck(List<string> input)
        {
            int CorrectSafetyReport = 0;
            List<List<int>> readings = new List<List<int>>();
            foreach (string s in input)
            {

                var list = s.Split(' ').ToList().ConvertAll(row => Int32.Parse(row));
                readings.Add(list);
            }

            foreach (var reading in readings)
            {
                int prev = reading[0];
                bool error = false;
                bool falling = prev > reading[1];
                for (int i = 1; i < reading.Count; i++)
                {
                    if (prev == reading[i])
                    {
                        error = true; break;
                    }




                    if (falling && prev < reading[i])
                    {
                        error = true; break;
                    }
                    if (!falling && prev > reading[i])
                    {
                        error = true; break;
                    }
                    if (Math.Abs(prev - reading[i]) > 3)
                    {
                        error = true; break;
                    }
                    prev = reading[i];

                }
                if (error == false)
                {
                    CorrectSafetyReport++;
                }

            }
            return CorrectSafetyReport;

        }

        public static int SafetyishCheck(List<string> input)
        {
            int CorrectSafetyReport = 0;
            List<List<int>> readings = new List<List<int>>();
            foreach (string s in input)
            {

                var list = s.Split(' ').ToList().ConvertAll(row => Int32.Parse(row));
                readings.Add(list);
            }

            foreach (var reading in readings)
            {
                if (CalculateLine(reading))
                {
                    CorrectSafetyReport++;
                    continue;
                }
                for (int i = 0; i < reading.Count; i++)
                {
                    var temp = reading.Where((v,j)=>j!=i).ToList();
                        //temp.RemoveRange(i, 1);

                    if (CalculateLine(temp))
                    {
                        CorrectSafetyReport++;
                        break;
                    }
                }

            }
            return CorrectSafetyReport;

        }


        private static bool CalculateLine(List<int> line)
        {
            int prev = line[0];
            bool error = false;
            bool falling = prev > line[1];

            for (int i = 1; i < line.Count; i++)
            {
                if (prev == line[i])
                {
                    error = true; break;
                }




                if (falling && prev < line[i])
                {
                    error = true; break;
                }
                if (!falling && prev > line[i])
                {
                    error = true; break;
                }
                if (Math.Abs(prev - line[i]) > 3)
                {
                    error = true; break;
                }
                prev = line[i];

            }
            if (error == false)
            {
                return true;
            }
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2023
{
    public class SixthDayOfChrismas
    {
        public static int BoatRace(List<string> lines)
        {
            var times = lines[0].Split(':', StringSplitOptions.RemoveEmptyEntries)[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(row => int.Parse(row)).ToList();
            var distance = lines[1].Split(':', StringSplitOptions.RemoveEmptyEntries)[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(row => int.Parse(row)).ToList();
            var result = 1;

            for (int i = 0; i < times.Count; i++)
            {
                int waysToBeatRecord = 0;
                for (int j = 0; j <= times[i]; j++)
                {

                    var calculateDistance = j * (times[i] - j);
                    if (calculateDistance > distance[i])
                    {
                        waysToBeatRecord++;
                    }


                }

                result *= waysToBeatRecord;
            }


            return result;
        }


        public static long LongBoatRace(List<string> lines)
        {
            var times = long.Parse(lines[0].Split(':')[1].Replace(" ",""));
            var distance = long.Parse(lines[1].Split(':')[1].Replace(" ",""));


            int waysToBeatRecord = 0;
            for (int j = 0; j <= times; j++)
            {

                var calculateDistance = j*(times-j);
                if (calculateDistance > distance)
                {
                    waysToBeatRecord++;
                }






            }


            return waysToBeatRecord;
        }
    }
}

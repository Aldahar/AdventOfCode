using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2023
{
    public class FourthDayOfChristmas
    {
        public static int CheckWinnings(List<string> lines)
        {
            int totalWinnings = 0;

            foreach (string line in lines)
            {
                var lineWinnings = 0;
                var winnings = line.Split(':')[1].Split('|')[0].Trim().Split(' ').Where(row => !String.IsNullOrWhiteSpace(row)).ToList();
                var numbers = line.Split(':')[1].Split('|')[1].Trim().Split(' ').Where(row => !String.IsNullOrWhiteSpace(row)).ToList();

                foreach (var number in numbers)
                {

                    if (winnings.Contains(number))
                    {
                        lineWinnings = lineWinnings == 0 ? 1 : lineWinnings * 2;
                    }


                }

                totalWinnings += lineWinnings;


            }
            return totalWinnings;
        }


        public static int TotalScratchCards(List<string> lines)
        {
            int totalCount = 0;
            int[] duplications = new int[lines.Count];
            for (int i = 0; i < duplications.Length; i++)
            {
                duplications[i] = 1;
            }

            for (int i = 0; i < lines.Count; i++)
            {
                var winnings = lines[i].Split(':')[1].Split('|')[0].Trim().Split(' ').Where(row => !String.IsNullOrWhiteSpace(row)).ToList();
                var numbers = lines[i].Split(':')[1].Split('|')[1].Trim().Split(' ').Where(row => !String.IsNullOrWhiteSpace(row)).ToList();
                int localDuplications = 0;

                foreach (var number in numbers)
                {
                    
                    if (winnings.Contains(number))
                    {
                        localDuplications++;
                        
                    }


                }
                for (int j = i+1; j <= (i+localDuplications > lines.Count ? lines.Count : i + localDuplications); j++)
                {
                    
                    duplications[j] += duplications[i];
                }


            }


            totalCount = duplications.Sum();
            return totalCount;
        }



    }
}

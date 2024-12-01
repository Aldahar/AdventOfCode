using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2023
{
    public class SeventhDayOfChristmas
    {
        static readonly List<char> orderList = new List<char>()
        {
            'A', 'K','Q','J','T','9','8','7','6','5','4','3','2'
        };
        static readonly List<char> orderListJoker = new List<char>()
        {
            'A', 'K','Q','T','9','8','7','6','5','4','3','2','J'
        };
        public static long CamelCardWinnings(List<string> lines)
        {
            long totalWinnings = 0;

            var five = new List<Tuple<string, int>>();
            var four = new List<Tuple<string, int>>();
            var fullhouse = new List<Tuple<string, int>>();
            var three = new List<Tuple<string, int>>();
            var twoPairs = new List<Tuple<string, int>>();
            var two = new List<Tuple<string, int>>();
            var highcard = new List<Tuple<string, int>>();

            foreach (var line in lines)
            {
                var hand = line.Split(' ')[0];
                var bid = int.Parse( line.Split(" ")[1]);

                var maxOccurance = hand.GroupBy(row => row).OrderByDescending(row => row.Count()).ToList();

                switch (maxOccurance.First().Count())
                {
                    case 1:
                        highcard.Add(new(hand,bid));
                        highcard.Sort();
                        continue;

                    case 2:
                        if (maxOccurance[1].Count() != 2)
                        {
                            two.Add(new(hand, bid));
                            two.Sort();
                        }
                        else
                        {
                            twoPairs.Add(new(hand, bid));
                            twoPairs.Sort();
                        }
                        continue;

                    case 3:
                        if (maxOccurance[1].Count() != 2)
                        {
                            three.Add(new(hand,bid));
                            three.Sort();
                        }
                        else
                        {
                            fullhouse.Add(new(hand,bid));
                            fullhouse.Sort();
                        }
                        continue;

                        case 4:
                        four.Add(new(hand,bid));
                        four.Sort();
                        continue;

                        case 5:
                        five.Add(new(hand,bid));
                        
                        continue;
                        
                }


            }

            five = five.OrderBy(row => orderList.IndexOf(row.Item1[0])).ThenBy(row => orderList.IndexOf(row.Item1[1])).ThenBy(row => orderList.IndexOf(row.Item1[2])).ThenBy(row => orderList.IndexOf(row.Item1[3])).ThenBy(row => orderList.IndexOf(row.Item1[4])).ToList();
            four = four.OrderBy(row => orderList.IndexOf(row.Item1[0])).ThenBy(row => orderList.IndexOf(row.Item1[1])).ThenBy(row => orderList.IndexOf(row.Item1[2])).ThenBy(row => orderList.IndexOf(row.Item1[3])).ThenBy(row => orderList.IndexOf(row.Item1[4])).ToList();
            three = three.OrderBy(row => orderList.IndexOf(row.Item1[0])).ThenBy(row => orderList.IndexOf(row.Item1[1])).ThenBy(row => orderList.IndexOf(row.Item1[2])).ThenBy(row => orderList.IndexOf(row.Item1[3])).ThenBy(row => orderList.IndexOf(row.Item1[4])).ToList();
            fullhouse = fullhouse.OrderBy(row => orderList.IndexOf(row.Item1[0])).ThenBy(row => orderList.IndexOf(row.Item1[1])).ThenBy(row => orderList.IndexOf(row.Item1[2])).ThenBy(row => orderList.IndexOf(row.Item1[3])).ThenBy(row => orderList.IndexOf(row.Item1[4])).ToList();
            two = two.OrderBy(row => orderList.IndexOf(row.Item1[0])).ThenBy(row => orderList.IndexOf(row.Item1[1])).ThenBy(row => orderList.IndexOf(row.Item1[2])).ThenBy(row => orderList.IndexOf(row.Item1[3])).ThenBy(row => orderList.IndexOf(row.Item1[4])).ToList();
            twoPairs = twoPairs.OrderBy(row => orderList.IndexOf(row.Item1[0])).ThenBy(row => orderList.IndexOf(row.Item1[1])).ThenBy(row => orderList.IndexOf(row.Item1[2])).ThenBy(row => orderList.IndexOf(row.Item1[3])).ThenBy(row => orderList.IndexOf(row.Item1[4])).ToList();
            highcard = highcard.OrderBy(row => orderList.IndexOf(row.Item1[0])).ThenBy(row => orderList.IndexOf(row.Item1[1])).ThenBy(row => orderList.IndexOf(row.Item1[2])).ThenBy(row => orderList.IndexOf(row.Item1[3])).ThenBy(row => orderList.IndexOf(row.Item1[4])).ToList();


            int mult = lines.Count;

            foreach (var draw in five)
            {
                totalWinnings += draw.Item2* mult;
                mult--;
            }
            foreach (var draw in four)
            {
                totalWinnings += draw.Item2 * mult;
                mult--;
            }
            foreach (var draw in fullhouse)
            {
                totalWinnings += draw.Item2 * mult;
                mult--;
            }
            foreach (var draw in three)
            {
                totalWinnings += draw.Item2 * mult;
                mult--;
            }
            foreach (var draw in twoPairs)
            {
                totalWinnings += draw.Item2 * mult;
                mult--;
            }
            foreach (var draw in two)
            {
                totalWinnings += draw.Item2 * mult;
                mult--;
            }
            foreach (var draw in highcard)
            {
                totalWinnings += draw.Item2 * mult;
                mult--;
            }






            return totalWinnings;

        }

    }
}

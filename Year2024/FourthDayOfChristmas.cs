using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public class FourthDayOfChristmas
    {
        // input[Y][X]
        public static int Crossword(List<string> input)
        {
            int occurence = 0;
            Regex xmas = new(@"(?=XMAS|SAMX)");
            foreach (string line in input)
            {
                occurence += xmas.Matches(line).Count; 
            }
            for (int i = 0; i < input.Count; i++) {
                StringBuilder sb = new();
                input.ForEach(row => sb.Append(row[i]));
                occurence += xmas.Matches(sb.ToString()).Count;

            }
            for(int i = 0; i<input.Count; i++)  // Scans this direction     \
            {                                   //                          \
                int y = i;                      //                          \
                int x = 0;
                StringBuilder sb = new();
                while (x != input[0].Length - i)
                {

                    sb.Append(input[y][x]);
                    y++;
                    x++;
                }
                Console.WriteLine(sb.ToString());
                occurence += xmas.Matches(sb.ToString()).Count;
            }
            Console.WriteLine();
            for (int i = 1; i < input[0].Length; i++) //Scans this direction \\\\
            {
                int y = 0;
                int x = i;
                StringBuilder sb = new();
                while (y != input.Count() - i)
                {

                    sb.Append(input[y][x]);
                    y++;
                    x++;
                    
                }
                Console.WriteLine(sb.ToString());
                occurence += xmas.Matches(sb.ToString()).Count;
            }
            Console.WriteLine();
            for (int i = input.Count-1; i >= 0; i--) // Scans in this direction     /
            {                                           //                          /
                int y = i;                              //                          /
                int x = 0;
                StringBuilder sb = new();
                while (y>=0)
                {

                    sb.Append(input[y][x]);
                    y--;
                    x++;
                }
                Console.WriteLine(sb.ToString());
                var a = xmas.Matches(sb.ToString());
                occurence += xmas.Matches(sb.ToString()).Count;
            }
            Console.WriteLine();


            for (int i = 1; i <= input[0].Length; i++) // Scans in this direction     ////
            {
                int y = input.Count-1;
                int x = i;
                StringBuilder sb = new();
                while (x < input[0].Length)
                {

                    sb.Append(input[y][x]);
                    y--;
                    x++;
                }
                Console.WriteLine(sb.ToString());
                occurence += xmas.Matches(sb.ToString()).Count;
            }

            return occurence;
        }

        public static int XCrossMAS(List<string> input)
        {
            int occurence = 0;
            List<(int,int)> ListOfAs = new();
            Regex xmas = new(@"(?=MAS|SAM)");

            for (int i = 0; i < input.Count; i++)  // Scans this direction     \
            {                                   //                          \
                int y = i;                      //                          \
                int x = 0;
                StringBuilder sb = new();
                while (x != input[0].Length - i)
                {

                    sb.Append(input[y][x]);
                    y++;
                    x++;
                }
                Console.WriteLine(sb.ToString());
                
                var matchList = xmas.Matches(sb.ToString());
                foreach (Match match in matchList)
                {
                    var a = match.Index;
                    ListOfAs.Add((i + match.Index+1, match.Index + 1));
                }
            }
            Console.WriteLine();
            for (int i = 1; i < input[0].Length; i++) //Scans this direction \\\\
            {
                int y = 0;
                int x = i;
                StringBuilder sb = new();
                while (y != input.Count() - i)
                {

                    sb.Append(input[y][x]);
                    y++;
                    x++;

                }
                Console.WriteLine(sb.ToString());
                var matchList = xmas.Matches(sb.ToString());
                foreach (Match match in matchList)
                {
                    ListOfAs.Add((match.Index + 1, i + match.Index + 1));
                }
            }
            Console.WriteLine();
            for (int i = input.Count - 1; i >= 0; i--) // Scans in this direction     /
            {                                           //                          /
                int y = i;                              //                          /
                int x = 0;
                StringBuilder sb = new();
                while (y >= 0)
                {

                    sb.Append(input[y][x]);
                    y--;
                    x++;
                }
                Console.WriteLine(sb.ToString());
                var matchList = xmas.Matches(sb.ToString());
                foreach (Match match in matchList)
                {

            if (ListOfAs.Contains((i - match.Index - 1, match.Index + 1)))
                    {
                occurence++;
            }
                    ListOfAs.Add((i - match.Index - 1, match.Index+1));
                    var a = input[ListOfAs.Last().Item1][ListOfAs.Last().Item2];
                    var b = ListOfAs.Last();

                }
            }
            Console.WriteLine();


            for (int i = 1; i <= input[0].Length; i++) // Scans in this direction     ////
            {
                int y = input.Count - 1;
                int x = i;
                StringBuilder sb = new();
                while (x < input[0].Length)
                {

                    sb.Append(input[y][x]);
                    y--;
                    x++;
                }
                Console.WriteLine(sb.ToString());
                var matchList = xmas.Matches(sb.ToString());
                foreach (Match match in matchList)
                {

                    if (ListOfAs.Contains((input[0].Length - match.Index - 2, i + match.Index + 1)))
                    {
                        occurence++;
                    }
                    ListOfAs.Add((input[0].Length - match.Index - 2, i + match.Index + 1));
                    var a = input[ListOfAs.Last().Item1][ListOfAs.Last().Item2];
                }
            }

            foreach (var item in ListOfAs)
            {
                Console.WriteLine(input[item.Item1][item.Item2]);
            }




            return occurence;
        }

        //public static bool CheckSurrounding(int x,int y)
        //{
        //    int startX = x == 0 ? 0 : x - 1;
        //    int startY = y == 0 ? 0 : y - 1;
        //    for (int i = x-1; i<= x+1
        //}
        
        

    }
}

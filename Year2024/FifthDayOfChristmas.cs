using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public class FifthDayOfChristmas
    {
        public static (int,int) SafetyManual(List<string> Lines)
        {
            int middlePageNumbers = 0;
            int missprintMiddleNumbers = 0;
            List<(int,int)> DaRULEZ = new();
            List<List<int>> DaPrintJob = new();
            //List<List<int>> missprints = new();
            foreach (var line in Lines)
            {
                if (line.Contains('|')) // is Rule
                {
                    var rule = line.Split('|');
                    DaRULEZ.Add((int.Parse(rule[0]), int.Parse(rule[1])));
                }
                else if (line.Contains(','))
                {
                    var printJob = line.Split(",").ToList().ConvertAll(row=>int.Parse(row));
                    DaPrintJob.Add(printJob);

                }
            }

            foreach (var printJob in DaPrintJob)
            {
                var currentRulez = DaRULEZ.Where(row => printJob.Contains(row.Item1) && printJob.Contains(row.Item2)).ToList();
                var missprint = false;
                for (int i = 0; i < printJob.Count; i++)
                {
                    var prevListe = new List<int>();
                    var afterListe = new List<int>();
                    //printJob.Where(row => currentRulez.Contains(row2 => row2.Item2 == row));
                    for (int j = 0; j < i; j++) // check if previous entries obey rules
                    {
                        var a = currentRulez.Where(row => row == (printJob[i], printJob[j])).ToList();
                        missprint = !missprint ? currentRulez.Where(row => row == (printJob[i], printJob[j])).Count()>0 : true;
                    }
                    for (int k = i+1; k < printJob.Count; k++) // check if later entries obey rules
                    {
                        var a = currentRulez.Where(row => row == (printJob[k], printJob[i])).ToList();
                        missprint = !missprint ? currentRulez.Where(row => row == (printJob[k], printJob[i])).Count() > 0 : true;
                    }

                    if (missprint)
                    {
                        break;
                    }
                }
                if (!missprint)
                {
                    middlePageNumbers += printJob[(int)Math.Round(printJob.Count / 2.0, MidpointRounding.ToZero)];
                }
                else
                {
                    missprintMiddleNumbers += MissprintFixing(printJob, currentRulez);
                }

            }
           



            return (middlePageNumbers,missprintMiddleNumbers);
        }


        public static int MissprintFixing(List<int> printjob, List<(int,int)> rules)
        {
            var middlePage = 0;
            List<int> fixedPrintJob = new();

            while(rules.Count > 0)
            {
                var topology = rules.GroupBy(row => row.Item2).ToList(); // groupBy shows which number has no connections

                 var noEdges =   printjob.First(row => !topology.Any(row2 => row2.Key == row)); // find out which number has no connections and add it to the right of the fixed list
                fixedPrintJob.Add(noEdges);

                rules = rules.Where(row => row.Item1 != noEdges).ToList();
                printjob.Remove(noEdges);

               //var a = rules.Where(row => printjob.Contains(row.Item2)).ToList().Count() == 0;



            }
            fixedPrintJob.Add(printjob.First());


            middlePage = fixedPrintJob[(int)Math.Round(fixedPrintJob.Count / 2.0, MidpointRounding.ToZero)];

            return middlePage;


        }


    }
}

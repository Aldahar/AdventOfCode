using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2023
{
    public class NinthDayOfChristmas
    {
        public static long ExtrapolateTheEnvironment(List<string> lines)
        {
            List<List<long>> allRecordings = new();
            long allPredictions = 0;
            foreach (string line in lines)
            {
               var list = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(row => long.Parse(row));
                allRecordings.Add(list);
            }

            foreach (var recording in allRecordings)
            {
                List<List<long>> predictions = new();
                predictions.Add(recording);
                List<long> currentPrediction = recording;

                while (!currentPrediction.All(row=> row == 0))
                {
                    List<long> nextPrediction = new();
                    for (int i = 1; i < currentPrediction.Count; i++)
                    {
                        nextPrediction.Add(currentPrediction[i] - currentPrediction[i-1]);
                    }
                    predictions.Add(nextPrediction);
                    currentPrediction = nextPrediction;
                }
                long nextNumber = 0;
                for (int i = predictions.Count-1; i >0 ; i--)
                {
                    nextNumber = predictions[i].Last() + predictions[i - 1].Last();
                    predictions[i-1].Add(nextNumber);


                }
                allPredictions += nextNumber;
            
            
            }

            return allPredictions;

        }


        public static long ExtrapolateThePast(List<string> lines)
        {
            List<List<long>> allRecordings = new();
            long allPredictions = 0;
            foreach (string line in lines)
            {
                var list = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(row => long.Parse(row));
                allRecordings.Add(list);
            }

            foreach (var recording in allRecordings)
            {
                List<List<long>> predictions = new();
                predictions.Add(recording);
                List<long> currentPrediction = recording;

                while (!currentPrediction.All(row => row == 0))
                {
                    List<long> nextPrediction = new();
                    for (int i = 1; i < currentPrediction.Count; i++)
                    {
                        nextPrediction.Add(currentPrediction[i] - currentPrediction[i - 1]);
                    }
                    predictions.Add(nextPrediction);
                    currentPrediction = nextPrediction;
                }

                long nextNumber = 0;
                for (int i = predictions.Count - 1; i > 0; i--)
                {
                    nextNumber = predictions[i].First() + predictions[i - 1].First();
                    predictions[i - 1].Insert(0,-1*nextNumber);


                }
                allPredictions += nextNumber;


            }

            return allPredictions;

        }
    }
}

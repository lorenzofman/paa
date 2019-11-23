using System;
using System.Collections.Generic;

namespace AssemblyLines
{ 
    class Program
    {
        static void Main(string[] args)
        {
            int stations = 4;
            int[,] stationCosts = 
            { 
                {4, 5, 3, 2},
                {2, 10, 1, 4}
            };

            int[,] transferenceCosts = 
            { 
                {0, 7, 4, 5},
                {0, 9, 2, 8} 
            };

            int[] enterCosts = { 10, 12 };
            int[] exitCosts = { 18, 7 };

            Assembly(stationCosts, transferenceCosts, enterCosts, exitCosts, stations).ForEach(stLine => Console.WriteLine(stLine));
        
        }

        private static List<int> Assembly(int [,] stationCosts, int[,] transferenceCosts, int[] enterCosts, int[] exitCosts, int stations)
        {
            /* Indexing: [assemblyLine, station] */
            int[] fstAssemblyCosts = new int[stations];
            int[] sndAssemblyCosts = new int[stations];

            int[] fstStationPrevious = new int[stations];
            int[] sndStationPrevious = new int[stations];

            fstAssemblyCosts[0] = enterCosts[0] + stationCosts[0, 0];

            sndAssemblyCosts[0] = enterCosts[1] + stationCosts[1, 0];

            for (int st = 1; st < stations; st++)
            {
                int fstLinePreviousCost = fstAssemblyCosts[st - 1];
                int sndLinePreviousCost = sndAssemblyCosts[st - 1];

                int fstLineCurrentCost = fstLinePreviousCost + stationCosts[0, st];
                int sndLineCurrentCost = sndLinePreviousCost +stationCosts[1, st];

                int fstLineCostWithTransference = fstLinePreviousCost + transferenceCosts[0, st];
                int sndLineCostWithTransference = sndLinePreviousCost + transferenceCosts[1, st];

                fstAssemblyCosts[st] = Math.Min(fstLineCurrentCost, sndLineCostWithTransference);
                fstStationPrevious[st] = (fstLineCurrentCost < sndLineCostWithTransference) ? 0 : 1;

                sndAssemblyCosts[st] = Math.Min(sndLineCurrentCost, fstLineCostWithTransference);
                sndStationPrevious[st] = (sndLineCurrentCost < fstLineCostWithTransference) ? 1 : 0;
            }

            int fstLast = fstAssemblyCosts[stations - 1] += exitCosts[0];

            int sndLast = sndAssemblyCosts[stations - 1] += exitCosts[1];

            List<int> path = new List<int>();


            int currentStation = (fstLast < sndLast) ? 0 : 1;
            for (int i = stations - 1; i >= 0; i--)
            {
                path.Add(currentStation);
                currentStation = (currentStation == 0) ? fstStationPrevious[i] : sndStationPrevious[i];
            }
            path.Add(currentStation);

            path.Reverse();
            return path;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace KNearestNeighborsExamples
{
    public static class BakeryOperations
    {
        public static double RegressionForBreadSoldWith(this List<SalesRecord> salesRecords, int weatherScore, int isWeekendOrHoliday, int isGameDay)
        {
            var closest4Neighbors = salesRecords.Select(
                s => new Neighbor<SalesRecord>
                {
                    Value = s,
                    Distance = CalculateDistanceBetween(weatherScore, isWeekendOrHoliday, isGameDay, s.WeatherScore, s.WasWeekendOrHoliday, s.WasGameDay)
                }).OrderBy(n => n.Distance).Take(4);

            return closest4Neighbors.Select(n => n.Value.BreadSold).Average();
        }

        private static double CalculateDistanceBetween(int x1, int y1, int z1, int x2, int y2, int z2)
            => Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2) + Math.Pow((z1 - z2), 2));
    }

    public class SalesRecord
    {
        public int WeatherScore { get; set; }
        public int WasWeekendOrHoliday { get; set; } 
        public int WasGameDay { get; set; }
        public int BreadSold { get; set; }
    }
}

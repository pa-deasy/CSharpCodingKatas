using NUnit.Framework;
using System.Collections.Generic;

namespace KNearestNeighborsExamples.Tests.Unit
{
    [TestFixture]
    public class BakeryOperationsTests
    {
        [Test]
        public void Given_SalesConditions_When_ClosestNeighborsObtained_Then_PredictsSales()
        {
            var salesRecords = new List<SalesRecord> 
            {
                new SalesRecord{ WeatherScore = 5, WasWeekendOrHoliday = 1, WasGameDay = 0, BreadSold = 300 },
                new SalesRecord{ WeatherScore = 3, WasWeekendOrHoliday = 1, WasGameDay = 1, BreadSold = 225 },
                new SalesRecord{ WeatherScore = 1, WasWeekendOrHoliday = 1, WasGameDay = 0, BreadSold = 75 },
                new SalesRecord{ WeatherScore = 4, WasWeekendOrHoliday = 0, WasGameDay = 1, BreadSold = 200 },
                new SalesRecord{ WeatherScore = 4, WasWeekendOrHoliday = 0, WasGameDay = 0, BreadSold = 150 },
                new SalesRecord{ WeatherScore = 2, WasWeekendOrHoliday = 0, WasGameDay = 0, BreadSold = 50 }
            };

            Assert.AreEqual(218.75, salesRecords.RegressionForBreadSoldWith(4, 1, 0));
        }
    }
}

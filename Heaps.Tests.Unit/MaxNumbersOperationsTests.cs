using NUnit.Framework;
using System;
using System.Linq;

namespace Heaps.Tests.Unit
{
    [TestFixture]
    public class MaxNumbersOperationsTests
    {
        [Test]
        public void Given_ArrayOf100Numbers_When_Highest20Retrieved_Then_AsExpected()
        {
            var numbers = TestArrayOf(100, 20);

            var highest20 = numbers.HighestNumbersOf(20);

            Assert.That(numbers.Take(20), Is.EquivalentTo(highest20));
        }

        [Test]
        public void Given_ArrayOf5000Numbers_When_Highest10Retrieved_Then_AsExpected()
        {
            var numbers = TestArrayOf(5000, 10);

            var highest10 = numbers.HighestNumbersOf(10);

            Assert.That(numbers.Take(10), Is.EquivalentTo(highest10));
        }

        private static int[] TestArrayOf(int arrayLength, int highestCount)
        {
            var testArray = new int[arrayLength];

            var highest = GenerateRandomArrayOf(highestCount, 90000, 99999);
            highest.CopyTo(testArray, 0);

            var randomArrayLength = arrayLength - highestCount;
            var randomArray = GenerateRandomArrayOf(randomArrayLength, 0, 89999);
            randomArray.CopyTo(testArray, highestCount);

            return testArray;
        }

        private static int[] GenerateRandomArrayOf(int arrayLength, int minValue, int maxValue)
        {
            var randomArray = new int[arrayLength];
            var random = new Random();

            for (int index = 0; index < arrayLength; index++)
                randomArray[index] = random.Next(minValue, maxValue);

            return randomArray;
        }
    }
}

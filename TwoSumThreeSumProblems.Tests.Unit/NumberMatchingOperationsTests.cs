using NUnit.Framework;
using System.Collections.Generic;

namespace TwoSumThreeSumProblems.Tests.Unit
{
    [TestFixture]
    public class NumberMatchingOperationsTests
    {
        [Test]
        public void Given_Target_When_TargetSummingPairExists_Then_RetursPair()
        {
            var numbers = new List<int> { 0, -1, 2, -3, 1 };
            var expectedPair = new List<int> { 1, -3 };

            var pair = numbers.FindPairSummingTo(-2);

            Assert.AreEqual(expectedPair, pair);
        }

        [Test]
        public void Given_Target_When_TargetSummingTripletExists_Then_RetursTriplet()
        {
            var numbers = new List<int> { 12, 3, 4, 1, 6, 9 };
            var expectedPair = new List<int> { 9, 12, 3 };

            var triplet = numbers.FindTripletSummingTo(24);

            Assert.AreEqual(expectedPair, triplet);
        }
    }
}

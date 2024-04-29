using NUnit.Framework;

namespace ClosestPairSummingTo.Tests.Unit
{
    [TestFixture]
    public class NumbersArrayOperationsTests
    {
        [Test]
        public void Given_Numbers_When_ClosestPairSummingToZero_Then_ReturnsClosestPair()
        {
            var numbers = new int[] { 1, 60, -10, 70, -80, 85 };

            var closestPair = numbers.ClosestPairSummingTo(0);

            Assert.AreEqual(-80, closestPair.Item1);
            Assert.AreEqual(85, closestPair.Item2);
        }

        [Test]
        public void Given_Numbers_When_ClosestPairSummingToNine_Then_ReturnsClosestPair()
        {
            var numbers = new int[] { 1, -21, -8, 29, -1 , 85 };

            var closestPair = numbers.ClosestPairSummingTo(9);

            Assert.AreEqual(-21, closestPair.Item1);
            Assert.AreEqual(29, closestPair.Item2);
        }
    }
}

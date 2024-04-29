using NUnit.Framework;

namespace MissingNumber.Tests.Unit
{
    [TestFixture]
    public class NumbersArrayOperationsTests
    {
        [Test]
        public void Given_ArrayOfNumbers_When_ContainsMissingNumber_Then_ReturnsExpected()
        {
            var numbers = new int[] { 1, 2, 4, 6, 3, 7, 8 };

            Assert.AreEqual(5, numbers.MissingNumber());
        }
    }
}

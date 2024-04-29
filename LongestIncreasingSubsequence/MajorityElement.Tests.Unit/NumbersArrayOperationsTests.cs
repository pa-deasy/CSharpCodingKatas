using NUnit.Framework;

namespace MajorityElement.Tests.Unit
{
    [TestFixture]
    public class NumbersArrayOperationsTests
    {
        [Test]
        public void Given_ArrayOfNumbers_When_MajorityElementExists_Then_ReturnsElement()
        {
            var numbers = new int[] { 3, 3, 4, 2, 4, 4, 2, 4, 4 };
            Assert.AreEqual(4, numbers.MajorityElement());
        }

        [Test]
        public void Given_ArrayOfNumbers_When_MajorityElementDoesNotExist_Then_ReturnsZero()
        {
            var numbers = new int[] { 3, 3, 4, 2, 4, 4, 2, 4 };
            Assert.AreEqual(0, numbers.MajorityElement());
        }
    }
}

using NUnit.Framework;

namespace StringExercises.Tests.Unit
{
    [TestFixture]
    public class UniqueOrderingTests
    {
        [Test]
        public void Given_String_When_DuplicatesRemovedAndOrdered_Then_IsAsExpected()
        {
            var input = "abuukscpccf";
            var expected = "abcfkpsu";

            Assert.AreEqual(expected, input.RemoveDuplicatesAndOrder());
        }
    }
}

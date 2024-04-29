using NUnit.Framework;
using System.Collections.Generic;

namespace StringExercises.Tests.Unit
{
    [TestFixture]
    public class StringPermutationsTests
    {
        [Test]
        public void Given_SimpleString_When_PermutationsCalculated_Then_AsExpected()
        {
            var input = "ABC";
            var expectedPermutations = new HashSet<string> { "ABC", "BAC", "CBA", "ACB", "BCA", "CAB" };

            var permutations = input.Permutations();

            Assert.That(permutations, Is.EquivalentTo(expectedPermutations));
        }

        [Test]
        public void Given_String_When_PermutationsCalculated_Then_AsExpected()
        {
            var input = "ABCD";
            var expectedCount = 24; // 4 x 3 x 2 x 1

            var permutations = input.Permutations();

            Assert.AreEqual(expectedCount, permutations.Count);
        }
    }
}

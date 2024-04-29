using NUnit.Framework;

namespace StringExercises.Tests.Unit
{
    [TestFixture]
    public class SentenceReversalTests
    {
        [Test]
        public void Given_Sentence_When_Reversed_Then_AsExpected()
        {
            var sentence = "My name is Khan";
            var expected = "Khan is name My";

            var reversed = sentence.ReverseSentence();

            Assert.AreEqual(expected, reversed);
        }
    }
}

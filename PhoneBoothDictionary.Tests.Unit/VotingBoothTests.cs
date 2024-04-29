using NUnit.Framework;
using System;

namespace PhoneBoothDictionary.Tests.Unit
{
    [TestFixture]
    public class VotingBoothTests
    {
        private VotingBooth _votingBooth;

        [SetUp]
        public void SetUp()
        {
            _votingBooth = new VotingBooth();
        }


        [Test]
        public void Given_VotingBooth_When_NewVoteCast_Then_AddedToVotes()
        {
            _votingBooth.CastVote("Patrick", "Bertie Ahern");

            _votingBooth.CastVote("Michael", "John Desmond");

            Assert.AreEqual(2, _votingBooth.Votes.Count);
        }

        [Test]
        public void Given_VotingBooth_When_RecurringVoteCast_Then_ExceptionThrown()
        {
            _votingBooth.CastVote("Patrick", "Bertie Ahern");

            Assert.Throws<Exception>(() => _votingBooth.CastVote("Patrick", "John Desmond"));
        }

    }
}

using System;
using System.Collections.Generic;

namespace PhoneBoothDictionary
{
    public class VotingBooth
    {
        public readonly IDictionary<string, string> Votes;

        public VotingBooth()
        {
            Votes = new Dictionary<string, string>();
        }

        private bool AlreadyVoted(string name) => Votes.ContainsKey(name);

        public void CastVote(string name, string vote) 
        {
            if (AlreadyVoted(name))
                throw new Exception("Your vote was already cast!");

            Votes.Add(name, vote);
        }
    }
}

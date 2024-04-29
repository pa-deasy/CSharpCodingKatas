using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForLoopToAggregation
{
    public class Functional
    {
        public static int Add(int currentSum, int numberToAdd) => currentSum + numberToAdd;

        public static int countingValleys(int steps, string path)
        {
            var pathSteps = path.ToCharArray();

            var startingPointState = HikeState.StartingPoint;

            var endHikeState = pathSteps.Aggregate(startingPointState, (currentState, nextStep) => Walk(currentState, nextStep));

            return endHikeState.NumberOfValleys;
        }

        private static HikeState Walk(HikeState hikeState, char step)
        {
            var newSeaLevel = SeaLevelFrom(step, hikeState.SeaLevel);
            var numberOfValleys = EnteredValley(step, newSeaLevel) ? hikeState.NumberOfValleys + 1 : hikeState.NumberOfValleys;

            return new HikeState
                (
                    newSeaLevel,
                    numberOfValleys
                );
        }

        private static int SeaLevelFrom(char pathStep, int seaLevel)
        {
            if (pathStep == 'D')
                seaLevel -= 1;

            if (pathStep == 'U')
                seaLevel += 1;

            return seaLevel;
        }

        private static bool EnteredValley(char pathStep, int seaLevel)
            => pathStep == 'D' && seaLevel == -1;
    }
}

public class HikeState
{
    public int SeaLevel { get; private set; }
    public int NumberOfValleys { get; private set; }

    public HikeState(int seaLevel, int numberOfValleys)
    {
        SeaLevel = seaLevel;
        NumberOfValleys = numberOfValleys;
    }

    public static HikeState StartingPoint => new HikeState(0, 0);
}
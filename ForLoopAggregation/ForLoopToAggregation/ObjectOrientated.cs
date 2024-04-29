using System;
using System.Collections.Generic;
using System.Text;

namespace ForLoopToAggregation
{
    public class ObjectOrientated
    {
        public static int countingValleys(int steps, string path)
        {
            var pathSteps = path.ToCharArray();
            var seaLevel = 0;
            var numberOfvalleys = 0;

            foreach (char pathStep in pathSteps)
            {
                seaLevel = SeaLevelFrom(pathStep, seaLevel);

                if (EnteredValley(pathStep, seaLevel))
                    numberOfvalleys++;
            }

            return numberOfvalleys;
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

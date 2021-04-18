using System;

namespace BallArrangementProblem
{
    public static class BallsSortOperations
    {
        private static int[,,,] CalculationsCache;

        public static int NumberOfArrangementsFor(int reds, int greens, int blues)
        {
            var maxRange = Math.Max(Math.Max(reds, greens), blues) + 1;
            CalculationsCache = new int[maxRange, maxRange, maxRange, 3];

            for (int i = 0; i < maxRange; i++)
                for (int j = 0; j < maxRange; j++)
                    for (int k = 0; k < maxRange; k++)
                        for (int l = 0; l < 3; l++)
                            CalculationsCache[i, j, k, l] = -1;

            var count = CountArrangements(reds, greens, blues, Color.Red)
            + CountArrangements(reds, greens, blues, Color.Green)
            + CountArrangements(reds, greens, blues, Color.Blue);

            return count;
        }

        private static int CountArrangements(int reds, int greens, int blues, Color lastBall)
        {
            if(reds < 0 || greens < 0 || blues < 0)
                return 0;

            if(reds == 1 && greens == 0 && blues == 0 && lastBall == Color.Red)
                return 1;

            if(reds == 0 && greens == 1 && blues == 0 && lastBall == Color.Green)
                return 1;

            if(reds == 0 && greens == 0 && blues == 1 && lastBall == Color.Blue)
                return 1;

            if (CalculationsCache[reds, greens, blues, (int)lastBall] != -1)
                return CalculationsCache[reds, greens, blues, (int)lastBall];

            if (lastBall == Color.Red)
                CalculationsCache[reds, greens, blues, (int)lastBall] = 
                    CountArrangements(reds - 1, greens, blues, Color.Green) + CountArrangements(reds - 1, greens, blues, Color.Blue);

            if (lastBall == Color.Green)
                CalculationsCache[reds, greens, blues, (int)lastBall] =
                    CountArrangements(reds, greens - 1, blues, Color.Red) + CountArrangements(reds, greens - 1, blues, Color.Blue);

            if (lastBall == Color.Blue)
                CalculationsCache[reds, greens, blues, (int)lastBall] =
                    CountArrangements(reds, greens, blues - 1, Color.Red) + CountArrangements(reds, greens, blues - 1, Color.Green);

            return CalculationsCache[reds, greens, blues, (int)lastBall];
        }
    }

    public enum Color
    {
        Red = 0,
        Green = 1,
        Blue = 2
    }
}

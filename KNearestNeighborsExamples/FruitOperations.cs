using System;
using System.Collections.Generic;
using System.Linq;

namespace KNearestNeighborsExamples
{
    public static class FruitOperations
    {
        public static Fruit GrapefruitOrOrangeClassificationFor(this IList<Fruit> fruits, int size, int redness)
        {
            var closest3Neighbors = fruits.Select(
                f => new Neighbor<Fruit> { Value = f, Distance = CalculateDistanceBetween(size, redness, f.Size, f.Redness) })
                .OrderBy(n => n.Distance).Take(3);

            var closestOrangeNeighborsCount = closest3Neighbors.Where(o => o.Value.Type == FruitType.Orange).Count();
            var closestGrapefruitNeighborsCount = closest3Neighbors.Where(o => o.Value.Type == FruitType.Grapefruit).Count();
            
            return closestOrangeNeighborsCount > closestGrapefruitNeighborsCount 
                ? new Fruit { Type = FruitType.Orange, Redness = redness, Size = size }
                : new Fruit { Type = FruitType.Grapefruit, Redness = redness, Size = size };
        }

        private static double CalculateDistanceBetween(int x1, int y1, int x2, int y2)
            => Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
    }

    public class Fruit
    {
        public int Size { get; set; }
        public int Redness { get; set; }
        public FruitType Type { get; set; }
    }

    public enum FruitType
    {
        Orange,
        Grapefruit
    }
}

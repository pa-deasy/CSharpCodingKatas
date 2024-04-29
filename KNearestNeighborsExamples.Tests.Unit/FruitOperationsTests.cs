using NUnit.Framework;
using System.Collections.Generic;

namespace KNearestNeighborsExamples.Tests.Unit
{
    [TestFixture]
    public class FruitOperationsTests
    {
        [Test]
        public void Given_SizeAndRedness_When_ClosestNeighborsObtained_Then_CorrectFruitIdentified()
        {
            var fruits = new List<Fruit>
            {
                new Fruit{ Redness = 1, Size = 1, Type = FruitType.Orange },
                new Fruit{ Redness = 2, Size = 1, Type = FruitType.Orange },
                new Fruit{ Redness = 1, Size = 3, Type = FruitType.Orange },
                new Fruit{ Redness = 5, Size = 5, Type = FruitType.Grapefruit },
                new Fruit{ Redness = 5, Size = 7, Type = FruitType.Grapefruit }
            };

            Assert.AreEqual(FruitType.Orange, fruits.GrapefruitOrOrangeClassificationFor(3, 2).Type);

            Assert.AreEqual(FruitType.Grapefruit, fruits.GrapefruitOrOrangeClassificationFor(4, 4).Type);
        }
    }

    
}

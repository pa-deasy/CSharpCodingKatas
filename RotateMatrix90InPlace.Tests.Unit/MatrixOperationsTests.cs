using FluentAssertions;
using NUnit.Framework;

namespace RotateMatrix90InPlace.Tests.Unit
{
    [TestFixture]
    public class MatrixOperationsTests
    {
        [Test]
        public void Given_MatrixBy3_When_Rotated90AntiClockwise_Then_MatrixAsExpected()
        {
            var rotated = MatrixBy3.Rotate90AntiClock();

            rotated.Cells[0, 0].Should().Be(3);
            rotated.Cells[1, 0].Should().Be(2);
            rotated.Cells[2, 0].Should().Be(1);

            rotated.Cells[0, 1].Should().Be(6);
            rotated.Cells[1, 1].Should().Be(5);
            rotated.Cells[2, 1].Should().Be(4);

            rotated.Cells[0, 2].Should().Be(9);
            rotated.Cells[1, 2].Should().Be(8);
            rotated.Cells[2, 2].Should().Be(7);
        }

        [Test]
        public void Given_MatrixBy4_When_Rotated90AntiClockwise_Then_MatrixAsExpected()
        {
            var rotated = MatrixBy4.Rotate90AntiClock();

            rotated.Cells[0, 0].Should().Be(4);
            rotated.Cells[1, 0].Should().Be(3);
            rotated.Cells[2, 0].Should().Be(2);
            rotated.Cells[3, 0].Should().Be(1);

            rotated.Cells[0, 1].Should().Be(8);
            rotated.Cells[1, 1].Should().Be(7);
            rotated.Cells[2, 1].Should().Be(6);
            rotated.Cells[3, 1].Should().Be(5);

            rotated.Cells[0, 2].Should().Be(12);
            rotated.Cells[1, 2].Should().Be(11);
            rotated.Cells[2, 2].Should().Be(10);
            rotated.Cells[3, 2].Should().Be(9);

            rotated.Cells[0, 3].Should().Be(16);
            rotated.Cells[1, 3].Should().Be(15);
            rotated.Cells[2, 3].Should().Be(14);
            rotated.Cells[3, 3].Should().Be(13);
        }

        [Test]
        public void Given_MatrixBy6_When_Rotated90AntiClockwise_Then_MatrixAsExpected()
        {
            var rotated = MatrixBy6.Rotate90AntiClock();

            rotated.Cells[0, 0].Should().Be(6);
            rotated.Cells[1, 0].Should().Be(5);
            rotated.Cells[2, 0].Should().Be(4);
            rotated.Cells[3, 0].Should().Be(3);
            rotated.Cells[4, 0].Should().Be(2);
            rotated.Cells[5, 0].Should().Be(1);

            rotated.Cells[0, 1].Should().Be(12);
            rotated.Cells[1, 1].Should().Be(11);
            rotated.Cells[2, 1].Should().Be(10);
            rotated.Cells[3, 1].Should().Be(9);
            rotated.Cells[4, 1].Should().Be(8);
            rotated.Cells[5, 1].Should().Be(7);

            rotated.Cells[0, 2].Should().Be(18);
            rotated.Cells[1, 2].Should().Be(17);
            rotated.Cells[2, 2].Should().Be(16);
            rotated.Cells[3, 2].Should().Be(15);
            rotated.Cells[4, 2].Should().Be(14);
            rotated.Cells[5, 2].Should().Be(13);

            rotated.Cells[0, 3].Should().Be(24);
            rotated.Cells[1, 3].Should().Be(23);
            rotated.Cells[2, 3].Should().Be(22);
            rotated.Cells[3, 3].Should().Be(21);
            rotated.Cells[4, 3].Should().Be(20);
            rotated.Cells[5, 3].Should().Be(19);

            rotated.Cells[0, 4].Should().Be(30);
            rotated.Cells[1, 4].Should().Be(29);
            rotated.Cells[2, 4].Should().Be(28);
            rotated.Cells[3, 4].Should().Be(27);
            rotated.Cells[4, 4].Should().Be(26);
            rotated.Cells[5, 4].Should().Be(25);

            rotated.Cells[0, 5].Should().Be(36);
            rotated.Cells[1, 5].Should().Be(35);
            rotated.Cells[2, 5].Should().Be(34);
            rotated.Cells[3, 5].Should().Be(33);
            rotated.Cells[4, 5].Should().Be(32);
            rotated.Cells[5, 5].Should().Be(31);


        }

        [Test]
        public void Given_MatrixBy3_When_Rotated90Clockwise_Then_MatrixAsExpected()
        {
            var rotated = MatrixBy3.Rotate90Clock();

            rotated.Cells[0, 0].Should().Be(7);
            rotated.Cells[1, 0].Should().Be(8);
            rotated.Cells[2, 0].Should().Be(9);

            rotated.Cells[0, 1].Should().Be(4);
            rotated.Cells[1, 1].Should().Be(5);
            rotated.Cells[2, 1].Should().Be(6);

            rotated.Cells[0, 2].Should().Be(1);
            rotated.Cells[1, 2].Should().Be(2);
            rotated.Cells[2, 2].Should().Be(3);
        }

        [Test]
        public void Given_MatrixBy4_When_Rotated90Clockwise_Then_MatrixAsExpected()
        {
            var rotated = MatrixBy4.Rotate90Clock();

            rotated.Cells[0, 0].Should().Be(13);
            rotated.Cells[1, 0].Should().Be(14);
            rotated.Cells[2, 0].Should().Be(15);
            rotated.Cells[3, 0].Should().Be(16);

            rotated.Cells[0, 1].Should().Be(9);
            rotated.Cells[1, 1].Should().Be(10);
            rotated.Cells[2, 1].Should().Be(11);
            rotated.Cells[3, 1].Should().Be(12);

            rotated.Cells[0, 2].Should().Be(5);
            rotated.Cells[1, 2].Should().Be(6);
            rotated.Cells[2, 2].Should().Be(7);
            rotated.Cells[3, 2].Should().Be(8);

            rotated.Cells[0, 3].Should().Be(1);
            rotated.Cells[1, 3].Should().Be(2);
            rotated.Cells[2, 3].Should().Be(3);
            rotated.Cells[3, 3].Should().Be(4);
        }

        private static Matrix MatrixBy3 =>
            new Matrix(new int[,]
                {{ 1, 2, 3 },
                 { 4, 5, 6 },
                 { 7, 8, 9 }});

        private static Matrix MatrixBy4 =>
            new Matrix(new int[,]
                {{ 1, 2, 3, 4},
                 { 5, 6, 7, 8 },
                 { 9, 10, 11, 12 },
                 { 13, 14, 15, 16 } });

        private static Matrix MatrixBy6 =>
            new Matrix(new int[,]
                {{ 1, 2, 3, 4, 5, 6},
                 { 7, 8, 9, 10, 11, 12 },
                 { 13, 14, 15, 16, 17, 18 },
                 { 19, 20, 21, 22, 23, 24 },
                 { 25, 26, 27, 28, 29, 30 },
                 { 31, 32, 33, 34, 35, 36 }});
    }
}

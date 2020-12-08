using System.Linq;
using AdventOfCode.Domain.Day05;
using Xunit;

namespace AdventOfCode.Tests
{
    public class AdventOfCode_Day05Tests
    {
        [Theory]
        [InlineData(0, 128, 'F', 0, 63)]
        [InlineData(0, 64, 'B', 32, 63)]
        [InlineData(32, 32, 'F', 32, 47)]
        [InlineData(32, 16, 'B', 40, 47)]
        [InlineData(40, 8, 'B', 44, 47)]
        [InlineData(44, 4, 'F', 44, 45)]
        [InlineData(44, 2, 'F', 44, 44)]
        public void SplitArrayTests(int start, int length, char command, int lower, int higher)
        {
            var range = Enumerable.Range(start, length);
            var half = range.GetRowHalf(command);
            Assert.Equal(lower, half.First());
            Assert.Equal(higher, half.Last());
        }
        //

        [Theory]
        [InlineData("FBFBBFF", 44)]
        [InlineData("BFFFBBFRRR", 70)]
        [InlineData("FFFBBBFRRR", 14)]
        [InlineData("BBFFBBFRLL", 102)]
        public void RowNumber(string sequence, int expectedResult)
        {
            var result = Day05ExtensionMethods.RowNumber(sequence);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("RRR", 7)]
        [InlineData("RLL", 4)]
        public void ColNumber(string sequence, int expectedResult)
        {
            var res = Day05ExtensionMethods.ColumnNumber(sequence);

            Assert.Equal(expectedResult, res);
        }

        [Theory]
        [InlineData("BFFFBBFRRR", 567)]
        public void SeatNumber(string s, int expectedResult)
        {
            var res = Day05ExtensionMethods.SeatNumber(s);

            Assert.Equal(res, expectedResult);
        }
    }
}
using System.Linq;
using AdventOfCode.Domain;
using AdventOfCode.Domain.Day06;
using Xunit;

namespace AdventOfCode.Tests
{
    public class AdventOfCode_Day06Tests
    {
        [Theory]
        [InlineData("Day06.Example.txt", 5)]
        public void FileSplitsIntoCorrectNumberGroups(string filename, int expectedCount)
        {
            var groups = FileUtils.SplitFileByBlankLines(filename);
            
            Assert.Equal(expectedCount, groups.Count());
        }
    }
}
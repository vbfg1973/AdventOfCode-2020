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

        [Theory]
        [InlineData("a b c", "abc")]
        [InlineData("a b\nc", "abc")]
        [InlineData("a\n\tb\nc", "abc")]
        public void StripWhiteSpace(string input, string expected)
        {
            var res = StringUtils.StripAllWhiteSpace(input);
            Assert.Equal(expected, res);
        }
        
        [Theory]
        [InlineData("a b c", "abc")]
        [InlineData("a b\nc", "ab\nc")]
        [InlineData("a\n\tb\nc", "a\nb\nc")]
        public void StripWhiteSpaceExceptNewlines(string input, string expected)
        {
            var res = StringUtils.StripAllWhiteSpaceExceptNewlines(input);
            Assert.Equal(expected, res);
        }
    }
}
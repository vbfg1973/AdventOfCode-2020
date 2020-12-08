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

        [Theory]
        [InlineData("abc", 3)]
        [InlineData("a b c", 3)]
        [InlineData("a\nb\n\tc", 3)]
        [InlineData("aaa", 1)]
        [InlineData("a a a", 1)]
        [InlineData("a\na\n\ta", 1)]
        public void CountAllAsOne(string input, int expected)
        {
            var d = new AllQuestionsAnyone();
            var actual = d.CountGroup(input);
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Day06.Example.txt", 11)]
        public void CountAllQuestionsAnyone(string filename, int expected)
        {
            var d6 = new AllQuestionsAnyone();
            var actual = d6.Count(filename);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(" a b c", 1)]
        [InlineData("abc", 1)]
        [InlineData("a\nb\nc", 3)]
        [InlineData("ab\nac", 2)]
        [InlineData("a\na\na\na", 4)]
        [InlineData("b", 1)]
        public void SplitGroupsIntoIndividualsEveryone(string input, int expected)
        {
            var d6 = new AllQuestionsEveryone();
            var actual = d6.SplitGroupIntoIndividuals(input).Count();
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("abc", 3)]
        [InlineData("a\nb\nc", 0)]
        [InlineData("ab\nac", 1)]
        [InlineData("a\na\na\na", 1)]
        [InlineData("b", 1)]
        public void CountAllQuestionsSingleGroupEveryone(string input, int expected)
        {
            var d6 = new AllQuestionsEveryone();
            var actual = d6.CountGroup(input);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("Day06.Example.txt", 6)]
        public void CountAllQuestionsEveryone(string filename, int expected)
        {
            var d6 = new AllQuestionsEveryone();
            var actual = d6.Count(filename);

            Assert.Equal(expected, actual);
        }
    }
}
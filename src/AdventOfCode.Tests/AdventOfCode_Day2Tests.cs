using AdventOfCode.Domain;
using Xunit;

namespace AdventOfCode.Tests
{
    public class AdventOfCode_Day2Tests
    {
        [Theory]
        [InlineData(1, 3, 'a', "abcde", true)]
        [InlineData(1, 3, 'b', "cdefg", false)]
        [InlineData(2, 9, 'c', "ccccccccc", true)]
        public void GivenMinMaxConstraintsStringMatches(int min, int max, char c, string testString, bool expected)
        {
            var passwordVerifier = new PasswordVerifier();

            var answer = passwordVerifier.IsMinMaxValidPassword(min, max, c, testString);

            Assert.Equal(expected, answer);
        }

        [Theory]
        [InlineData(1, 3, 'a', "abcde", true)]
        [InlineData(1, 3, 'b', "cdefg", false)]
        [InlineData(2, 9, 'c', "ccccccccc", false)]
        public void GivenPositionalConstraintsStringMatches(int posA, int posB, char c, string testString,
            bool expected)
        {
            var passwordVerifier = new PasswordVerifier();

            var answer = passwordVerifier.IsPositionalValidPassword(posA, posB, c, testString);

            Assert.Equal(expected, answer);
        }

        [Theory]
        [InlineData("1-3 a: abcde", 1, 3, 'a', "abcde")]
        [InlineData("1-3 b: cdefg", 1, 3, 'b', "cdefg")]
        [InlineData("2-9 c: ccccccccc", 2, 9, 'c', "ccccccccc")]
        public void GivenRuleIsParsedIntoComponents(string rule, int expectedMin, int expectedMax, char expectedChar,
            string expectedPassword)
        {
            var passwordVerifier = new PasswordVerifier();

            string password;
            char c;
            int min, max;

            passwordVerifier.ParseRule(out min, out max, out c, out password, rule);

            Assert.Equal(expectedMin, min);
            Assert.Equal(expectedMax, max);
            Assert.Equal(expectedChar, c);
            Assert.Equal(expectedPassword, password);
        }
    }
}
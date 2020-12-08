using AdventOfCode.Domain.Day07;
using Xunit;

namespace AdventOfCode.Tests
{
    public class AdventOfCode_Day07Tests
    {
        [Theory]
        [InlineData("Day07.Example.txt", 4)]
        public void s1ExampleParsesCorrectly(string filename, int expected)
        {
            var d7 = new Day07(filename);
            Assert.Equal(expected, d7.Solve_1());
        }
        
        [Theory]
        [InlineData("Day07.Example.txt", 32)]
        public void s2ExampleParsesCorrectly(string filename, int expected)
        {
            var d7 = new Day07(filename);
            Assert.Equal(expected, d7.Solve_2());
        }
    }
}
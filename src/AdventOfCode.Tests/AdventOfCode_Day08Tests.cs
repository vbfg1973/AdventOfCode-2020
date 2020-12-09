using AdventOfCode.Domain.Day08;
using Xunit;

namespace AdventOfCode.Tests
{
    public class AdventOfCode_Day08Tests
    {
        [Theory]
        [InlineData("Day08.Example.txt", 5)]
        public void ExampleRunsOkay(string filename, int expectedValue)
        {
            var d8 = new Day08();
            d8.LoadFromFile(filename);
            var actual = d8.Run();
            
            Assert.Equal(expectedValue, actual);
        }
    }
}
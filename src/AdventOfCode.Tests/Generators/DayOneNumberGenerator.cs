using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Generators
{
    public static class DayOneDataGenerator
    {
        private static int[] _data = {1721, 979, 366, 299, 675, 1456};

        public static IEnumerable<object[]> CombinationData => new List<object[]>
        {
            new object[]
            {
                2, // Size of combination 
                15, // Number of combinations
                _data
            }
        };

        public static IEnumerable<object[]> FinalSumData => new List<object[]>
        {
            new object[]
            {
                _data,
                new int[] {1721, 299},
                2020
            }
        };
        
        public static IEnumerable<object[]> FinalProductData => new List<object[]>
        {
            new object[]
            {
                _data,
                2020,
                514579
            }
        };
    }
}
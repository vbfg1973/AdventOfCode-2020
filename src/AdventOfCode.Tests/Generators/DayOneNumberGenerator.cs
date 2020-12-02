using System.Collections.Generic;

namespace AdventOfCode.Tests.Generators
{
    public static class DayOneDataGenerator
    {
        private static readonly int[] _data = {1721, 979, 366, 299, 675, 1456};

        public static IEnumerable<object[]> CombinationData => new List<object[]>
        {
            new object[]
            {
                2, // Size of combination 
                15, // Number of combinations
                _data
            }
        };

        public static IEnumerable<object[]> FinalSumData_Part01 => new List<object[]>
        {
            new object[]
            {
                2,
                _data,
                new[] {1721, 299},
                2020
            }
        };

        public static IEnumerable<object[]> FinalSumData_Part02 => new List<object[]>
        {
            new object[]
            {
                3,
                _data,
                new[] {979, 366, 675},
                2020
            }
        };

        public static IEnumerable<object[]> FinalProductData_Part01 => new List<object[]>
        {
            new object[]
            {
                2,
                _data,
                2020,
                514579
            }
        };

        public static IEnumerable<object[]> FinalProductData_Part02 => new List<object[]>
        {
            new object[]
            {
                3,
                _data,
                2020,
                241861950
            }
        };
    }
}
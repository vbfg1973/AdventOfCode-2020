using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain.Day05
{
    public static class Day05ExtensionMethods
    {
        public static void Split<T>(T[] array, int index, out T[] first, out T[] second)
        {
            first = array.Take(index).ToArray();
            second = array.Skip(index).ToArray();
        }

        public static void SplitMidPoint<T>(T[] array, out T[] first, out T[] second)
        {
            Split(array, array.Length / 2, out first, out second);
        }

        public static IEnumerable<T> GetRowHalf<T>(this IEnumerable<T> enumerable, char c)
        {
            T[] first;
            T[] second;
            
            SplitMidPoint(enumerable.ToArray(), out first, out second);
            switch (c)
            {
                case 'F':
                    return first;
                case 'B':
                    return second;
                default:
                    throw new ArgumentException();
            }
        }
        
        public static IEnumerable<T> GetColHalf<T>(this IEnumerable<T> enumerable, char c)
        {
            T[] first;
            T[] second;
            
            SplitMidPoint(enumerable.ToArray(), out first, out second);
            switch (c)
            {
                case 'L':
                    return first;
                case 'R':
                    return second;
                default:
                    throw new ArgumentException();
            }
        }

        public static int RowNumber(string s)
        {
            var range = Enumerable.Range(0, 128);
        
            var rowDirections = s.Take(7);
        
            foreach (var direction in rowDirections)
            {
                range = range.GetRowHalf(direction);
            }

            return range.First();
        }

        public static int ColumnNumber(string s)
        {
            var range = Enumerable.Range(0, 8);
            var colDirections = s.Skip(Math.Max(0, s.Count() - 3));
            
            foreach (var direction in colDirections)
            {
                range = range.GetColHalf(direction);
            }

            return range.First();
        }

        public static int SeatNumber(string s)
        {
            return (Day05ExtensionMethods.RowNumber(s) * 8) + Day05ExtensionMethods.ColumnNumber(s);
        }
    }
}
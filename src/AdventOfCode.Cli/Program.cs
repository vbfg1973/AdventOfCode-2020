using System;
using AdventOfCode.Domain.Day06;
using AdventOfCode.Domain.Day07;

namespace AdventOfCode.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var filename = args[0];
            var day07 = new Day07(filename);
            Console.WriteLine(day07.Solve_1());
            Console.WriteLine(day07.Solve_2())
        }
    }
}
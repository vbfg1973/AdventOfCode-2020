using System;
using AdventOfCode.Domain.Day06;

namespace AdventOfCode.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var filename = args[0];

            var d6 = new AllQuestionsEveryone();
            var actual = d6.Count(filename);
            Console.WriteLine(actual);
        }
    }
}
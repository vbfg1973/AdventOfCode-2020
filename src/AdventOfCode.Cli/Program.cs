using System;
using AdventOfCode.Cli.Days;

namespace AdventOfCode.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = args[0];

            var d = new Day01();
            Console.WriteLine(d.Run(2, filename));

            Console.WriteLine(d.Run(3, filename));
        }
    }
}
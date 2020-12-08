using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Domain;
using AdventOfCode.Domain.Day03;
using AdventOfCode.Domain.Day04;
using AdventOfCode.Domain.Day05;

namespace AdventOfCode.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var filename = args[0];
            
            var dayRunner = new Day05Runner();
            dayRunner.RunP1(filename);
        }
    }
}

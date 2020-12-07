using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Domain;
using AdventOfCode.Domain.Day03;
using AdventOfCode.Domain.Day04;

namespace AdventOfCode.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var filename = args[0];
            
            var dayRunner = new Day03Runner();
            dayRunner.Run(filename);
        }
    }
}

using System;
using System.IO;
using System.Linq;
using System.Net;

namespace AdventOfCode.Domain.Day05
{
    public class Day05Runner
    {
        public void RunP1(string fileName)
        {
            var lines = File.ReadAllLines(fileName)
                .Select(str => str.Trim())
                .Where(str => str.Length > 0);

            var biggest = lines.Select(line => Day05ExtensionMethods.SeatNumber(line))
                .Max();

            Console.WriteLine(biggest);
        }
    }
}
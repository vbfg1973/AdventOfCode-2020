using System;
using System.IO;
using System.Runtime.InteropServices;

namespace AdventOfCode.Domain.Day04
{
    public class Day04Runner
    {
        public void RunP1(string fileName)
        {
            var validator = new Validator();
            var text = File.ReadAllText(fileName);

            Console.WriteLine(validator.CountValid(text));
        }
    }
}
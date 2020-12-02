using System;
using AdventOfCode.Domain;

namespace AdventOfCode.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var filename = args[0];

            var passwordVerified = new PasswordVerifier();
            var result = passwordVerified.CountValidInFileMinMax(filename);
            Console.WriteLine(result);

            var resultPositional = passwordVerified.CountValidInFilePositional(filename);
            Console.WriteLine(resultPositional);
        }
    }
}
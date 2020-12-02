using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class PasswordVerifier
    {
        public bool IsMinMaxValidPassword(int min, int max, char c, string password)
        {
            var occurrences = password.Count(ch => ch == c);
            return occurrences >= min && occurrences <= max;
        }

        public bool IsPositionalValidPassword(int posA, int posB, char c, string password)
        {
            return (password[posA - 1] == c) ^ (password[posB - 1] == c);
        }

        public void ParseRule(out int min, out int max, out char c, out string password, string ruleDescription)
        {
            var initialSplit = ruleDescription.Split(':');
            password = initialSplit.Last();
            password = password.Trim();

            var rule = initialSplit.First();
            var ruleSplit = rule.Split(' ');
            c = ruleSplit.Last().First();

            var constraints = ruleSplit.First();
            var minMax = constraints.Split('-');
            min = Convert.ToInt32(minMax.First());
            max = Convert.ToInt32(minMax.Last());
        }

        public int CountValidInFileMinMax(string filename)
        {
            var rules = File.ReadAllLines(filename);

            var runningTotal = 0;
            foreach (var rule in rules)
            {
                int min, max;
                char c;
                string password;

                ParseRule(out min, out max, out c, out password, rule);

                if (IsMinMaxValidPassword(min, max, c, password)) runningTotal++;
            }

            return runningTotal;
        }

        public int CountValidInFilePositional(string filename)
        {
            var rules = File.ReadAllLines(filename);

            var runningTotal = 0;
            foreach (var rule in rules)
            {
                int min, max;
                char c;
                string password;

                ParseRule(out min, out max, out c, out password, rule);

                if (IsPositionalValidPassword(min, max, c, password)) runningTotal++;
            }

            return runningTotal;
        }
    }
}
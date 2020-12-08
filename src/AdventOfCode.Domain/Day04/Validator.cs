using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Domain.Day04
{
    public class PassportField
    {
        public PassportField(string code, string value)
        {
            Code = code.Trim().ToUpper();
            Value = value;
        }

        public string Code { get; }
        public string Value { get; }
    }

    public class Validator
    {
        public IEnumerable<PassportField> PassportFields(string rawPassport)
        {
            return SplitString(rawPassport)
                .Select(ExtractPassportField);
        }

        public PassportField ExtractPassportField(string str)
        {
            if (!str.Contains(':')) throw new ArgumentException("String cannot be converted to a Passport Field");

            var strArray = str.Split(':');
            return new PassportField(strArray[0], strArray[1]);
        }

        public IEnumerable<string> SplitString(string content)
        {
            return content.Split()
                .Select(str => str.Trim())
                .Where(str => str.Length > 0);
        }

        public IEnumerable<IEnumerable<PassportField>> ParsePassports(string str)
        {
            str = Regex.Replace(str, " +", " ");

            var rawPassports = Regex.Split(str, "\\s{2,}", RegexOptions.CultureInvariant);
            foreach (var rawPassport in rawPassports)
            {
                var passportFields = PassportFields(rawPassport);

                yield return passportFields;
            }
        }

        public int CountValid(string rawPassports)
        {
            var runningTotal = 0;
            foreach (var parsedPassport in ParsePassports(rawPassports))
            {
            }

            return runningTotal;
        }

        public bool IsValid(IEnumerable<PassportField> passportFields)
        {
            IEnumerable<string> requiredFields = new[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
            IEnumerable<string> validEcl = new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};

            requiredFields = requiredFields.Select(str => str.Trim().ToUpper());
            var cnt = passportFields.Count(ppf => requiredFields.Contains(ppf.Code));
            if (cnt >= requiredFields.Count())
            {
            }

            return false;
        }
    }
}
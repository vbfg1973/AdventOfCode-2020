using System;
using System.IO;
using System.Linq;
using AdventOfCode.Domain.Day04;
using Xunit;

namespace AdventOfCode.Tests
{
    public class AdventOfCode_Day04Tests
    {
        [Theory]
        [InlineData("a b c", 3)]
        [InlineData("a\nb\tc", 3)]
        [InlineData("a\n\nb\t\tc", 3)]
        [InlineData("a\n\tb\t\nc", 3)]
        public void StringsplitsAcrossMultipleVariationsOfWhitespace(string str, int expectedCount)
        {
            var validator = new Validator();
            var actualCount = validator.SplitString(str).Count();

            Assert.Equal(expectedCount, actualCount);
        }

        [Theory]
        [InlineData("ABC:1234", "ABC", "1234")]
        [InlineData("abc:1234", "ABC", "1234")]
        [InlineData("abc :1234", "ABC", "1234")]
        public void StringConvertsToPassportField(string rawPassportField, string expectedCode, string expectedValue)
        {
            var validator = new Validator();
            var passportField = validator.ExtractPassportField(rawPassportField);
            Assert.Equal(expectedCode, passportField.Code);
            Assert.Equal(expectedValue, passportField.Value);
        }

        [Theory]
        [InlineData("ABC1234")]
        public void ValidatorThrowsOnInvalidPassportField(string rawPassportField)
        {
            var validator = new Validator();
            Assert.Throws<ArgumentException>(() =>
            {
                var passportField = validator.ExtractPassportField(rawPassportField);
            });
        }

        [Theory]
        [InlineData("abc:123 def:1010", 2)]
        [InlineData("abc:123\ndef:1010", 2)]
        [InlineData("abc:123\n\tdef:1010", 2)]
        [InlineData("abc:123\t\ndef:1010", 2)]
        public void ParseSimplePassword(string rawPassport, int expectedFieldCount)
        {
            var validator = new Validator();
            var passportFields = validator.PassportFields(rawPassport);
            Assert.Equal(expectedFieldCount, passportFields.Count());
        }

        [Theory]
        [InlineData("abc:123 def:1010\n\nabc:123 def:1010\n\nabc:123 def:1010\n\nabc:123 def:1010", 4)]
        public void CountOfPassportsIsCorrect(string fileName, int expectedCount)
        {
            var validator = new Validator();
            Assert.Equal(expectedCount, validator.ParsePassports(fileName).Count());
        }
        
        [Theory]
        [InlineData("Day04.Example.txt", 2)]
        public void CountOfPassportsInFileIsCorrect(string fileName, int expectedCount)
        {
            var rawPassports = File.ReadAllText(fileName);
            var validator = new Validator();
            Assert.Equal(expectedCount, validator.CountValid(rawPassports));
        }
    }
}
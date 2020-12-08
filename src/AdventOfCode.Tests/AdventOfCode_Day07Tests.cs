using System.Linq;
using AdventOfCode.Domain.Day07;
using Xunit;

namespace AdventOfCode.Tests
{
    public class AdventOfCode_Day07Tests
    {
        [Theory]
        [InlineData("1 shiny gold bag.", 1, "shiny gold bag")]
        [InlineData("2 shiny gold bags.", 2, "shiny gold bag")]
        public void ParseBagQuantity(string rule, int expectedQty, string expectedType)
        {
            var bagQ = BagRuleParser.BagQuantityParseRule(rule);
            Assert.Equal(expectedQty, bagQ.Quantity);
            Assert.Equal(expectedType, bagQ.BagType);
        }

        [Theory]
        [InlineData("bright white bags contain no other bags.", "bright white bag", 0)]
        [InlineData("bright white bags contain 1 shiny gold bag.", "bright white bag", 1)]
        [InlineData("muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.", "muted yellow bag", 2)]
        public void BasicBagRuleParserTest(string rule, string expectedMainBagName, int expectedSubRules)
        {
            var bagRule = BagRuleParser.ParseRule(rule);
            Assert.Equal(expectedMainBagName, bagRule.BagType);
            Assert.Equal(expectedSubRules, bagRule.BagQuantities.Count());
        }
    }
}
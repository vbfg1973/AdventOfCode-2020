using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Domain.Day07
{
    public static class BagRuleParser
    {
        public static BagRule ParseRule(string rawBagRule)
        {
            Regex mainRule = new Regex(@"^(?<enclosingBag>.*) contain (?<rule>.*)$");

            rawBagRule = rawBagRule.Trim();
            var match = mainRule.Match(rawBagRule);
            var bagRule = new BagRule(match.Groups["enclosingBag"].Value);

            var enclosedRule = match.Groups["rule"].Value;

            if (enclosedRule == "no other bags.") return bagRule;

            foreach (var subRule in match.Groups["rule"].Value.Split(','))
            {
                bagRule.AddBagQuantity(BagRuleParser.BagQuantityParseRule(subRule));
            }

            return bagRule;
        }

        public static BagQuantity BagQuantityParseRule(string bagQuantityRule)
        {
            bagQuantityRule = bagQuantityRule.Trim();
            Regex mainRule = new Regex(@"^(?<quantity>\d+) (?<bagtype>.*)$");
            var m = mainRule.Match(bagQuantityRule);

            var bagType = m.Groups["bagtype"].Value;

            var qty = Convert.ToInt32(m.Groups["quantity"].Value);
            return new BagQuantity(qty, bagType);
        }
    }
}
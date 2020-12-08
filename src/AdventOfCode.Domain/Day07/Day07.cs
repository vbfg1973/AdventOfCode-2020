using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BagMap = System.Collections.Generic.Dictionary<string, (string name, int count)[]>;

namespace AdventOfCode.Domain.Day07
{
    public class Day07
    {
        private readonly string _filename;
        private BagMap _bagMap;

        public Day07(string filename)
        {
            _filename = filename;

            _bagMap = ReadBagMap();
        }

        private BagMap ReadBagMap()
        {
            var lineRegex =
                new Regex(@"^(?<outer_bag>[a-z ]+) bags contain (?<bags>(((\d+[a-z ]+)|no other) bags?(, )?)*)\.$",
                    RegexOptions.Compiled);
            var bagRegex = new Regex(@"^(?<number>\d+) (?<name>[a-z ]+) bags?$", RegexOptions.Compiled);

            var bagMap = File.ReadAllLines(_filename)
                .Select(l => lineRegex.Match(l))
                .ToDictionary(
                    k => k.Groups["outer_bag"].Value,
                    v => v.Groups["bags"].Value.Trim() == "no other bags" // Test no other bags contained
                        ? new (string, int)[0] // Empty if no contained bags
                        : v.Groups["bags"].Value // Parse contained bag rule
                            .Split(',')
                            .Select(b => bagRegex.Match(b.Trim()))
                            .Select(b => (b.Groups["name"].Value, int.Parse(b.Groups["number"].Value)))
                            .ToArray());

            return bagMap;
        }

        private bool CanContain(BagMap map, string containingColor, string containedColor) =>
            map[containingColor].Any(b => b.name == containedColor || CanContain(map, b.name, containedColor));
        
        private int BagsContained(BagMap map, string containingColor) =>
            map[containingColor].Sum(b => b.count + b.count * BagsContained(map, b.name));
        
        public int Solve_1() =>
            _bagMap.Keys.Count(b => CanContain(_bagMap, b, "shiny gold"));
        
        public int Solve_2() =>
            BagsContained(_bagMap, "shiny gold");
    }
}
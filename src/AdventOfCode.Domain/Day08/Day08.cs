using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Domain.Day08
{
    public class Day08
    {
        private IList<Instruction> _instructions;

        public Day08()
        {
            _instructions = new List<Instruction>();
        }

        public void LoadFromFile(string filename)
        {
            Load(File.ReadAllLines(filename).Select(str => str.Trim()));
        }

        public void Load(IEnumerable<string> rawInstructions)
        {
            var rx = new Regex(@"(?<operation>\w{3}) (?<operand>[\+\-])(?<value>\d+)", RegexOptions.Compiled);

            _instructions = rawInstructions
                .Select(inst => rx.Match(inst))
                .Select(match =>
                    new Instruction(match.Groups["operation"].Value,
                        match.Groups["operand"].Value,
                        int.Parse(match.Groups["value"].Value)))
                .ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace AdventOfCode.Domain.Day08
{
    public class Day08
    {
        private IList<Instruction> _instructions;
        private int _accumulator;

        public Day08()
        {
            _accumulator = 0;
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

        public int Run()
        {
            for (int i = 0; i <= _instructions.Count; i++)
            {
                var instruction = _instructions[i];

                if (instruction.Runs > 0)
                {
                    break;
                }

                else
                {
                    switch (instruction.Operation)
                    {
                        case Operation.nop:
                            break;
                        case Operation.jmp:
                            i = Jmp(instruction, i);
                            break;
                        case Operation.acc:
                            _accumulator = Acc(instruction, _accumulator);
                            break;
                    }
                }

                instruction.AddRun();
            }

            return _accumulator;
        }

        private int Jmp(Instruction instruction, int i)
        {
            switch (instruction.Operand)
            {
                case "-":
                    i -= instruction.Value;
                    break;
                case "+":
                    i += instruction.Value;
                    break;
                default:
                    throw new ArgumentException(
                        $"Invalid operation: {JsonConvert.SerializeObject(instruction)}");
                    break;
            }

            return i;
        }
        
        private int Acc(Instruction instruction, int acc)
        {
            switch (instruction.Operand)
            {
                case "-":
                    acc -= instruction.Value;
                    break;
                case "+":
                    acc += instruction.Value;
                    break;
                default:
                    throw new ArgumentException(
                        $"Invalid operation: {JsonConvert.SerializeObject(instruction)}");
            }

            return acc;
        }
    }
}

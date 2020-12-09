using System;

namespace AdventOfCode.Domain.Day08
{
    public class Instruction
    {
        public Operation Operation { get; }
        public string Operand { get; }
        public int Value { get; }
        public int Runs { get; private set; }

        public Instruction(string operation, string operand, int value)
        {
            Operation = ParseOperation(operation);
            Operand = operand;
            Value = value;
            Runs = 0;
        }

        public void AddRun()
        {
            Runs++;
        }

        private Operation ParseOperation(string op)
        {
            switch (op)
            {
                case "nop":
                    return Operation.nop;
                case "jmp":
                    return Operation.jmp;
                case "acc":
                    return Operation.acc;
                default:
                    throw new ArgumentException($"Not a defined operation: {op}");
            }
        }
    }
}
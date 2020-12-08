using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain.Day03
{
    public class Day03Runner
    {
        public void Run(string filename)
        {
            var map = new Map();
            map.ReadFile(filename);

            var treeCounts = new List<int>();

            var movements = new List<Tuple<int, int, int>>
            {
                new Tuple<int, int, int>(0, 1, 1),
                new Tuple<int, int, int>(0, 3, 1),
                new Tuple<int, int, int>(0, 5, 1),
                new Tuple<int, int, int>(0, 7, 1),
                new Tuple<int, int, int>(0, 1, 2)
            };

            foreach (var moves in movements)
            {
                var commands = GenerateMovementCommands(moves.Item1, moves.Item2, moves.Item3);
                var treeCount = map.CountTreesFollowingMovements(commands);
                treeCounts.Add(treeCount);
                map.ResetPosition();
            }

            foreach (var trees in treeCounts) Console.WriteLine(trees);

            var product = treeCounts.Aggregate(1, (acc, val) => acc * val);
            Console.WriteLine($"Product: {product}");
        }

        private static IList<Movement> GenerateMovementCommands(int left, int right, int down)
        {
            var movementCommands = new List<Movement>();
            movementCommands.AddRange(Enumerable.Repeat(Movement.Left, left));
            movementCommands.AddRange(Enumerable.Repeat(Movement.Right, right));
            movementCommands.AddRange(Enumerable.Repeat(Movement.Down, down));

            return movementCommands;
        }
    }
}
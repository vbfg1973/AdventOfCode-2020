using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Domain.Day03;
using Xunit;

namespace AdventOfCode.Tests
{
    public class AdventOfCode_Day03Tests
    {
        [Theory]
        [InlineData(3, 4)]
        [InlineData(1, 1)]
        [InlineData(100, 2000)]
        public void GivenStringDimensionsAreCorrect(int width, int height)
        {
            var map = GenerateMap(width, height);

            Assert.Equal(width, map.Width());
            Assert.Equal(height, map.Height());
        }

        [Theory]
        [InlineData(3, 3, 1, 2)]
        [InlineData(3, 3, 2, 3)]
        [InlineData(3, 3, 3, 1)]
        public void RightMovement(int width, int height, int start, int expected)
        {
            var map = GenerateMap(width, height);
            map.X(start);
            map.Right();
            Assert.Equal(expected, map.X());
        }
        
        [Theory]
        [InlineData(3, 3, 1, 2)]
        [InlineData(3, 3, 2, 3)]
        [InlineData(3, 3, 3, 1)]
        public void RightMovementCommand(int width, int height, int start, int expected)
        {
            var map = GenerateMap(width, height);
            map.X(start);

            var commands = new List<Movement>() {Movement.Right};
            map.MovementCommand(commands);
            
            Assert.Equal(expected, map.X());
        }

        [Theory]
        [InlineData(3, 3, 3, 2)]
        [InlineData(3, 3, 2, 1)]
        [InlineData(3, 3, 1, 3)]
        public void LeftMovement(int width, int height, int start, int expected)
        {
            var map = GenerateMap(width, height);
            map.X(start);
            map.Left();
            Assert.Equal(expected, map.X());
        }
        
        [Theory]
        [InlineData(3, 3, 3, 2)]
        [InlineData(3, 3, 2, 1)]
        [InlineData(3, 3, 1, 3)]
        public void LeftMovementCommand(int width, int height, int start, int expected)
        {
            var map = GenerateMap(width, height);
            map.X(start);
            
            var commands = new List<Movement>() {Movement.Left};
            map.MovementCommand(commands);
            
            Assert.Equal(expected, map.X());
        }

        [Theory]
        [InlineData(3, 3, 1, 2)]
        [InlineData(3, 3, 2, 3)]
        public void DownMovement(int width, int height, int start, int expected)
        {
            var map = GenerateMap(width, height);
            map.Y(start);
            map.Down();
            Assert.Equal(expected, map.Y());
        }
        
        [Theory]
        [InlineData(3, 3, 1, 2)]
        [InlineData(3, 3, 2, 3)]
        public void DownMovementCommand(int width, int height, int start, int expected)
        {
            var map = GenerateMap(width, height);
            map.Y(start);
            
            var commands = new List<Movement>() {Movement.Down};
            map.MovementCommand(commands);
            
            Assert.Equal(expected, map.Y());
        }

        [Theory]
        [InlineData(3, 3, 1, true)]
        [InlineData(3, 3, 2, true)]
        [InlineData(3, 3, 3, false)]
        public void DownMovementAbleTo(int width, int height, int start, bool expected)
        {
            var map = GenerateMap(width, height);
            map.Y(start);
            var response = map.Down();
            Assert.Equal(expected, response);
        }
        
        [Theory]
        [InlineData(3, 3, 1, true)]
        [InlineData(3, 3, 2, true)]
        [InlineData(3, 3, 3, false)]
        public void DownMovementAbleToCommand(int width, int height, int start, bool expected)
        {
            var map = GenerateMap(width, height);
            map.Y(start);
            
            var commands = new List<Movement>() {Movement.Down};
            var response = map.MovementCommand(commands);
            
            Assert.Equal(expected, response);
        }
        
        [Theory]
        [InlineData("Day03.Trees.Part01.txt", 1, 1, Terrain.Open)]
        [InlineData("Day03.Trees.Part01.txt", 2, 1, Terrain.Open)]
        [InlineData("Day03.Trees.Part01.txt", 3, 1, Terrain.Tree)]
        [InlineData("Day03.Trees.Part01.txt", 1, 2, Terrain.Tree)]
        [InlineData("Day03.Trees.Part01.txt", 1, 3, Terrain.Open)]
        public void GivenTestInputTerrainAtPositionIsCorrect(string path, int x, int y, Terrain expectedTerrain)
        {
            var map = new Map();
            map.ReadFile(path);

            map.X(x);
            map.Y(y);
            Assert.Equal(expectedTerrain, map.TerrainAtPosition());
        }
        
        [Theory]
        [InlineData("Day03.Trees.Part01.txt", 0, 1, 1, 2)]
        [InlineData("Day03.Trees.Part01.txt", 0, 3, 1, 7)]
        [InlineData("Day03.Trees.Part01.txt", 0, 5, 1, 3)]
        [InlineData("Day03.Trees.Part01.txt", 0, 7, 1, 4)]
        [InlineData("Day03.Trees.Part01.txt", 0, 1, 2, 2)]
        public void CountTreesOnRepeatedIssuingOfCommands(string path, int left, int right, int down, int expectedTrees)
        {
            var map = new Map();
            map.ReadFile(path);

            var commands = new List<Movement>();
            commands.AddRange(Enumerable.Repeat(Movement.Left, left));
            commands.AddRange(Enumerable.Repeat(Movement.Right, right));
            commands.AddRange(Enumerable.Repeat(Movement.Down, down));

            var actualTrees = map.CountTreesFollowingMovements(commands);
            
            Assert.Equal(expectedTrees, actualTrees);
        }
        
        private Map GenerateMap(int width, int height)
        {
            var list = new List<string>();
            var s = new string('-', width);

            for (var i = 0; i < height; i++) list.Add(s);

            var map = new Map();
            map.ReadMap(list);

            return map;
        }

        [Fact]
        public void GivenEmptyStringDimensionsAreCorrect()
        {
            var map = new Map();

            Assert.Equal(0, map.Width());
            Assert.Equal(0, map.Height());
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Domain.Day03
{
    public enum Terrain
    {
        Open,
        Tree,
        Unknown
    }

    public enum Movement
    {
        Left,
        Right,
        Down
    }

    public class Map
    {
        private int _currX;
        private int _currY;
        private IList<IList<char>> _map;

        public Map()
        {
            _map = new List<IList<char>>();
            ResetPosition();
        }

        public void ResetPosition()
        {
            _currX = 0;
            _currY = 0;
        }

        public void ReadMap(IList<string> map)
        {
            _map = new List<IList<char>>();
            foreach (var line in map)
            {
                var newRow = new List<char>();
                _map.Add(newRow);

                foreach (var c in line) newRow.Add(c);
            }
        }

        public void ReadFile(string path)
        {
            var lines = File.ReadAllLines(path);
            var list = new List<string>();

            foreach (var line in lines) list.Add(line);

            ReadMap(list);
        }

        public bool MovementCommand(IList<Movement> commands)
        {
            var downs = commands.Count(move => move == Movement.Down);

            if (_currY + downs <= Height() - 1)
            {
                foreach (var down in commands.Where(move => move == Movement.Down)) Down();

                foreach (var left in commands.Where(move => move == Movement.Left)) Left();

                foreach (var right in commands.Where(move => move == Movement.Right)) Right();

                return true;
            }

            return false;
        }

        public int CountTreesFollowingMovements(IList<Movement> commands)
        {
            var trees = 0;

            while (MovementCommand(commands))
                switch (TerrainAtPosition())
                {
                    case Terrain.Tree:
                        trees++;
                        break;
                }

            return trees;
        }

        public Terrain TerrainAtPosition()
        {
            switch (_map[_currY][_currX])
            {
                case '.': return Terrain.Open;
                case '#': return Terrain.Tree;
                default: return Terrain.Unknown;
            }
        }

        #region Positional

        public int Height()
        {
            return _map.Count;
        }

        public int Width()
        {
            if (Height() >= 1)
                return _map.First().Count;

            return 0;
        }

        public int X()
        {
            return _currX + 1;
        }

        public int Y()
        {
            return _currY + 1;
        }

        public int X(int x)
        {
            _currX = x - 1;
            return X();
        }

        public int Y(int y)
        {
            _currY = y - 1;
            return Y();
        }

        public void Left()
        {
            _currX = _currX == 0 ? Width() - 1 : _currX - 1;
        }

        public void Right()
        {
            _currX = _currX == Width() - 1 ? 0 : _currX + 1;
        }

        public bool Down()
        {
            if (CanDown())
            {
                _currY++;
                return true;
            }

            return false;
        }

        public bool CanDown()
        {
            return _currY < Height() - 1;
        }

        #endregion
    }
}
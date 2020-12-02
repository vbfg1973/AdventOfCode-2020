using System.Collections.Generic;

namespace AdventOfCode.Domain
{
    public interface IInputProvider
    {
        IEnumerable<T> GetInput<T>();
    }
}
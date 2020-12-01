﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public static class Combinations
    {
        public static IEnumerable<IEnumerable<T>> GetKCombs<T>(this IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0), 
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}

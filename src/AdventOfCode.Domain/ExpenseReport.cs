using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class ExpenseReport
    {
        private int _combinationSize = 2;

        public IEnumerable<int> GetSummableTo(IEnumerable<int> list, int finalSum)
        {
            return list.GetKCombs(_combinationSize)
                .FirstOrDefault(combination => combination.Sum() == finalSum);
        }

        public int GetProduct(IEnumerable<int> list, int finalSum)
        {
            var res = GetSummableTo(list, finalSum).ToList();
            if (res.Count() == _combinationSize)
            {
                return res[0] * res[1];
            }

            throw new ArgumentException($"No combinations found that sum top {finalSum}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class ExpenseReport
    {
        public IEnumerable<int> GetSummableTo(IEnumerable<int> list, int finalSum, int combinationSize)
        {
            return list.GetKCombs(combinationSize)
                .FirstOrDefault(combination => combination.Sum() == finalSum);
        }

        public int GetProduct(IEnumerable<int> list, int finalSum, int combinationSize)
        {
            var res = GetSummableTo(list, finalSum, combinationSize).ToList();

            if (res.Count() >= 2) return res.Aggregate(1, (acc, listItem) => acc * listItem);

            throw new ArgumentException($"No combinations found that sum top {finalSum}");
        }
    }
}
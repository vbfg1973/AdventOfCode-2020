﻿using System;
using System.IO;
using System.Linq;
using AdventOfCode.Domain;

namespace AdventOfCode.Cli.Days
{
    public class Day01
    {
        private readonly ExpenseReport _expenseReport;

        public Day01()
        {
            _expenseReport = new ExpenseReport();
        }

        public int Run(int combinationSize, string fileName)
        {
            var numbers = File.ReadAllLines(fileName)
                .Select(x => Convert.ToInt32(x));

            return _expenseReport.GetProduct(numbers, 2020, combinationSize);
        }
    }
}
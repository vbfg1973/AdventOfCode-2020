using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Domain;
using AdventOfCode.Tests.Generators;
using Xunit;

namespace AdventOfCode.Tests
{
    public class AdventOfCode_Day1Tests
    {
        [Theory]
        [MemberData(nameof(DayOneDataGenerator.CombinationData), MemberType = typeof(DayOneDataGenerator))]
        public void CombinationsTests(int combinationSize, int count, IEnumerable<int> numbers)
        {
            var res = numbers.GetKCombs(combinationSize);
            Assert.Equal(count, res.Count());
        }

        [Theory]
        [MemberData(nameof(DayOneDataGenerator.FinalSumData_Part01), MemberType = typeof(DayOneDataGenerator))]
        [MemberData(nameof(DayOneDataGenerator.FinalSumData_Part02), MemberType = typeof(DayOneDataGenerator))]
        public void SummingTests(int combinationSize, IEnumerable<int> numbers, IEnumerable<int> expectedCombination, int finalSum)
        {
            var expenseReport = new ExpenseReport();
            var res = expenseReport.GetSummableTo(numbers, finalSum, combinationSize);
            
            Assert.Equal(expectedCombination.Count(), res.Count());

            foreach (var i in expectedCombination)
            {
                Assert.Contains(i, res);
            }
            
            Assert.Equal(finalSum, res.Sum());
        }
        
        [Theory]
        [MemberData(nameof(DayOneDataGenerator.FinalProductData_Part01), MemberType = typeof(DayOneDataGenerator))]
        [MemberData(nameof(DayOneDataGenerator.FinalProductData_Part02), MemberType = typeof(DayOneDataGenerator))]
        public void ProductTests(int combinationSize, IEnumerable<int> numbers, int finalSum, int finalProduct)
        {
            var expenseReport = new ExpenseReport();
            var res = expenseReport.GetProduct(numbers, finalSum, combinationSize);

            Assert.Equal(finalProduct, res);
        }
    }
}
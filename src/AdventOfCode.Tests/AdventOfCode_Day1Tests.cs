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
        public void CombinationsTests(int size, int count, IEnumerable<int> numbers)
        {
            var res = numbers.GetKCombs(size);
            Assert.Equal(count, res.Count());
        }

        [Theory]
        [MemberData(nameof(DayOneDataGenerator.FinalSumData), MemberType = typeof(DayOneDataGenerator))]
        public void SummingTests(IEnumerable<int> numbers, IEnumerable<int> expectedCombination, int finalSum)
        {
            var expenseReport = new ExpenseReport();
            var res = expenseReport.GetSummableTo(numbers, finalSum);
            
            Assert.Equal(expectedCombination.Count(), res.Count());

            foreach (var i in expectedCombination)
            {
                Assert.Contains(i, res);
            }
            
            Assert.Equal(finalSum, res.Sum());
        }
        
        [Theory]
        [MemberData(nameof(DayOneDataGenerator.FinalProductData), MemberType = typeof(DayOneDataGenerator))]
        public void ProductTests(IEnumerable<int> numbers, int finalSum, int finalProduct)
        {
            var expenseReport = new ExpenseReport();
            var res = expenseReport.GetProduct(numbers, finalSum);

            Assert.Equal(finalProduct, res);
        }
    }
}
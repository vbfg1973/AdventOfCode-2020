using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain.Day07
{
    public class BagRule
    {
        private readonly IList<BagQuantity> _quantities;

        public BagRule(string bagType)
        {
            bagType = bagType.CleanBagName();
            
            _quantities = new List<BagQuantity>();
            BagType = bagType;
        }

        public string BagType { get; }
        public IEnumerable<BagQuantity> BagQuantities => _quantities;

        public void AddBagQuantity(BagQuantity bagQuantity)
        {
            _quantities.Add(bagQuantity);
        }
    }
}
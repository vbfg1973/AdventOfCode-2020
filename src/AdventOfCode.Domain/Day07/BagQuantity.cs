using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Domain.Day07
{
    public class BagQuantity
    {
        public string BagType { get; }
        public int Quantity { get; }

        public BagQuantity(int quantity, string bagType)
        {
            Quantity = quantity;
            BagType = bagType.CleanBagName();
        }
    }
}
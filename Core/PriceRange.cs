using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PriceRange
    {
        public double StartPrice { get; set; }
        public double EndPrice { get; set; }

        public PriceRange(double startPrice, double endPrice)
        {
            StartPrice = startPrice;
            EndPrice = endPrice;
        }
        public PriceRange(string priceRange)
        {
            var prices = priceRange.Split('-');
            StartPrice = double.Parse(prices[0].Substring(1,4));
            EndPrice = double.Parse(prices[1].Substring(2, 4));
        }

        public string GetRange() => "$" + StartPrice + " - " + "$" + EndPrice;

        public bool IsInRange(string price)
        {
            var newPrice = double.Parse(price.Substring(1));
            return newPrice>=StartPrice||newPrice<=EndPrice;
        }
    }
}

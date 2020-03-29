using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ProductRowStorage
    {
        public double TotalPrice { get; set; }
        public double UnitPrice { get; set; }
        public double QtyValue { get; set; }

        public ProductRowStorage(ProductRow product)
        {
            TotalPrice = product.GetTotalPrice();
            UnitPrice = product.GetUnitPrice();
            QtyValue = product.QtyBox.GetQtyValue();

        }
    }
}

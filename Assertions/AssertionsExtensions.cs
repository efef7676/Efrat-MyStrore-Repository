using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assertions
{
    public static class AssertionsExtensions
    {
        public static CatalogAssertions Should(this CatalogPage instance)
        {
            return new CatalogAssertions(instance);
        }

        public static CartAssertions Should(this CartPage instance)
        {
            return new CartAssertions(instance);
        }

        public static GeneralProductAssertions Should(this GeneralProduct instance)
        {
            return new GeneralProductAssertions(instance);
        }

        public static ProductListAssertions Should(this List<Product> instance)
        {
            return new ProductListAssertions(instance);
        }
    }
}

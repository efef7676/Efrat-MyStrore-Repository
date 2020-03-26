using FluentAssertions;
using FluentAssertions.Primitives;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assertions
{
    public class CatalogAssertions : ObjectAssertions
    {
        public CatalogAssertions(CatalogPage value) : base(value)
        {
        }
        protected override string Identifier => "CatalogAssertions";

        [CustomAssertion]
        public AndConstraint<CatalogAssertions> BeExistsInViewedProductsList(Uri expectedImageUri)
        {
            (Subject as CatalogPage)
                .ViewedProductsComponent
                .GetProductBy(expectedImageUri)
                .Should().NotBeNull();
            return new AndConstraint<CatalogAssertions>(this);
        }

    }
}

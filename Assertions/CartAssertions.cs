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
    public class CartAssertions : ObjectAssertions
    {
        protected override string Identifier => "CartAssertions";

        public CartAssertions(CartPage value) : base(value)
        {
        }

        [CustomAssertion]
        public AndConstraint<CartAssertions> BeExistsInCart(Uri expectedImageUri)
        {
            (Subject as CartPage)
                .GetProductBy(expectedImageUri)
                .Should().NotBeNull();

            return new AndConstraint<CartAssertions>(this);
        }

        [CustomAssertion]
        public AndConstraint<CartAssertions> BeDeletedSuccessfully(Uri expectedImageUri)
        {
            (Subject as CartPage)
                .GetProductBy(expectedImageUri)
                .Should().BeNull();

            return new AndConstraint<CartAssertions>(this);
        }
    }
}

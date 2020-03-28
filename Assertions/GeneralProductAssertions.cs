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
    public class GeneralProductAssertions : ObjectAssertions
    {
        protected override string Identifier => "GeneralProductAssertions";

        public GeneralProductAssertions(GeneralProduct value) : base(value)
        {
        }

        [CustomAssertion]
        public AndConstraint<GeneralProductAssertions> BeChangeQtySuccessfully(bool raisePrice, int originQtyValue, double originPrice, int changeIn = 1)
        {
            if (raisePrice)
            {
                (Subject as ProductRow)
                                .GetPrice()
                                .Should()
                                .Be((originQtyValue + changeIn) * originPrice);

            }else
            {
                (Subject as ProductRow)
                                .GetPrice()
                                .Should()
                                .Be((originQtyValue - changeIn) * originPrice);
            }

            return new AndConstraint<GeneralProductAssertions>(this);
        }
    }
}

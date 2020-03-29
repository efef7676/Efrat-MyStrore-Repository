﻿using FluentAssertions;
using FluentAssertions.Primitives;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assertions
{
    public class ProductListAssertions : ObjectAssertions
    {
        protected override string Identifier => "ProductListAssertions";

        public ProductListAssertions(List<Product> value) : base(value)
        {
        }

        [CustomAssertion]
        public AndConstraint<ProductListAssertions> BeBySelectedColor(Color expectedColor)
        {
            (Subject as List<Product>)
               .TrueForAll(a => a.GetColors().Contains(expectedColor))
               .Should()
               .BeTrue();

            return new AndConstraint<ProductListAssertions>(this);
        }
    }
}

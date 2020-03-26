using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Infrastructure;
using Assertions;

namespace Tests
{
    [TestClass]
    public class CatalogPageTests : BaseTest
    {
        [TestMethod]
        public void SelectProductByColor_ShowTheProductWithThisColor()
        {
            var selectedProduct = HomePage.Categories.ClickOnWomen().StandOnProduct(0);

            selectedProduct.GetColor(0)
                .Should()
                .Be(selectedProduct.ClickOnColor(0)
                .GetSelectedColor());
        }

        [TestMethod]
        public void ViewedProduct_ShouldExistsInViewedProductsList()
        {
            var productToView = HomePage.Categories.ClickOnWomen()
                .StandOnProduct(0);
            var expectedImageUri = productToView.GetImageUri();

            productToView.ClickOnName()
                .ClickOnMainLogo()
                 .Categories.ClickOnWomen()
                 .Should()
                 .BeExistsInViewedProductsList(expectedImageUri);
        }
        [TestMethod]
        public void AddProductToCart_ThisProductExistsInCart()
        {
            var selectedProduct = HomePage.Categories.ClickOnWomen()
                .StandOnProduct(0);
            var expectedImageUri = selectedProduct.GetImageUri();

            (selectedProduct.ClickOnAddToCart(false) as CartPage)
                .Should()
                .BeExistsInCart(expectedImageUri);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure;
using FluentAssertions;
using System.Threading;
using Assertions;
using System.Data;

namespace Tests
{
    [TestClass]
    public class CartPageTests : BaseTest
    {
        [TestMethod]
        public void DeleteProductFromCart_WillSuccess()
        {
            var productToAdd = HomePage.Categories.ClickOnWomen()
               .StandOnProduct(0);
            var expectedImageUri = productToAdd.GetImageUri();

            (productToAdd.ClickOnAddToCart(false) as CartPage)
                .DeleteProductBy(expectedImageUri)
                .Should()
                .BeDeletedSuccessfully(expectedImageUri);
        }

        [TestMethod]
        public void AddToQtyOfExistsProduct_WillSuccess()
        {
            var productToAdd = HomePage.Categories.ClickOnWomen()
               .StandOnProduct(0);
            var expectedImageUri = productToAdd.GetImageUri();
            var currentCartPage = (productToAdd.ClickOnAddToCart(false) as CartPage);
            var originPrice = currentCartPage.GetProductBy(expectedImageUri).GetPrice();
            var originQtyValue = currentCartPage.ChangeQtyOneMore(RaiseQty: true, imageUri: expectedImageUri).QtyBox.GetQtyValue();
            //class of productRowStorge?

            currentCartPage
                .ChangeQtyOneMore(true, expectedImageUri)
                .Should()
                .BeChangeQtySuccessfully(true, originQtyValue, originPrice);
        }

        [TestMethod]
        public void ChangeQtyToIrrationalNumber_WillFail()
        {
            var productToAdd = HomePage.Categories.ClickOnWomen()
              .StandOnProduct(1);
            var expectedImageUri = productToAdd.GetImageUri();
            var currentCartPage = (productToAdd.ClickOnAddToCart(false) as CartPage);

            var originPrice = currentCartPage.GetProductBy(expectedImageUri).GetPrice();
            var originQtyValue = currentCartPage.ChangeQtyOneMore(RaiseQty: true, imageUri: expectedImageUri).QtyBox.GetQtyValue();
            //class of productRowStorge?

        }
    }
}

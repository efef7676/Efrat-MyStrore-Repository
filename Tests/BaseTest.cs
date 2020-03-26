using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using System.Drawing;

namespace Tests
{
    [TestClass]
    public class BaseTest
    {
        protected HomePage HomePage;
        private IWebDriver _driver;
        [TestInitialize]
        public void TestInitialize()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            _driver.Manage().Window.Maximize();
            HomePage = new HomePage(_driver);
        }

        [TestMethod]
        public void TryFirst()
        {
            HomePage.Categories.ClickOnWomen()
                .StandOnProduct(1)
                .ClickOnAddToCart();
        }

        [TestMethod]
        public void TrySecond()
        {
            var selectedProduct = HomePage.Categories.ClickOnWomen()
                .StandOnProduct(0);
            selectedProduct.GetColor(0).Should().Be(selectedProduct.ClickOnColor(0)
                .GetSelectedColor());
        }
        [TestMethod]
        public void TryThird()
        {
            var selectedProduct = HomePage.Categories.ClickOnWomen()
                .StandOnProduct(0).ClickOnImage();
            var viewedProducts = selectedProduct.ClickOnMainLogo()
                 .Categories.ClickOnWomen().ViewedProductsComponent.SummarizedProducts;
            //fluent assertion extension - on url(?), the method gets list<summarizedProducts> and check any url in all
            //or on ViewedProductsComponent and the method should get url.
        }
        [TestMethod]
        public void TryFourth()
        {
            var cartPage = HomePage.Categories.ClickOnWomen()
                .StandOnProduct(0).ClickOnAddToCart(false) as CartPage;
            
        }
        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Close();
        }
    }
}

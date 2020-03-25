﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            var a = HomePage.Categories.ClickOnWomen()
                .Products;
            a[0].StandOnProduct().Products[0].ClickOnAddToCart();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Close();
        }
    }
}

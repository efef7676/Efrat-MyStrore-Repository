﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Extensions;

namespace Infrastructure
{
    public class ProductRow : GeneralProduct
    {
        private IWebElement DeleteButton => ParentElement.WaitAndFindElement(By.CssSelector("td .cart_delete.text-center"));
        private IWebElement Price => ParentElement.WaitAndFindElement(By.CssSelector("td .cart_total span"));
        private IWebElement Image => ParentElement.WaitAndFindElement(By.CssSelector("td .cart_product a"));
        public QtyBox QtyBox => new QtyBox(Driver, ParentElement.WaitAndFindElement(By.CssSelector("td .cart_quantity.text-center")));


        public ProductRow(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public CartPage ClickOnDeleteButton()
        {
            DeleteButton.Click();

            return new CartPage(Driver);
        }

        public string GetPrice => Price.Text;

        public override Uri GetImageUri() => new Uri(Image.GetAttribute("href"));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Extensions;

namespace Infrastructure
{
    public class ProductRow : BaseComponent
    {
        private IWebElement DeleteButton => ParentElement.WaitAndGetElement(By.CssSelector("td .cart_delete.text-center"));
        private IWebElement Price => ParentElement.WaitAndGetElement(By.CssSelector("td .cart_total span"));
        public QtyBox QtyBox => new QtyBox(Driver, ParentElement.WaitAndGetElement(By.CssSelector("td .cart_quantity.text-center")));

        public ProductRow(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public CartPage ClickOnDeleteButton()
        {
            DeleteButton.Click();

            return new CartPage(Driver);
        }

        public string GetPrice => Price.Text;
    }
}

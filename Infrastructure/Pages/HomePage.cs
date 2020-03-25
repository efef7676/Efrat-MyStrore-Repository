using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class HomePage : BasePage
    {
        public Categories Categories => new Categories(Driver, Driver.WaitAndGetElement(By.CssSelector("#block_top_menu ul")));
        private IWebElement CartButton => Driver.WaitAndGetElement(By.CssSelector(".shopping_cart a"));

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public CartPage ClickOnCart()
        {
            CartButton.Click();

            return new CartPage(Driver);
        }
    }
}

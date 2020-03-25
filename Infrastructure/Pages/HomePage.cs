using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class HomePage : BasePage
    {
        public Categories Categories => new Categories(Driver.FindElement(By.CssSelector("#block_top_menu ul")), Driver);
        private IWebElement CartButton => Driver.FindElement(By.CssSelector(".shopping_cart a"));

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickOnCart() => CartButton.Click();
    }
}

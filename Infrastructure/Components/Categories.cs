using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class Categories : BaseComponent
    {
        private IWebElement WomenCategory => Driver.FindElements(By.CssSelector("li a")).FirstOrDefault(el => el.Text == "Women");
        private IWebElement DressesCategory => Driver.FindElements(By.CssSelector("li a")).FirstOrDefault(el => el.Text == "Dresses");
        private IWebElement TShirtsCategory => Driver.FindElements(By.CssSelector("li a")).FirstOrDefault(el => el.Text == "T-shirts");
        public Categories(IWebElement parentElement, IWebDriver driver) : base(parentElement, driver)
        {
        }

        public void ClickOnWomen() => WomenCategory.Click();
    }
}

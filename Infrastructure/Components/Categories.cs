using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Extensions;

namespace Infrastructure
{
    public class Categories : BaseComponent
    {
        private IWebElement WomenCategory => ParentElement.FindElements(By.CssSelector("li a")).FirstOrDefault(el => el.Text == "WOMEN");
        private IWebElement DressesCategory => ParentElement.FindElements(By.CssSelector("li a")).FirstOrDefault(el => el.Text == "Dresses");
        private IWebElement TShirtsCategory => ParentElement.FindElements(By.CssSelector("li a")).FirstOrDefault(el => el.Text == "T-shirts");

        public Categories(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public CatalogPage ClickOnWomen()
        {
            WomenCategory.Click();

            return new CatalogPage(Driver);
        }
    }
}

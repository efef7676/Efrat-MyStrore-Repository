using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class BasePage : DriverUser
    {
        private IWebElement MainLogo => Driver.FindElement(By.CssSelector("#header_logo a"));

        public BasePage(IWebDriver driver) : base(driver)
        {
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class DriverUser
    {
        protected IWebDriver Driver { get; set; }
        public DriverUser(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}

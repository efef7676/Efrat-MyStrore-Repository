using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class BaseComponent : DriverUser
    {
        public IWebElement ParentElement { get; set; }

        public BaseComponent(IWebDriver driver, IWebElement parentElement) : base(driver)
        {
            ParentElement = parentElement;
        }
    }
}

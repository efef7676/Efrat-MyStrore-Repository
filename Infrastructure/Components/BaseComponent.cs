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
        protected IWebElement ParentElement { get; set; }

        public BaseComponent(IWebElement parentElement, IWebDriver driver) : base(driver)
        {
            ParentElement = parentElement;
        }
    }
}

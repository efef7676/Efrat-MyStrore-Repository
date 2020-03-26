using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class GeneralProduct : BaseComponent
    {
        protected abstract IWebElement Image { get; }

        public GeneralProduct(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public abstract Uri GetImageUri();
        public virtual ProductPage ClickOnImage()
        {
            Image.Click();

            return new ProductPage(Driver);
        }
    }
}

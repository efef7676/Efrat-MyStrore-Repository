using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Extensions;

namespace Infrastructure
{
    public class Price : BaseComponent
    {
        private PriceRange PriceRange => new PriceRange(ParentElement.FindElement(By.CssSelector("#layered_price_range")).Text);
        private IWebElement RaisesTheMinPrice => ParentElement.WaitAndGetElement(By.CssSelector("#layered_price_slider a:first-child"));
        private IWebElement LowersTheMaxPrice => ParentElement.WaitAndGetElement(By.CssSelector("#layered_price_slider a:nth-child(2)")); 

        public Price(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }            
    }
}

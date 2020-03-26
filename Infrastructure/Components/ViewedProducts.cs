using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class ViewedProducts : BaseComponent
    {
        public List<SummarizedProduct> SummarizedProducts => ParentElement
            .FindElements(By.CssSelector(".block_content.products-block ul li"))
            .Select(s => new SummarizedProduct(Driver, s)).ToList();
        public ViewedProducts(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }
    }
}

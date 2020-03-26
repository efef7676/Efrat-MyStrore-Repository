using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Extensions;

namespace Infrastructure
{
    public class SummarizedProduct : GeneralProduct
    {
        protected override IWebElement Image => ParentElement.WaitAndFindElement(By.CssSelector("a"));
        private IWebElement Title => ParentElement.WaitAndFindElement(By.CssSelector("h5 a"));
        private IWebElement Description => ParentElement.WaitAndFindElement(By.CssSelector("p .product-description"));

        public SummarizedProduct(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public ProductPage ClickOnTitle()
        {
            Title.Click();

            return new ProductPage(Driver);
        }

        public string GetDescription() => Description.Text;

        public override Uri GetImageUri() => new Uri(Image.GetAttribute("href"));

        public override ProductPage ClickOnImage()=> base.ClickOnImage();
    }
}

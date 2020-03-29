using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Extensions;
using OpenQA.Selenium.Support.UI;

namespace Infrastructure
{
    public class ProductRow : GeneralProduct
    {
        private IWebElement DeleteButton => ParentElement.WaitAndFindElement(By.CssSelector(".cart_delete.text-center a"));
        private IWebElement TotalPrice => ParentElement.WaitAndFindElement(By.CssSelector(".cart_total span"));
        private IWebElement UnitPrice => ParentElement.WaitAndFindElement(By.CssSelector(".cart_unit span span"));
        protected override IWebElement Image => ParentElement.WaitAndFindElement(By.CssSelector(".cart_product a"));
        public QtyBox QtyBox => new QtyBox(Driver, ParentElement.WaitAndFindElement(By.CssSelector(".cart_quantity.text-center")));


        public ProductRow(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public override Uri GetImageUri() => new Uri(Image.GetAttribute("href"));

        public override ProductPage ClickOnImage() => base.ClickOnImage();

        public double GetTotalPrice() => double.Parse(TotalPrice.Text.Substring(1));

        public double GetUnitPrice() => double.Parse(UnitPrice.Text.Substring(1));

        public CartPage ClickOnDeleteButton()
        {
            DeleteButton.Click();

            return new CartPage(Driver);
        }
    }
}

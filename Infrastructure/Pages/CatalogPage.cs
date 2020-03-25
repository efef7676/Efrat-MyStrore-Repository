using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class CatalogPage : BasePage
    {
        public List<Product> Products => Driver.FindElements(By.CssSelector(".product_list.grid.row li .product-container")).Select(s => new Product(Driver, s)).ToList();

        public CatalogPage(IWebDriver driver) : base(driver)
        {
        }
    }
}

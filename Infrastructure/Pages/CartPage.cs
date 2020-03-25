using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class CartPage : BasePage
    {
        public List<ProductRow> Products => Driver.FindElement(By.CssSelector("#cart_summary tbody"))
            .FindElements(By.CssSelector("tr #product_5_19_0_0"))
            .Select(s=> new ProductRow(Driver, s)).ToList();

        public CartPage(IWebDriver driver) : base(driver)
        {
        }
    }
}

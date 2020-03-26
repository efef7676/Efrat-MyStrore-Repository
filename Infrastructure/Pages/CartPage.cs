using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Extensions;

namespace Infrastructure
{
    public class CartPage : BasePage, IHasProducts<ProductRow>
    {
        public List<ProductRow> Products => Driver.WaitAndFindElement(By.CssSelector("#cart_summary tbody"))
            .FindElements(By.CssSelector("tr"))
            .Select(s=> new ProductRow(Driver, s)).ToList();

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public ProductRow GetProductBy(Uri ImagetUri)
        {
           return Products.FirstOrDefault(p => p.GetImageUri() == ImagetUri);
        }
    }
}

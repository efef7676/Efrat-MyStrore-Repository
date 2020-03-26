using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Extensions;

namespace Infrastructure
{
    public class CatalogPage : BasePage, IHasProducts<Product>
    {
        public List<Product> Products => Driver.FindElements(By.CssSelector(".product_list.grid.row li .product-container")).Select(s => new Product(Driver, s)).ToList();

        public ViewedProducts ViewedProductsComponent => new ViewedProducts(Driver, Driver.WaitAndFindElement(By.CssSelector("#viewed-products_block_left")));

        public CatalogPage(IWebDriver driver) : base(driver)
        {
        }

        public Product StandOnProduct(int index=0)
        {
            if(index<= Products.Count)
            {
                Products[index].StandOnProduct();
            }

            return Products[index];
        }

        public CatalogPage NotStandingOnProducts()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(Driver.FindElement(By.CssSelector("#header"))).Perform();

            return new CatalogPage(Driver);
        }

        public Product GetProductBy(Uri uri)
        {
            return Products.FirstOrDefault(p => p.GetImageUri() == uri);
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Extensions;
using OpenQA.Selenium.Interactions;

namespace Infrastructure
{
    public class Product : BaseComponent
    {
        private List<IWebElement> Colors => ParentElement.FindElements(By.CssSelector(".color_to_pick_list.clearfix li a")).ToList();
        private IWebElement AddToCartButton => ParentElement.WaitAndGetElement(By.CssSelector(".button-container a"));
        private IWebElement Price => ParentElement.WaitAndGetElement(By.CssSelector(".content_price .price.product-price"));
        private IWebElement ImageButton => ParentElement.WaitAndGetElement(By.CssSelector("a .product_img_link"));

        public Product(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public CatalogPage StandOnProduct()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(ParentElement.FindElement(By.CssSelector(".left-block"))).Perform();

            return new CatalogPage(Driver);
        }
        public ProductPage ClickOnColor(int index = 0)
        {
            if (index < Colors.Count)
            {
                Colors[index].Click();

                return new ProductPage(Driver);
            }
            return null;
        }

        public Color GetColorHex(int index = 0)
        {
            if (index < Colors.Count)
            {
                return ColorTranslator.FromHtml(Colors[index].GetCssValue("background"));
            }
            return new Color();
        }

        public CatalogPage ClickOnAddToCart()
        {
            AddToCartButton.Click();
            ParentElement.WaitAndGetElement(By.CssSelector("#layer_cart .button-container span .continue.btn.btn-default.button.exclusive-medium")).Click();

            return new CatalogPage(Driver);
        }
        public string GetPriceString() => Price.Text;

        public double GetPrice()
        {
            return double.Parse(Price.Text.Substring(1));
        }

        public ProductPage ClickOnImageButton()
        {
            ImageButton.Click();

            return new ProductPage(Driver);
        }    
    }
}

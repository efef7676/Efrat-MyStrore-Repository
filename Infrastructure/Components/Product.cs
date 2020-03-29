using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Extensions;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Infrastructure
{
    public class Product : GeneralProduct
    {
        private List<IWebElement> Colors => ParentElement.FindElements(By.CssSelector(".color_to_pick_list.clearfix li a")).ToList();
        private IWebElement AddToCartButton => ParentElement.WaitAndFindElement(By.CssSelector(".button-container a"));
        private IWebElement Price => ParentElement.WaitAndFindElement(By.CssSelector(".content_price .price.product-price"));
        private IWebElement Name => ParentElement.WaitAndFindElement(By.CssSelector(".right-block .product-name"));
        protected override IWebElement Image => ParentElement.WaitAndFindElement(By.CssSelector(".product-image-container .product_img_link"));
        public bool IsAddToCartAvailable => AddToCartButton == null ? false : true;

        public Product(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public override Uri GetImageUri() => new Uri(Image.GetAttribute("href"));

        public override ProductPage ClickOnImage() => base.ClickOnImage();

        public double GetPrice() => double.Parse(Price.Text.Substring(1));

        public List<Color> GetColors()=>Colors.Select(s=>s.GetCssValue("background-color").ConvertToColor()).ToList();
        

        public CatalogPage StandOnProduct()
        {
            ParentElement.StandOn(Driver, By.CssSelector(".left-block"));

            return new CatalogPage(Driver);
        }

        public Color GetColor(int index = 0)
        {
            if (index < Colors.Count)
            {
                return Colors[index].GetCssValue("background-color").ConvertToColor();
            }
            return new Color();//maybe return null / throw an exception?
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

        public ProductPage ClickOnName()
        {
            Name.Click();

            return new ProductPage(Driver);
        }

        public BasePage ClickOnAddToCart(bool ContinueShopping = true)
        {
            if (AddToCartButton == null)
            {
                return null;
            }

            AddToCartButton.Click();

            if (ContinueShopping)
            {
                Driver.WaitAndFindElement(By.CssSelector("#layer_cart .continue.btn.btn-default.button.exclusive-medium")).Click();

                return new CatalogPage(Driver);
            }

            Driver.WaitAndFindElement(By.CssSelector("#layer_cart .btn.btn-default.button.button-medium")).Click();

            return new CartPage(Driver);
        }

    }
}

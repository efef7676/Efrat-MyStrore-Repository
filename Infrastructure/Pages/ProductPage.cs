using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Extensions;
using System.Drawing;

namespace Infrastructure
{
    public class ProductPage : BasePage
    {
        private IWebElement SelectedColor => Driver.WaitAndFindElement(By.CssSelector(".attribute_list li .selected"));
        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        public Color GetSelectedColor() => SelectedColor.GetCssValue("background-color").ConvertToColor();
    }
}

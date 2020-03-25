using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Drawing;


namespace Infrastructure
{
    public class FilterProduct : BaseComponent
    {
        private List<IWebElement> Colors => ParentElement.FindElements(By.CssSelector("#ul_layered_id_attribute_group_3 li")).ToList();


        public FilterProduct(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public void ClickOnColor(Color colorToClick)
        {
            Colors.FirstOrDefault(c =>
            ColorTranslator.FromHtml(c.FindElement(By.CssSelector("input")).GetCssValue("background")) == colorToClick)
                .FindElement(By.CssSelector("label a")).Click();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Extensions;

namespace Infrastructure
{
    public class QtyBox : BaseComponent
    {
        private IWebElement QtyValue => ParentElement.WaitAndFindElement(By.CssSelector("input[name=quantity_5_19_0_0_hidden]"));
        private IWebElement DownButton => ParentElement.WaitAndFindElement(By.CssSelector("a #cart_quantity_down_5_19_0_0"));
        private IWebElement UpButton => ParentElement.WaitAndFindElement(By.CssSelector("a #cart_quantity_up_5_19_0_0"));
        //check these selectors

        public QtyBox(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public int GetQtyValue() => int.Parse(QtyValue.GetAttribute("value"));

        public CartPage ClickOnUpButton()
        {
            UpButton.Click();

            return new CartPage(Driver);
        }
        public CartPage ClickDownUpButton()
        {
            DownButton.Click();

            return new CartPage(Driver);
        }
        public CartPage ChangeQty(double number)
        {
            QtyValue.Clear();
            QtyValue.SendKeys($"{number}");

            return new CartPage(Driver);
        }
    }
}

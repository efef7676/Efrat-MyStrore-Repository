﻿using System;
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
        private IWebElement QtyValue => ParentElement.WaitAndGetElement(By.CssSelector("input[name=quantity_5_19_0_0_hidden]"));
        private IWebElement DownButton => ParentElement.WaitAndGetElement(By.CssSelector("a #cart_quantity_down_5_19_0_0"));
        private IWebElement UpButton => ParentElement.WaitAndGetElement(By.CssSelector("a #cart_quantity_up_5_19_0_0"));
        //check these selectors

        public QtyBox(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

        public int GetQtyValue() => int.Parse(QtyValue.GetAttribute("value"));

        public void ClickOnUpButton() => UpButton.Click();

        public void ClickDownUpButton() => DownButton.Click();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class ProductPage : BasePage
    {

        public ProductPage(IWebDriver driver) : base(driver)
        {
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace Extensions
{
    public static class ISearchContextExtensions
    {
        public static IWebElement WaitAndFindElement(this ISearchContext iSearchContext, By by)
        {
            try
            {
                var wait = new DefaultWait<ISearchContext>(iSearchContext);
                wait.Timeout = TimeSpan.FromSeconds(10);
                return wait.Until(ctx =>
                {
                    try
                    {
                        var elem = ctx.FindElement(by);
                        if (!elem.Enabled || !elem.Displayed)
                            return null;
                        return elem;
                    }
                    catch (NoSuchElementException)
                    {
                        return null;
                    }
                });
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}

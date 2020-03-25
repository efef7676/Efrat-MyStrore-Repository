using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class ISearchContextExtensions
    {
        public static IWebElement WaitAndGetElement(this ISearchContext iSearchContext, By by)
        {
            var wait = new DefaultWait<ISearchContext>(iSearchContext);
            wait.Timeout = TimeSpan.FromSeconds(15);
            return wait.Until(ctx => {
                var elem = ctx.FindElement(by);
                if (!elem.Enabled)
                    return null;
                return elem;
            });
        }
    }
}

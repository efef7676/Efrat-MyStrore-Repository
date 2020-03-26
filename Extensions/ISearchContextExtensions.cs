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
            var wait = new DefaultWait<ISearchContext>(iSearchContext);
            wait.Timeout = TimeSpan.FromSeconds(15);
            return wait.Until(ctx =>
            {
                var elem = ctx.FindElement(by);
                if (!elem.Enabled||!elem.Displayed)
                    return null;
                return elem;
            });

        }

    }
}

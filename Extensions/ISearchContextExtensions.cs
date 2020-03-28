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
                wait.Timeout = TimeSpan.FromSeconds(15);
                return wait.Until(ctx =>
                {
                    var elem = ctx.FindElement(by);
                    wait.IgnoreExceptionTypes(typeof(Exception));
                    if (!elem.Enabled || !elem.Displayed)
                        return null;
                    return elem;
                });
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void WaitUntilElementIs(this ISearchContext iSearchContext, By by, string textValue)
        {
            var wait = new DefaultWait<ISearchContext>(iSearchContext);
            wait.Timeout = TimeSpan.FromSeconds(20);
            wait.Until(ctx =>
            {
                var elem = ctx.FindElement(by);
                if (!elem.Enabled || !elem.Displayed)
                    return null;
                if (elem.GetAttribute("value") == textValue)
                    return elem;

                return null;
            });
        }
        public static void WaitToElementToDisappear(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        public static void WaitToElementToDisappearSecond(this ISearchContext iSearchContext, By by)
        {
            var wait = new DefaultWait<ISearchContext>(iSearchContext);
            wait.Timeout = TimeSpan.FromSeconds(20);
            wait.Until(p =>
            {
                try
                {
                    return !(p.FindElement(by).Displayed);
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            });
        }
    }
}

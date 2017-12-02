using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DotNetCore.Utilities
{
    public class ElementHelper
    {
        private readonly IWebDriver _driver;
        public ElementHelper(IWebDriver driver)
        {
            this._driver = driver;
        }

        public IWebElement E(By locator)
        {
            return _driver.FindElement(locator);
        }

        public IList<IWebElement> EL(By locator)
        {
            return _driver.FindElements(locator);
        }

        public SelectElement S(By locator)
        {
            return new SelectElement(_driver.FindElement(locator));
        }
    }
}

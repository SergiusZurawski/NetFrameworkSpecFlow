using System;
using System.Collections.Generic;
using System.Text;
using DotNetCore.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace DotNetCore.Component
{
    public interface IComponent
    {
        void WaitUntilIsLoaded();
        bool IsVisible();
    }

    public abstract class AbstractComponent : IComponent
    {

        protected IWebDriver Driver;
        protected WebDriverWait Wait;
        protected readonly ElementHelper EHelper;
        protected readonly Actions Actions;

        public AbstractComponent(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(10000));
            EHelper = new ElementHelper(Driver);
            Actions = new Actions(Driver);
        }

        protected abstract IWebElement Root { get;}
        public abstract void WaitUntilIsLoaded();
        public abstract bool IsVisible();

        public IWebElement E(By locator)
        {
            return Root.FindElement(locator);
        }

        public IList<IWebElement> EL(By locator)
        {
            return Root.FindElements(locator);
        }

        public SelectElement S(By locator)
        {
            return new SelectElement(Root.FindElement(locator));
        }
    }
}

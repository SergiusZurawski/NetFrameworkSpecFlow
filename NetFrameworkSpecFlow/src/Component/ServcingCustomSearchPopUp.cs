using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace DotNetCore.Component
{
    public class ServcingCustomSearchPopUp : AbstractComponent
    {
        public ServcingCustomSearchPopUp(IWebDriver driver) : base(driver)
        {
        }

        private By root = By.Id("custom-servicing-provider-search");
        private By SerachButton = By.Id("servicing-provider-search-button");
        private By LastName = By.Id("servicing-provider-provider-last-name");
        protected override IWebElement Root {
            get { return Driver.FindElement(root); }
        }

        public override void WaitUntilIsLoaded()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(root));
            Wait.Until(ExpectedConditions.ElementIsVisible(SerachButton));
        }

        public override bool IsVisible()
        {
            return Root.Displayed;
        }

        public void EnterLastName(string lastName)
        {
            E(LastName).SendKeys(lastName);
        }

        public void Search()
        {
            E(SerachButton).Click();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace DotNetCore.Component
{
    public class NewAuthorizationPreScreeningPopUp : AbstractComponent
    {
        public NewAuthorizationPreScreeningPopUp(IWebDriver driver) : base(driver)
        {
        }

        private By root = By.Id("preScreeningMessageModal");
        private By primaryButton = By.Id("primary-button");
        protected override IWebElement Root {
            get { return Driver.FindElement(root); }
        }

        public override void WaitUntilIsLoaded()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(root));
            Wait.Until(ExpectedConditions.ElementIsVisible(primaryButton));
        }

        public override bool IsVisible()
        {
            return Root.Displayed;
        }

        public void Close()
        {
            Driver.FindElement(primaryButton).Click();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace DotNetCore.Component
{
    public class AdditionalProviderCustomSearchPopUp : AbstractComponent
    {
        public AdditionalProviderCustomSearchPopUp(IWebDriver driver) : base(driver)
        {
        }

        private By root = By.ClassName("additional-provider-search");
        private By SerachButton = By.CssSelector("div.aps-buttons button.btn-contextual");
        private By GroupName = By.CssSelector("input[data-bind='value: searchData.groupName']");
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

        public void EnterGroupName(string lastName)
        {
            E(GroupName).SendKeys(lastName);
        }

        public void Search()
        {
            E(SerachButton).Click();
        }
    }
}

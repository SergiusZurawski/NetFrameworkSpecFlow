using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace DotNetCore.Page
{
    class SearchForAuthorization : AbstractPage
    { 

        protected override string PagePath { get =>  "/authorizations/submission/plans/aries"; }
        private WebDriverWait _driverWait;

        private By CreateNewAuthorizationLink = By.Id("create-new-authorization");

        public SearchForAuthorization() 
        {
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(20000));
        }

        public override bool WaitUntilIsLoaded()
        {
            _driverWait.Until(ExpectedConditions.ElementExists(CreateNewAuthorizationLink));
            return _driver.FindElement(CreateNewAuthorizationLink).Displayed;
        }

       

        public void CreateNewAuthorization()
        {
            _driver.FindElement(CreateNewAuthorizationLink).Click();
        }
    }
}

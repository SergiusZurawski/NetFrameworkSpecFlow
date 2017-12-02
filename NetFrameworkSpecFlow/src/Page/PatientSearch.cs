using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace DotNetCore.Page
{
    class PatientSearch : AbstractPage
    {
        protected override string PagePath { get => "/authorizations/submission/plans/aries/patient-search-mock"; }
        private WebDriverWait _driverWait;
        

        private By Search = By.CssSelector("i.icon-search");

        public PatientSearch() 
        {
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(20000));
        }

        public override bool WaitUntilIsLoaded()
        {
            _driverWait.Until(ExpectedConditions.ElementExists(Search));
            return _driver.FindElement(Search).Displayed;
        }

       

        public void ClickSearch()
        {
            _driver.FindElement(Search).Click();
        }
    }
}

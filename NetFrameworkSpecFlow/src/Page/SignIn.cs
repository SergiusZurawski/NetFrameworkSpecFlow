using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace DotNetCore.Page
{
    class SignIn : AbstractPage
    {
        protected override string PagePath { get => "/sign-in"; }
       

        private By UserName = By.Id("LoginPortletUsername");
        private By Password = By.Id("LoginPortletPassword");
        private By SignButton = By.Id("btnSignInSubmit");

        public override bool WaitUntilIsLoaded()
        {
            _wait.Until(ExpectedConditions.ElementExists(UserName));
            return _driver.FindElement(UserName).Displayed;
        }

       

        public void EnterCredentials(string userName, string password)
        {
            _driver.FindElement(UserName).SendKeys(userName);
            _driver.FindElement(Password).SendKeys(password);
            _driver.FindElement(SignButton).Click();
        }
    }
}

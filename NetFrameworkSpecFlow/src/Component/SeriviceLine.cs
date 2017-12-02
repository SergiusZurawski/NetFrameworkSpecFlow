using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace DotNetCore.Component
{
    public class SeriviceLine : AbstractComponent
    {
        public SeriviceLine(IWebDriver driver) : base(driver)
        {
        }

        private readonly By _root = By.Id("serviceline-container");
        private readonly By _procedureCode = By.CssSelector("#serviceLine-procedure-div input");
        private readonly By _frequency = By.Id("frequency");
        private readonly By _ddlFrequency = By.Id("ddlFrequency");
        private readonly By _timeperiod = By.Id("timeperiod");
        private readonly By _ddlTimePeriod = By.Id("ddlTimePeriod");
        private readonly By _addServiceLine = By.Id("add-another-service-line");
        protected override IWebElement Root {
            get { return Driver.FindElement(_root); }
        }

        public override void WaitUntilIsLoaded()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_root));
        }

        public override bool IsVisible()
        {
            return Root.Displayed;
        }

        public void EnterProcedureCode(string procedure)
        {
            E(_procedureCode).Click();
            E(_procedureCode).SendKeys(procedure);
        }

        public void EnterFrequency(string frequency)
        {
            E(_frequency).SendKeys(frequency);
        }

        public void SelectDdlFrequency(string ddlFrequency)
        {
            S(_ddlFrequency).SelectByText(ddlFrequency);
        }

        public void EnterTimeperiod(string timeperiod)
        {
            E(_timeperiod).SendKeys(timeperiod);
        }

        public void SelectDdlTimePeriod(string ddlTimePeriod)
        {
            S(_ddlTimePeriod).SelectByText(ddlTimePeriod);
        }

        public void AddServiceLine()
        {
            E(_addServiceLine).Click();
        }
    }
}

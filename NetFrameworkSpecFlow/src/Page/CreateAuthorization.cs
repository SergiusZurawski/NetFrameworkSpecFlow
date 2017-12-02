using System;
using System.Collections.Generic;
using System.Text;
using DotNetCore.Component;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace DotNetCore.Page
{
    class CreateAuthorization : AbstractPage
    {
        protected override string PagePath { get => "/authorizations/submission/plans/aries/create"; }

        public NewAuthorizationPreScreeningPopUp AgreePopUp;
        private readonly ServcingCustomSearchPopUp _servicingPopUp;
        private readonly AdditionalProviderCustomSearchPopUp _additionalPopUp;
        private readonly SeriviceLine _seriviceLine;


        private readonly By _serviceType = By.Id("service-type");
        private readonly By _serviceTypeDropDown = By.CssSelector("#service-type-div .dropdown-container tbody tr:nth-child(1)");

        private readonly By _placeOfService = By.Id("place-of-service");
        private readonly By _placeOfServiceDropDown = By.CssSelector("#place-of-service-div .dropdown-container tbody tr:nth-child(1)");


        private readonly By _next = By.Id("go-to-page-2");

        private readonly By _dischargeDate = By.Id("DischargeDate");
        private readonly By _admissionDate = By.Id("AdmissionDate");
        private readonly By _admissionType = By.Id("admission-type");

        private readonly By _requestingProvider = By.Id("requesting-provider");
        private readonly By _requestingProviderDropDown = By.CssSelector("#requesting-provider-div .dropdown-container tbody tr:nth-child(1)");

        private readonly By _servicingProvider = By.Id("servicing-provider");
        private readonly By _servicingProviderResultDropDown = By.CssSelector("#servicing-provider-search-results-table tr:nth-child(2)");

        private readonly By _addtitionalProvider = By.Id("additional-provider1");
        private readonly By _addtitionalProviderResultFirstRow = By.Id("additional-provider-1-row-0");

        private readonly By _diagoeses = By.Id("diagnosis-code");
        private readonly By _diagoesesResult = By.CssSelector("#diagnosis-code ~ div.dropdown-container table tr.dropdown-item");

        private readonly By _addAttachment = By.CssSelector("input#inputupload");
        private readonly By _addAttachmentDocumentType = By.CssSelector("select.docTypeSelect");
        private readonly By _notes = By.Id("authorization-notes");
        private readonly By _submit = By.CssSelector("button[type=submit]");


        public CreateAuthorization() 
        {
            // TODO: move this to abstract class

            AgreePopUp = new NewAuthorizationPreScreeningPopUp(_driver);
            _servicingPopUp = new ServcingCustomSearchPopUp(_driver);
            _additionalPopUp = new AdditionalProviderCustomSearchPopUp(_driver);
            _seriviceLine = new SeriviceLine(_driver);
        }

        public override bool WaitUntilIsLoaded()
        {
            AgreePopUp.WaitUntilIsLoaded();
            return AgreePopUp.IsVisible();
        }

        public void SelectServiceType(string serviceType)
        {
            var e = _driver.FindElement(_serviceType);
            e.SendKeys(serviceType);
            _wait.Until(ExpectedConditions.ElementIsVisible(_serviceTypeDropDown));
            var eDropDown = _driver.FindElement(_serviceTypeDropDown);
            _wait.Until(ExpectedConditions.TextToBePresentInElement(eDropDown, serviceType));
            eDropDown.Click();
        }

        public void SelectPlaceOfService(string placeOfService)
        {
            var e = _driver.FindElement(_placeOfService);
            e.SendKeys(placeOfService);
            _wait.Until(ExpectedConditions.ElementIsVisible(_placeOfServiceDropDown));
            var eDropDown = _driver.FindElement(_placeOfServiceDropDown);
            _wait.Until(ExpectedConditions.TextToBePresentInElement(eDropDown, placeOfService));
            eDropDown.Click();
        }

        public void Next()
        {
            E(_next).Click();
        }

        public void TypeDischargeDateDirrectly(string date)
        {
            var e = _driver.FindElement(_dischargeDate);
            e.SendKeys(date);
        }

        public void SelectAdmitionType(string type)
        {
            var e = _driver.FindElement(_admissionType);
            var selectElement = new SelectElement(e);
            selectElement.SelectByText(type);
        }

        public void SelectRequestingProvider(string requestingProvider)
        {
            var e = _driver.FindElement(_requestingProvider);
            e.SendKeys(requestingProvider);
            _wait.Until(ExpectedConditions.ElementIsVisible(_requestingProviderDropDown));
            var eDropDown = _driver.FindElement(_requestingProviderDropDown);
            _wait.Until(ExpectedConditions.TextToBePresentInElement(eDropDown, requestingProvider));
            eDropDown.Click();
        }

        public void SearchForTheLastNameOfServicingProviderAndPickFirstFromResults(string lastName)
        {
            E(_servicingProvider).Click();
            _servicingPopUp.WaitUntilIsLoaded();
            _servicingPopUp.EnterLastName(lastName);
            _servicingPopUp.Search();
            _wait.Until(ExpectedConditions.ElementIsVisible(_servicingProviderResultDropDown));
            E(_servicingProviderResultDropDown).Click();
        }

        public void SearchForAdditionalProvider(string specialty = null, 
                                                string groupFacilityName = null,
                                                string groupNpi = null,
                                                string location = null,
                                                string lastName = null,
                                                string firstName = null)
        {
            E(_addtitionalProvider).Click();
            _additionalPopUp.WaitUntilIsLoaded();
            if (!string.IsNullOrEmpty(specialty))
            {
                _additionalPopUp.EnterGroupName(specialty);
            }
            _additionalPopUp.Search();
            _wait.Until(ExpectedConditions.ElementIsVisible(_addtitionalProviderResultFirstRow));
            var e = E(_addtitionalProviderResultFirstRow);
            _wait.Until(ExpectedConditions.TextToBePresentInElement(e, specialty));  //TODO: quick solution rethink it
            e.Click();
        }

        public void SetDiagnoses(string d)
        {
            E(_diagoeses).SendKeys(d);
            _wait.Until(ExpectedConditions.ElementIsVisible(_diagoesesResult));
            E(_diagoesesResult).Click();
        }

        public void SetServiceLine(string procedureCode, string frequency, string ddlFrequency, string timeperiod, string ddlTimePeriod)
        {
            _seriviceLine.WaitUntilIsLoaded();
            _seriviceLine.EnterProcedureCode(procedureCode);
            _seriviceLine.EnterFrequency(frequency);
            _seriviceLine.SelectDdlFrequency(ddlFrequency);
            _seriviceLine.EnterTimeperiod(timeperiod);
            _seriviceLine.SelectDdlTimePeriod(ddlTimePeriod);
            _seriviceLine.AddServiceLine();
        }

        public void UploadAttachment(string attachmentPath, string documentType = "Explanation of Benefits")
        {
            E(_addAttachment).SendKeys(@"C:\Users\Public\Pictures\Sample Pictures\Lighthouse.jpg");
            S(_addAttachmentDocumentType).SelectByText(documentType);
        }


        public void AddNotes(string notes)
        {
            E(_notes).SendKeys(notes);
        }

        public void Submit()
        {
            E(_submit).Click();
        }

        public void CopyAdmissionDateToDischargeDate()
        {
            E(_dischargeDate).SendKeys(E(_admissionDate).GetAttribute("value"));
        }
    }
}


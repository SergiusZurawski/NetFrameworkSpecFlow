using DotNetCore;
using DotNetCore.Page;
using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace NetFrameworkSpecFlow
{
    [Binding]
    public class AuthorizationSubmitionSteps
    {
        private readonly ScenarioContext scenarioContext;
        public AuthorizationSubmitionSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null) throw new ArgumentNullException("scenarioContext");
            this.scenarioContext = scenarioContext;
        }

        [Given(@"As a default user with Authorization Permitions enabled I login and go to search Authorization page")]
        public void AsADefaultUserWithAuthorizationPermitionsEnabledILoginAndGoToEBSearch()
        {
            var userName = TestContextCustom.Current.EnvConfig.UserCredentials[Constants.USER_CRDENTIALS_DEFAULT].UserName;
            var password = TestContextCustom.Current.EnvConfig.UserCredentials[Constants.USER_CRDENTIALS_DEFAULT].Password;
            SignInHelper sign = new SignInHelper();
            SignInHelper.SignInAndOpenEAndB(userName, password);
        }


        [Given(@"I populate patient search page with default values")]
        public void GivenIPopulatePatientSearchPageWithDefaultValues()
        {
            PatientSearch patientSearchPage = new PatientSearch();
            patientSearchPage.WaitUntilIsLoaded();
            patientSearchPage.ClickSearch();
        }

        [When(@"Create authorization page is filled for service type '(.*)' with values from the '(.*)'")]
        public void WhenCreateAuthorizationPageIsFilledForServiceTypeWithValuesFromThe(string p0, string p1)
        {
            Console.WriteLine("WhenCreateAuthorizationPageIsFilledForServiceTypeWithValuesFromThe");
        }

        [Then(@"I can see Authorization details page")]
        public void ThenICanSeeAuthorizationDetailsPage()
        {
            Console.WriteLine("ThenICanSeeAuthorizationDetailsPage");
        }

        //[AfterTestRun]
        //public static void AfterTestRun()
        //{
        //    int i = 1 + 2;
        //    Console.WriteLine(i);
        //    //factory.CloseAllDrivers();
        //    TestContextCustom.Current.BrowserFactory.CloseAllDrivers();
        //}

        //[OneTimeTearDown]
        //public void TeadownOne()
        //{
        //    TestContextCustom.Current.BrowserFactory.CloseAllDrivers();
        //}

    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace NetFrameworkSpecFlow.Steps
{
    [Binding]
    public class AuthorizationSteps
    {
        private IWebDriver driver;
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            //DesiredCapabilities caps = new DesiredCapabilities();
            //caps.SetCapability(CapabilityType.BrowserName, "chrome");
            //caps.SetCapability(CapabilityType.Version, "61");
            //caps.SetCapability(CapabilityType.Platform, "Windows 7");
            ////caps.SetCapability("deviceName", deviceName);
            ////caps.SetCapability("deviceOrientation", deviceOrientation);
            //caps.SetCapability("username", "sergii_zhuravskyi");
            //caps.SetCapability("accessKey", "50c0d526-e3f5-426f-b334-149979ef7b0c");
            //caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

            ////var proxy = new PassThroughProxy();
            ////proxy.Credentials = new NetworkCredential("sergii_zhuravskyi", "50c0d526-e3f5-426f-b334-149979ef7b0c");
            //driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps, TimeSpan.FromSeconds(120));
            //driver.Navigate().GoToUrl("http://www.google.com");
            //StringAssert.Contains("Google", driver.Title);
            //IWebElement query = driver.FindElement(By.Name("q"));
            //query.SendKeys("Sauce Labs");
            //query.Submit();
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            Console.WriteLine("WhenIPressAdd");
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Console.WriteLine("ThenTheResultShouldBeOnTheScreen");
        }
    }
}

using System;
using TechTalk.SpecFlow;

namespace NetFrameworkSpecFlow.Steps
{
    [Binding]
    public class AuthorizationSteps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            System.Threading.Thread.Sleep(10000);
            Console.WriteLine("GivenIHaveEnteredIntoTheCalculator");
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

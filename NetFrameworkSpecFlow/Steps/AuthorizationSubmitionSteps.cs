using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace NetFrameworkSpecFlow
{
    [Binding]
    public class AuthorizationSubmitionSteps
    {
        [Given(@"I open something")]
        public void GivenIOpenSomething()
        {
            Thread.Sleep(10000);
        }
        
        [Given(@"It waits a while")]
        public void GivenItWaitsAWhile()
        {
            Console.WriteLine("GivenItWaitsAWhile");
        }
        
        [When(@"It stop waiting")]
        public void WhenItStopWaiting()
        {
            Console.WriteLine("WhenItStopWaiting");
        }
        
        [Then(@"I can see the miracle")]
        public void ThenICanSeeTheMiracle()
        {
            Console.WriteLine("ThenICanSeeTheMiracle");
        }
    }
}

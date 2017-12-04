using DotNetCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NetFrameworkSpecFlow.FeatureSteps
{
    [Binding]
    public sealed class SetUpThearDownHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        //[OneTimeTearDown]
        //public void TeadownOne()
        //{
        //    TestContextCustom.Current.BrowserFactory.CloseAllDrivers();
        //}

        [AfterTestRun]
        public static void AfterTestRun()
        {
            int i = 1 + 2;
            Console.WriteLine(i);
            //factory.CloseAllDrivers();
            TestContextCustom.Current.BrowserFactory.CloseAllDrivers();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using DotNetCore.src.DTO.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Remote;

namespace DotNetCore
{
    public class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static readonly string location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static IWebDriver driver;
        private Dictionary<string, string> initConfig;
        private EnvironmentConfig envConfig;
        public static BrowserFactory Instance { get; private set; }
        private readonly string BrowserName;

        private readonly string _screenShoFolderPath = location + "/ScreenShots";
        private bool hasScreenShotDirectoryExists = false;

        private BrowserFactory(Dictionary<string, string> initConfig, EnvironmentConfig envConfig)
        {
            this.initConfig = initConfig;
            this.envConfig = envConfig;
            this.BrowserName = initConfig["webbrowser"];

            //TODO: we need this in order to close browsers, but there has to be a better way
        }

        public IWebDriver Driver
        {
            get
            {
                if (Instance == null)
                {
                    throw new Exception("BrowserFactory, hasn't been initialized yet. " +
                                            "Please, call BrowserFactory.InitFactory(Dictionary<string, string> initConfig, EnvironmentConfig envConfig) " +
                                            "before using BrowserFactory.Driver");
                }
                return Instance.InitBrowser();
            }
        }



        public static BrowserFactory InitFactory(Dictionary<string, string> initConfig, EnvironmentConfig envConfig)
        {
            Instance = new BrowserFactory(initConfig, envConfig);
            return Instance;
        }

        private IWebDriver InitBrowser()
        {
            string browserForThread = Thread.CurrentThread.ManagedThreadId + BrowserName;
            switch (BrowserName)
            {
                case "FF":
                    if (!Drivers.ContainsKey(browserForThread))
                    {
                        
                        FirefoxOptions options = new FirefoxOptions();
                        options.BrowserExecutableLocation =
                            @"C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe"; //TODO: REmove hardcoded value, move to config etc
                        var firingDriver = new EventFiringWebDriver(new FirefoxDriver(location, options));
                        firingDriver.ExceptionThrown += firingDriver_TakeScreenshotOnException;
                        Drivers.Add(browserForThread, firingDriver);

                    } 
                    return Drivers[browserForThread];  
                case "IE":
                    if (!Drivers.ContainsKey(browserForThread))
                    {
                        var firingDriver = new EventFiringWebDriver(new InternetExplorerDriver(location));
                        firingDriver.ExceptionThrown += firingDriver_TakeScreenshotOnException;
                        Drivers.Add(browserForThread, firingDriver);

                    }
                    return Drivers[browserForThread];
                case "SauceChrome":
                    if (!Drivers.ContainsKey(browserForThread))
                    {
                        //TODO: Extend for every test
                        DesiredCapabilities caps = new DesiredCapabilities();
                        caps.SetCapability(CapabilityType.BrowserName, "chrome");
                        caps.SetCapability(CapabilityType.Version, "61");
                        caps.SetCapability(CapabilityType.Platform, "Windows 7");
                        //caps.SetCapability("deviceName", deviceName);
                        //caps.SetCapability("deviceOrientation", deviceOrientation);
                        caps.SetCapability("username", "sergii_zhuravskyi");
                        caps.SetCapability("accessKey", "50c0d526-e3f5-426f-b334-149979ef7b0c");
                        caps.SetCapability("name", "DemoName, Temprorarly Solution");   
                        //TODO: Refactor. TryToPassSomewere.

                        //var proxy = new PassThroughProxy();
                        //proxy.Credentials = new NetworkCredential("sergii_zhuravskyi", "50c0d526-e3f5-426f-b334-149979ef7b0c");
                        var driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps, TimeSpan.FromSeconds(120));
                        var firingDriver = new EventFiringWebDriver(driver);
                        firingDriver.ExceptionThrown += firingDriver_TakeScreenshotOnException;
                        Drivers.Add(browserForThread, firingDriver);

                    }
                    return Drivers[browserForThread];
                default:
                    if (!Drivers.ContainsKey(browserForThread))
                    {
                        var firingDriver = new EventFiringWebDriver(new ChromeDriver(location));
                        firingDriver.ExceptionThrown += firingDriver_TakeScreenshotOnException;
                        Drivers.Add(browserForThread, new EventFiringWebDriver(firingDriver));

                    }
                    return Drivers[browserForThread];
            }
        }

//        public static void LoadApplication(string url)
//        {
//            Driver.Url = url;
//        }

        public void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }

        public void CloseWebDriver()
        {
            string browserForThread = Thread.CurrentThread.ManagedThreadId + BrowserName;
            Drivers[browserForThread].Close();
            Drivers[browserForThread].Quit();
        }

        private void firingDriver_TakeScreenshotOnException(object sender, WebDriverExceptionEventArgs e)
        {
            string name = e.GetType().FullName + DateTime.Now.ToString("yyyy-MM-dd-hhmm") + ".jpg";

            if (!hasScreenShotDirectoryExists)
            {
                if (!Directory.Exists(_screenShoFolderPath))
                {
                    Directory.CreateDirectory(_screenShoFolderPath);
                }
                hasScreenShotDirectoryExists = true;
            }
            Driver.TakeScreenshot().SaveAsFile(_screenShoFolderPath + "/" + name);
            Console.WriteLine("Screenshot is created by address:" + _screenShoFolderPath + "/" + name);

            //            if (!((TestOutputHelper) output).Output.Contains(name))
            //            {
            //output.WriteLine("Screenshot: " + fullName);
            //            }

        }



    }
}

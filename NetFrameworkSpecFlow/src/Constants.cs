using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DotNetCore
{
    public static class Constants
    {
        public static readonly string USER_CRDENTIALS_DEFAULT = "defaultUser";
        public static readonly string BROWSER_NAME = "webbrowser";
        public static readonly string ENVIRONMENT_CONFIG_PROPERTY_NAME = "environmentConfig";
        public static readonly string LAUNCH_SETTINGS_PATH = "/Properties/launchSettings.json";
        public static readonly string CONFIG_FOLDER_NAME = "/configs/{0}";
    }
}

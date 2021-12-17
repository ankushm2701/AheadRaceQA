using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using TechTalk.SpecFlow;

namespace AheadRaceTest.Model
{
    class Setting
    {
        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        private string _browserStackUser;

        private string _browserStackKey;

        public Setting(ScenarioContext scenarioContext)
        { 
            _scenarioContext = scenarioContext;
            _browserStackUser = "ankushmonga_oxUJbq";
            _browserStackKey = "kMNdGEsW7ykSjkyyf6mV";
        }

        public IWebDriver Setup(string browserName, string buildName, string device = default(string), int browserVersion = default(int), int os_Version = default(int), string os = default(string))
        {
            dynamic capability = GetBrowserType(browserName);
            if (device == "" && browserName != "Safari" && browserName != "MicrosoftEdge")
            {
                capability.AddAdditionalCapability("os", os, true);
                capability.AddAdditionalCapability("browser", browserName, true);
                capability.AddAdditionalCapability("browser_version", browserVersion, true);
                capability.AddAdditionalCapability("build", buildName, true);
                //capability.AddAdditionalCapability("os_version", "Windows", true);
                capability.AddAdditionalCapability("browserstack.user", _browserStackUser, true);
                capability.AddAdditionalCapability("browserstack.key", _browserStackKey, true);
            }
            else if (device == "" && browserName.ToLower().Contains("safari") || browserName.ToLower().Equals("microsoftedge"))
            {
                capability.AddAdditionalCapability("os", os);
                capability.AddAdditionalCapability("browser", browserName);
                capability.AddAdditionalCapability("browser_version", browserVersion);
                capability.AddAdditionalCapability("build", buildName);
                //capability.AddAdditionalCapability("os_version", version);
                capability.AddAdditionalCapability("browserstack.user", _browserStackUser);
                capability.AddAdditionalCapability("browserstack.key", _browserStackKey);
            }
            else if(device.ToLower().Contains("iphone"))
            {
                capability.AddAdditionalCapability("real_mobile", "true");
                capability.AddAdditionalCapability("os_version", os_Version);
                capability.AddAdditionalCapability("device", device);
                capability.AddAdditionalCapability("real_mobile", "true");
                capability.AddAdditionalCapability("build", buildName);
                capability.AddAdditionalCapability("browserstack.user", _browserStackUser);
                capability.AddAdditionalCapability("browserstack.key", _browserStackKey);
            }
            else
            {
                capability.AddAdditionalCapability("browser", "Android", true);
                capability.AddAdditionalCapability("os_version", os_Version, true);                
                capability.AddAdditionalCapability("device",device, true);
                capability.AddAdditionalCapability("real_mobile", "true", true);
                capability.AddAdditionalCapability("build", buildName, true);
                capability.AddAdditionalCapability("browserstack.local", "false", true);
                capability.AddAdditionalCapability("browserstack.user", "ankushmonga_oxUJbq", true);
                capability.AddAdditionalCapability("browserstack.key", "kMNdGEsW7ykSjkyyf6mV", true);
            }
            driver = new RemoteWebDriver(new Uri("https://hub-cloud.browserstack.com/wd/hub/"),
                capability.ToCapabilities());

            _scenarioContext.Set(driver, "WebDriver");

            if(device == "")
                driver.Manage().Window.Maximize();

            return driver;
        }

        private dynamic GetBrowserType(string _browserName)
        {
            switch (_browserName)
            {
                case "Chrome":
                    return new ChromeOptions();
                    break;
                case "Firefox":
                    return new FirefoxOptions();
                    break;
                case "MicrosoftEdge":
                    return new EdgeOptions();
                    break;
                case "Safari":
                    return new SafariOptions();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

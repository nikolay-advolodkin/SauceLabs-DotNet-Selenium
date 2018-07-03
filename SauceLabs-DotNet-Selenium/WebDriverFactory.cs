using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SauceLabsDotNetSelenium
{
    internal class WebDriverFactory
    {
        public IWebDriver CreateSauceDriver(string browser, string version, string os, string deviceName, string deviceOrientation)
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.Version, version);
            capabilities.SetCapability(CapabilityType.Platform, os);
            capabilities.SetCapability("deviceName", deviceName);
            capabilities.SetCapability("deviceOrientation", deviceOrientation);
            capabilities.SetCapability("username", "nikolay-a");
            capabilities.SetCapability("accessKey", "0fd366b1-548f-4ef4-8143-4746100fdf96");
            return new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
                capabilities, TimeSpan.FromSeconds(600));
        }

        public IWebDriver CreateSauceDriver(SauceConfiguration sauceConfig)
        {
            var driver = CreateSauceDriver(sauceConfig.Browser, sauceConfig.Version, sauceConfig.OS,
                sauceConfig.DeviceName, sauceConfig.DeviceOrientation);
            ((IJavaScriptExecutor)driver).ExecuteScript($"sauce:job-name={sauceConfig.TestCaseName}");
            return driver;
        }
    }
}
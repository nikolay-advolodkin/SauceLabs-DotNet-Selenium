using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SauceLabsDotNetSelenium
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }
        internal TestUser TheTestUser { get; private set; }
        internal TestUser EmergencyContactUser { get; private set; }
        public string Browser { get; set; }
        public string Version { get; set; }
        public string OS { get; set; }
        public string DeviceName { get; set; }
        public string DeviceOrientation { get; set; }

        public BaseTest(string browser, string version, string os, string deviceName, string deviceOrientation)
        {
            Browser = browser;
            Version = version;
            OS = os;
            DeviceName = deviceName;
            DeviceOrientation = deviceOrientation;
        }
        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            string isTestPassed = "failed";
            if (TestContext.CurrentContext.Result.Status == TestStatus.Passed)
                isTestPassed = "passed";

            ((IJavaScriptExecutor)Driver).ExecuteScript($"sauce:job-result={isTestPassed}");
            ((IJavaScriptExecutor)Driver).ExecuteScript($"sauce:context={TestContext.CurrentContext.Result}");
            Driver.Close();
            Driver.Quit();
        }

        [SetUp]
        public void SetupForEverySingleTestMethod()
        {
            var sauceConfig = new SauceConfiguration
            {
                Browser = Browser,
                Version = Version,
                OS = OS,
                DeviceName = DeviceName,
                DeviceOrientation = DeviceOrientation,
                TestCaseName = TestContext.CurrentContext.Test
            };

            Driver = new WebDriverFactory().CreateSauceDriver(sauceConfig);
        }

    }
}

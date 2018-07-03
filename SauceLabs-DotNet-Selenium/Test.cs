using NUnit.Framework;
using System;
namespace SauceLabsDotNetSelenium
{
    [Category("DataDrivenParallelTests")]
    [TestFixture("chrome", "45", "Windows 7", "", "")]
    [TestFixture("chrome", "50", "Windows 7", "", "")]
    [TestFixture("MicrosoftEdge", "14.14393", "Windows 10", "", "")]
    [TestFixture("chrome", "6.0", "Android", "Android Emulator", "portrait")]
    [TestFixture("Safari", "11.2", "iOS", "iPhone X Simulator", "portrait")]
    public class AdvancedSauceTests : BaseTest
    {
        public AdvancedSauceTests(string browser, string version, string os, string deviceName, string deviceOrientation) :
            base(browser, version, os, deviceName, deviceOrientation)
        {
        }

        [Test]
        public void OpenHomePage()
        {
            var homePage = new UltimateQAHomePage(Driver);
            homePage.GoTo();
            Assert.IsTrue(homePage.IsVisible);
        }

    }
}

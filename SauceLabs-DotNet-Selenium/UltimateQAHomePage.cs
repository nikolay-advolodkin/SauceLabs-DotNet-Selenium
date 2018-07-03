using System;
using OpenQA.Selenium;

namespace SauceLabsDotNetSelenium
{
    internal class UltimateQAHomePage
    {
        public IWebDriver Driver
        {
            get;
            set;
        }
        public bool IsVisible
        {
            get
            {
                try
                {
                    return StartHereButton.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
        public IWebElement StartHereButton => Driver.FindElement(By.LinkText("Start learning now"));
        public UltimateQAHomePage(OpenQA.Selenium.IWebDriver driver)
        {
            Driver = driver;
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com");
        }
    }
}
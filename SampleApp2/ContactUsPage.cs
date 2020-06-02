using OpenQA.Selenium;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleApp2
{
    internal class ContactUsPage
    {
        private IWebDriver Driver { get; set; }
        public ContactUsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public bool IsLoaded {
            get
            {
                try
                {
                    return Driver.FindElement(By.Id("center_column")).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=contact");                
            Driver.Manage().Window.Maximize();
        }
    }
}
using AutomationResrce;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SampleApp2
{
    public class BaseTest
    {
        public IWebDriver Driver { get; private set; }
        [TestInitialize]
        public void SetUpForEverySingleTestMethod()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Quit();
        }
    }
}
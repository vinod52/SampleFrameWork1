using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ReportingPrj
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver = null;
        [TestMethod]
        public void TestMethod1()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver= new ChromeDriver(outputDirectory);
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.FindElement(By.Id("email")).SendKeys("reporting");
        }
    }
}

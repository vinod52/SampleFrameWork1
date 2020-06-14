using System;
using System.IO;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ReportingPrj
{
    [TestClass]
    public class SampleReportClass
    {
        IWebDriver driver = null;
        ExtentReports extent = null;
        [TestInitialize]
        public void ExtentStart()
        {
            extent  = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"E:\VisualStudio\SampleFrameWork1\ReportingPrj\ExtentReports\Sample.html");
            extent.AttachReporter(htmlReporter);
        }
        [TestCleanup]
        public void ExtentClose()
        {
            extent.Flush();
        }
        [TestMethod]
        public void SampleReport()
        {
            ExtentTest test=extent.CreateTest("SampleReport").Info("Test Started");
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver= new ChromeDriver(outputDirectory);
            driver.Manage().Window.Maximize();
            test.Log(Status.Info,"Chrome Browser Launched");
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.FindElement(By.Id("email")).SendKeys("reporting");
            test.Log(Status.Info,"Email id is entered");            
            driver.Quit();
            test.Log(Status.Info, "Test1 Passed");
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace ReportingFW
{
    public class Tests
    {
        [OneTimeSetUp]
        public void ExtentStart()
        {
            //var extent = new ExtentReports();
            //extent.AttachReporter(reporterType);
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {

        }

        IWebDriver driver = null;
        [SetUp]
        public void Setup()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver=new ChromeDriver(outputDirectory);
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.FindElement(By.Id("email")).SendKeys("test");
            driver.Quit();
        }
    }
}